using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            GetData.creatTable();
            AddData.addData();
            int tuplesCount = GetData.connectSQL();
            Console.WriteLine("共插入" + tuplesCount + "条etuples");
        }
    }
}
