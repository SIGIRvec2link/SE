using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Task2
{
    class MarchLabel
    {
        /*
         * 以行为单位读取本地文件内容，并以行为单元存入集合中
         * 读取方式：
                    ArrayList list = read();
         */
        static ArrayList read()
        {
            StreamReader objReader = new StreamReader("D:\\BukectInfo3.txt");
            string sLine = "";
            ArrayList LineList = new ArrayList();
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null && !sLine.Equals(""))
                    LineList.Add(sLine);
            }
            objReader.Close();
            return LineList;
        }


        static public string getLabel(double longitude, double latitude)
        {
            //读取本地的桶标签信息
            ArrayList list = read();
            //将读取的信息存储在字符串数组中
            string[] sentences = (string[])list.ToArray(typeof(string));
            string[][] wordsStr = new string[list.Count * 5][];
            for (int i = 0; i < list.Count; i++)
            {
                wordsStr[i] = sentences[i].Split(' ');//将所有的数据存放在数组WordsStr中
            }
         
            //double longitude = Convert.ToDouble(longitudeStr);
            //double latitude = Convert.ToDouble(latitudeStr);

            string bucketLabel = String.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                /*
                 * 考虑该点所属范围的优先级（由高到低）：R2，R3，...Rn，R1(n个桶)
                 */
                if ((Convert.ToDouble(wordsStr[(i + 1) % list.Count][0]) <= longitude) && (Convert.ToDouble(wordsStr[(i + 1) % list.Count][2]) >= longitude)
                    && (Convert.ToDouble(wordsStr[(i + 1) % list.Count][1]) >= latitude) && (Convert.ToDouble((i + 1) % list.Count) <= latitude))
                {
                    //如果输入的数据在这个范围内，那么桶标签就为二维数组wordsStr第五列对应的数据
                    bucketLabel = wordsStr[(i + 1) % list.Count][4];
                    break;
                }
            }
            return bucketLabel;
        }
    }
}
