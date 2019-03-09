using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4
{
    class Program
    {
       /*
         Вывести при помощи метода “Show()” значения полей первых 75 объектов из упорядоченной коллекции, 
         для которых значение поля “Post” равно “Dean”, а “Course” равно 3. Сравнить с результатом для неупорядоченной коллекции.

        */
        static void Main(string[] args)
        {
            ListGenerator.ShowList(ListGenerator.ReadCsv());
            Console.ReadKey();
        }
    }
}
