using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Task1
{
    /*
     * 根据输入的数据找到本地文件存储的对应范围匹配的桶标签
     */
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


        static public string getLabel(string longitudeStr, string latitudeStr)
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
            /*
             * 存放每个数据
             * 因为本地文件存放有多行数据，每行数据又有5个数据：经度1，纬度1，经度2，纬度2，桶标签
             * 所以用二维数组words来存放
             * 一维表示一行数据，二维表示每个数据
             */


            /*
             * 数组words只包含每行的前4个数据，不包含最后一个桶标签
             */
            /*
             * 本来想将二维字符串数组先转化为double型的二维数组再参与运算的
             * 但是下面注释掉的写法在添加数据中总是报一个错：  未将对象引用设置到对象的实例
             * 经过调试发现二维字符串数组里的值并没有问题，但是就是无法转换其类型赋值到double的二维数组中
             */
            //double[][] words = new double[list.Count][];
            //for (int i = 0; i < list.Count-1; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        words[i][j] = Convert.ToDouble(wordsStr[i][j]);
            //    }
            //}

            double longitude=Convert.ToDouble(longitudeStr);
            double latitude=Convert.ToDouble(latitudeStr);

            //for (int i = 0; i < list.Count; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        Console.Write(wordsStr[i][j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine(wordsStr[2][4]);
            string bucketLabel = String.Empty;
            int index = 0;
            for (int i = 0; i < list.Count ; i++)
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
