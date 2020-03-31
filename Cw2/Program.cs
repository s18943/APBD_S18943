
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Cw2
{
    class Program
    {
        public static void ErrorLogging(Exception ex)
        {
            string logpath = @"C:\Users\s18943\source\repos\Cw1\log.txt";
            if (!File.Exists(logpath))
            {
                File.Create(logpath).Dispose();
            }
            StreamWriter sw = File.AppendText(logpath);
            sw.WriteLine("logging errors");
            sw.WriteLine("Start " + DateTime.Now);
            sw.WriteLine("Error " + ex.Message);
            sw.WriteLine("End " + DateTime.Now);
            sw.Close();

        }
        static void Main(string[] args)
        {
            try
            {

                string csvpath = Console.ReadLine(); // C:\Users\s18943\source\repos\Cw1\dane.csv
                string xmlpath = Console.ReadLine(); // C:\Users\s18943\source\repos\Cw1\
                string forpath = Console.ReadLine(); // xml
                if (File.Exists(csvpath) && Directory.Exists(xmlpath))
                {
                    string[] source = File.ReadAllLines(csvpath);
                    XElement xml = new XElement("uczelnia",
                        new XElement("studenci",
                        from str in source
                        let fields = str.Split(',')
                        select new XElement("student",
                          new XAttribute("StudentId", "s" + fields[4]),
                          new XElement("fname", fields[0]),
                          new XElement("lname", fields[1]),
                          new XElement("birthdate", fields[5]),
                          new XElement("email", fields[6]),
                          new XElement("mothersName", fields[7]),
                          new XElement("fathersName", fields[8]),
                          new XElement("studies",
                          new XElement("name", fields[2]),
                          new XElement("mode", fields[3])
                      )
                  )
                       )
                    );
                    xml.Save(String.Concat(xmlpath + "result.xml"));
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }
        }
    }
}