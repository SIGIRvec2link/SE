using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class AddData
    {
        static public void addData()
        {
            int tuplesCount = GetData.connectSQL();
            string[] provinceArr = new string[tuplesCount];
            string[] cityArr = new string[tuplesCount];
            double[] longitudeArr = new double[tuplesCount];
            double[] latitudeArr = new double[tuplesCount];
            double[] gdpArr = new double[tuplesCount];
            GetData.GetArray(ref provinceArr, ref cityArr, ref longitudeArr, ref latitudeArr, ref gdpArr);
            InsertData.insertData(provinceArr, cityArr, longitudeArr, latitudeArr, gdpArr);//插入数据
        }
    }
}
