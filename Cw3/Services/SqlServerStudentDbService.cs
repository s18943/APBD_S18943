using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cw3.DTOs.Requests;
using Cw3.DTOs.Responses;
using Cw3.Models;

namespace Cw3.Services
{
    public class SqlServerStudentDbService : IStudentDbService
    {
        private string ConnectionString = "Data Source=db-mssql;Initial Catalog=s18943;Integrated Security=True";

        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                con.Open();
                var tran = con.BeginTransaction();
                com.Transaction = tran;
                try
                {
                    com.CommandText = "SELECT IdStudy FROM Studies WHERE Studies.Name=@name";
                    com.Parameters.AddWithValue("name", request.Studies);
                    var reader = com.ExecuteReader();

                    if (!reader.Read())
                    {
                        reader.Close();
                        tran.Rollback();
                        return null;
                    }
                    int idStudies = (int)reader["IdStudy"];
                    reader.Close();
                    com.CommandText = "SELECT IdEnrollment,StartDate FROM Enrollment " +
                        "WHERE Semester=1 AND idStudy=@idStudy AND StartDate=" +
                        "(SELECT max(startDate) FROM Enrollment WHERE Semester=1 AND idStudy=@idStudy)";
                    com.Parameters.AddWithValue("idStudy", idStudies);
                    reader = com.ExecuteReader();

                    int idEnrollment = -1;
                    DateTime date = DateTime.Today;

                    if (!reader.Read())
                    {
                        reader.Close();
                        com.CommandText = "SELECT max(IdEnrollment) AS 'id' FROM Enrollment";
                        reader = com.ExecuteReader();
                        idEnrollment = reader.Read() ? (int)reader["id"] + 1 : 1;
                        reader.Close();
                        com.CommandText = "INSERT INTO Enrollment(IdEnrollment,Semester,IdStudy,StartDate) " +
                                           "VALUES (@idEnrollment,1,@idStudy,@date)";
                        com.Parameters.AddWithValue("date", DateTime.Today.ToString("yyyy-MM-dd"));
                        com.Parameters.AddWithValue("idEnrollment", idEnrollment);
                        reader = com.ExecuteReader();
                    }
                    else
                    {
                        date = (DateTime)reader["StartDate"];
                        idEnrollment = (int)reader["IdEnrollment"];
                    }

                    reader.Close();

                    com.CommandText = "SELECT * FROM Student WHERE IndexNumber LIKE @index";
                    com.Parameters.AddWithValue("index", request.IndexNumber.ToString());
                    SqlDataReader sqlDataReader = com.ExecuteReader();
                    reader = sqlDataReader;
                    if (reader.Read())
                    {
                        reader.Close();
                        tran.Rollback();
                        return null;
                    }
                    reader.Close();
                    EnrollStudentResponse response = new EnrollStudentResponse();
                    response.IdEnrollment = idEnrollment;
                    response.IdStudy = idStudies;
                    response.Semester = 1;
                    response.StartDate = date;

                    com.CommandText = "INSERT INTO Student(IndexNumber,Firstname,LastName,BirthDate,IdEnrollment)" +
                                     " VALUES(@indexx,@Fname,@Lname,@bDate,@idEnrollment)";
                    com.Parameters.AddWithValue("indexx", request.IndexNumber);
                    com.Parameters.AddWithValue("Fname", request.FirstName);
                    com.Parameters.AddWithValue("Lname", request.LastName);
                    com.Parameters.AddWithValue("bDate", request.BirthDate.ToString("yyyy-MM-dd"));
                    com.Parameters.AddWithValue("idEnrollment", idEnrollment);
                    com.ExecuteNonQuery();

                    reader.Close();
                    tran.Commit();
                    return response;
                }
                catch (SqlException exc)
                {
                    Console.WriteLine(exc.Message);
                    tran.Rollback();
                }

            }
            return null;
        }

        public PromoteStudentResponse PromoteStudents(PromoteStudentRequest request)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("dbo.PromoteStudents", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Studies", SqlDbType.VarChar, 100).Value = request.Studies;
                    command.Parameters.Add("@semester", SqlDbType.Int).Value = request.Semester;
                    connection.Open();
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PromoteStudentResponse response = new PromoteStudentResponse
                                {
                                    IdEnrollment = (int)reader["IdEnrollment"],
                                    Semester = (int)reader["Semester"],
                                    IdStudy = (int)reader["IdStudy"],
                                    StartDate = (DateTime)reader["StartDate"]
                                };
                                return response;
                            }
                            Console.WriteLine("Failed: Unable to read.");
                            return null;

                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine("Failed: Check if procedure exists. " + e.Message);
                        return null;

                    }
                }
            }
        }

        public Student GetStudent(string indexNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand("SELECT * FROM Student WHERE IndexNumber = @index", connection))
                {

                    command.Parameters.AddWithValue("index", indexNumber);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {

                        if (!reader.Read())
                            return null;
                        return new Student
                        {

                            IndexNumber = indexNumber,
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            BirthDate = (DateTime)reader["BirthDate"],
                            IdEnrollment = (int)reader["IdEnrollment"]
                        };
                    }
                }
            }
        }
    }
}
