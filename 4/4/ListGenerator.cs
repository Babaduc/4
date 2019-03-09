using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class ListGenerator
    {
       
        public static List<Students> ReadCsv()
        {
            var university = new StreamReader("university.csv");
            List<Students> StudList = new List<Students>();
            university.ReadLine();
            while (!university.EndOfStream)
            {
                var line = university.ReadLine();
                var values = line.Split(';');
                Students student = new Students(values[0], values[1], short.Parse(values[3]), int.Parse(values[4]), values[2]);
                StudList.Add(student);
            }
            university.Close();
            return StudList;
        }

        public static void ShowList(List<Students> StudList)
        {
            Stopwatch sw = Stopwatch.StartNew();
         
            var t = (from stud in StudList
                     where stud.Course == 4
                     where stud.Post == "Academic"
                     select stud);
            t = (from stud in t.Take(75)
                     select stud);
           
            Parallel.ForEach(t, (s) => { Console.WriteLine(s.Show()); });
            long ms = sw.ElapsedMilliseconds;
            Console.WriteLine("Процесс завершен за {0} мс", ms);
            Console.WriteLine("\n\n\nУпорядоченный: --------------------------------------\n\n\n");
            Stopwatch sw1 = Stopwatch.StartNew();
            t = (from stud in t.Take(75).OrderBy(u => u.FirstName)
                 select stud);
        
            Parallel.ForEach(t, (s) => { Console.WriteLine(s.Show()); });
            long ms1 = sw1.ElapsedMilliseconds;
            Console.WriteLine("\n=============================\n");
           
            Console.WriteLine("Процесс завершен за {0} мс", ms1);
        }
    }
}