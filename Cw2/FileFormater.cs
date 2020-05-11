using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Cw2
{
    class FileFormater
    {
        public void kotlet()
        {

            //string[] source = File.ReadAllLines(csvpath);
            var list = new List<Student>();

            //foreach String str in source
            //    let fields = str.Split(',');
            //    list.Add(new Student { StudentId = "s", Imie = "Jan", Nazwisko = "Kowalski", Birthdate = "fields[5]",
            //        Email = "fields[6]",
            //        MothersName = "fields[7]",
            //        FathersName = "fields[8]" });

            var jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText("data.json", jsonString);
        }
    }
}
