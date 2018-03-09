using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace CreateB
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * ======================================================================================================================================================
             */
            int tuplesCount = GetData.connectSQL();            //首先获取多维数据的数量

            /* 
             * 获取数据库中的元组数据并存入数组 
             */
            double[] longitudeArr = new double[tuplesCount];
            double[] latitudeArr = new double[tuplesCount];
            GetData.GetArray(ref longitudeArr, ref latitudeArr);//获取元组
            double peri = 0, cost = 0;
            peri = UsefulFunction.semiPeriU(UsefulFunction.minInArr(longitudeArr), UsefulFunction.minInArr(latitudeArr), UsefulFunction.maxInArr(longitudeArr), UsefulFunction.maxInArr(latitudeArr));
            cost = peri * tuplesCount;
            Console.WriteLine("Tips:The original cost of the buckets is:" + cost);
            //double[] longitudeArr = new double[34] { 116.28, 121.29, 117.11, 106.32, 126.41, 125.19, 123.24, 111.48, 114.28, 112.34, 117, 113.42, 108.54, 103.49, 106.16, 101.45, 87.36, 117.18, 118.50, 120.09, 113, 115.52, 114.21, 104.05, 106.42, 119.18, 121.31, 113.15, 110.20, 108.20, 102.41, 91.10, 114.10, 113.5 };
            //double[] latitudeArr = new double[34] { 39.54, 31.14, 39.09, 29.32, 45.45, 43.52, 41.50, 40.49, 38.02, 37.52, 36.38, 34.48, 34.16, 36.03, 38.20, 36.38, 43.48, 31.51, 32.02, 30.14, 28.11, 28.41, 30.37, 30.39, 26.35, 26.05, 25.03, 23.08, 20.02, 22.48, 25, 29.40, 22.18, 22.2 };
            //Console.WriteLine(longitudeArr.Length);
            //for (int i = 0; i < longitudeArr.Length; i++)
            //{
            //    Console.WriteLine(longitudeArr[i]);
            //}
            //初始R1的范围
            double rOneLongitudeFirst = 0;
            double rOneLatitudeFirst = 0;
            double rOneLongitudeSecond = 0;
            double rOneLatitudeSecond = 0;

            double rTwoLongitudeFirst = 0;//R2的范围
            double rTwoLatitudeFirst = 0;
            double rTwoLongitudeSecond = 0;
            double rTwoLatitudeSecond = 0;
            /*
             * ======================================================================================================================================================
             */
            /*
             * 我们需要把每次生成的R1和R*的范围存入以下集合中
             */
            ArrayList listROneLongitudeFirst = new ArrayList();
            ArrayList listROneLatitudeFirst = new ArrayList();
            ArrayList listROneLongitudeSecond = new ArrayList();
            ArrayList listROneLatitudeSecond = new ArrayList();

            ArrayList listRTwoLongitudeFirst = new ArrayList();
            ArrayList listRTwoLatitudeFirst = new ArrayList();
            ArrayList listRTwoLongitudeSecond = new ArrayList();
            ArrayList listRTwoLatitudeSecond = new ArrayList();

            string str = string.Empty;
            int bucketNum = 0;
            Console.Write("Please input the number of bucket's label that you want to create:");
            //bucketNum = Console.Read() - 48;
            str = Console.ReadLine();
            bucketNum = Convert.ToInt32(str);
            ArrayList listCost = new ArrayList();
            ArrayList listCostFinal = new ArrayList();
            Console.WriteLine("_______________________________________________________________________________");
            Console.WriteLine("\tRejust Or Not\t\t The cost of R1 and R*\t The cost of R*");
            for (int i = 0; i < bucketNum - 1; i++)//划分一次（最终加上R1有两个桶）
            {
                //用于在划分迭代计算时，存放新的数据集的集合
                ArrayList listLongitudeArr = new ArrayList();
                ArrayList listLatitudeArr = new ArrayList();
                /* 
                 * 如果R1中的数据集少于4个，就不能再分桶了
                 * 如果只有一个点，显然已经不是一个平面
                 * 如果还有两个分桶会是一样的
                 * 如果有三个，分桶后R1中只剩一个点，不能确定一个平面
                 */
                if (longitudeArr.Length < 4)
                    break;
                NewDataSet.getNewDataSet(longitudeArr, latitudeArr, ref listLongitudeArr, ref listLatitudeArr, ref rOneLongitudeFirst, ref rOneLatitudeFirst,
                    ref rOneLongitudeSecond, ref rOneLatitudeSecond, ref rTwoLongitudeFirst, ref rTwoLatitudeFirst, ref rTwoLongitudeSecond, ref rTwoLatitudeSecond,
                    ref listCost, ref listCostFinal);
                longitudeArr = (double[])listLongitudeArr.ToArray(typeof(double));
                latitudeArr = (double[])listLatitudeArr.ToArray(typeof(double));
                //注意添加到集合中的范围，集合中的第一项（下标从0开始）是R2的范围，集合中的最后一项（下标：list.Count-1）是R1的范围，中间的依次为R3，R4，R5...
                /*
                 * 在加入集合前我们需要判断新划分出来的桶会不会是一个点
                 * 如果是一个点，说明R1中的数据集不可以再进行划分了，因此需要立即终止该循环
                 * 否则继续划分
                 */
                //if ((rTwoLongitudeFirst == rTwoLongitudeSecond) && (rTwoLatitudeFirst == rTwoLatitudeSecond))
                //    break;
                ///*
                // * 除了划分出去的点外还要检查R1是不是也是一个点
                // */
                //if ((rOneLongitudeFirst == rOneLongitudeSecond) && (rOneLatitudeFirst == rOneLatitudeSecond))
                //    break;
                /*
                 * 在将矩形的范围存入集合中时，为了保持范围的一致性，按照参考文献的标准我们设计如下：
                 * first.x<second.x     first.y>second.y
                 */
                if (rOneLongitudeFirst > rOneLongitudeSecond)
                {
                    UsefulFunction.swap(ref rOneLongitudeFirst, ref rOneLongitudeSecond);
                }
                if (rTwoLongitudeFirst > rTwoLongitudeSecond)
                {
                    UsefulFunction.swap(ref rTwoLongitudeFirst, ref rTwoLongitudeSecond);
                }
                if (rOneLatitudeSecond > rOneLatitudeFirst)
                {
                    UsefulFunction.swap(ref rOneLatitudeSecond, ref rOneLatitudeFirst);
                }
                if (rTwoLatitudeSecond > rTwoLatitudeFirst)
                {
                    UsefulFunction.swap(ref rTwoLatitudeSecond, ref rTwoLatitudeFirst);
                }


                listROneLongitudeFirst.Add(rOneLongitudeFirst);
                listROneLatitudeFirst.Add(rOneLatitudeFirst);
                listROneLongitudeSecond.Add(rOneLongitudeSecond);
                listROneLatitudeSecond.Add(rOneLatitudeSecond);

                listRTwoLongitudeFirst.Add(rTwoLongitudeFirst);
                listRTwoLatitudeFirst.Add(rTwoLatitudeFirst);
                listRTwoLongitudeSecond.Add(rTwoLongitudeSecond);
                listRTwoLatitudeSecond.Add(rTwoLatitudeSecond);
            }
            Console.WriteLine("_______________________________________________________________________________");
            //for (int i = 0; i < listCostFinal.Count; i++)
            //{
            //    Console.WriteLine(listCostFinal[i]);
            //}
            int realLabelNum = 0;//真实生成的桶标签数
            realLabelNum = listROneLongitudeFirst.Count + 1;
            if (bucketNum > 1)
            {
                double[] costArr = (double[])listCost.ToArray(typeof(double));
                double[] costFinalArr = (double[])listCostFinal.ToArray(typeof(double));
                double costPartOne = 0, costPartTwo = 0, realCost = 0;
                for (int i = 1; i < realLabelNum; i++)
                {

                    costPartOne = costFinalArr[i - 1];
                    if (i == 1)//如果是第一次划分，只需要R1和R*的总成本
                    {
                        costPartTwo = 0;
                    }
                    else
                    {
                        costPartTwo += costArr[i - 2];
                    }
                    realCost = costPartOne + costPartTwo;
                    Console.WriteLine("The " + i + "th bucketization cost:" + realCost);
                }
                    //int icost = 0;
                    //for (icost = 0; icost < listCost.Count; icost++)
                    //{
                    //    if (listCost.Count - 1 == icost)//不加最后一项
                    //        break;
                    //    realCost += costArr[icost];
                    //}
                    //realCost += costFinalArr[listCostFinal.Count - 1];
                    //int itemp = icost + 1;
                    //Console.WriteLine("The " + itemp + "th bucketization cost:" + realCost);
                Console.WriteLine("_______________________________________________________________________________");
                Console.WriteLine("Tips:The real number of the bucket's label is:" + realLabelNum);//真实生成的桶标签数
                Console.WriteLine("Tips:The real cost of the bucketization algorithm is:" + realCost);//真实生成的桶标签数
            }
            else if (bucketNum == 1)
            {
                Console.WriteLine("The bucketization cost:" + cost);
                realLabelNum = listROneLongitudeFirst.Count + 1;
                Console.WriteLine("_______________________________________________________________________________");
                Console.WriteLine("Tips:The real number of the bucket's label is:" + realLabelNum);//真实生成的桶标签数
                Console.WriteLine("Tips:The real cost of the bucketization algorithm is:" + cost);//真实生成的桶标签数
            }
            else
            {
                Console.WriteLine("输入数据非法！");
            }
            /*
             * ======================================================================================================================================================
             */
            /*
             * 以下是存放R2,R3,R4,...R1范围的数组
             * rOne的数组中存放的是：R1,R1,R1......R1的范围，其中最后一个R1就是最终的R1范围
             * rTwo的数组中存放的是：R2,R3,R4.....的范围
             */
            double[] rOneLongitudeFirstArr = (double[])listROneLongitudeFirst.ToArray(typeof(double));
            double[] rOneLatitudeFirstArr = (double[])listROneLatitudeFirst.ToArray(typeof(double));
            double[] rOneLongitudeSecondArr = (double[])listROneLongitudeSecond.ToArray(typeof(double));
            double[] rOneLatitudeSecondArr = (double[])listROneLatitudeSecond.ToArray(typeof(double));

            double[] rTwoLongitudeFirstArr = (double[])listRTwoLongitudeFirst.ToArray(typeof(double));
            double[] rTwoLatitudeFirstArr = (double[])listRTwoLatitudeFirst.ToArray(typeof(double));
            double[] rTwoLongitudeSecondArr = (double[])listRTwoLongitudeSecond.ToArray(typeof(double));
            double[] rTwoLatitudeSecondArr = (double[])listRTwoLatitudeSecond.ToArray(typeof(double));
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            //将桶划分的结果写入本地的文件中，用于今后用户查询的读取进行桶标签的匹配

            string path = "D:\\BukectInfo3.txt";
            if (!File.Exists(path))
                File.Create(path);
            FileInfo finfo = new FileInfo(path);
            if (finfo.Exists)
            {
                finfo.Delete();
            }
            using (FileStream fs = finfo.OpenWrite())
            {
                //根据上面创建的文件流创建写文件流
                StreamWriter sw = new StreamWriter(fs);
                //设置写数据流的起始位置为文件流的末尾
                sw.BaseStream.Seek(0, SeekOrigin.End);
                if (realLabelNum == 1)
                {
                    //如果只有一个桶标签，说明只生成一个桶，就是原来的数据集
                    ArrayList list = new ArrayList();
                    list.Add(UsefulFunction.minInArr(longitudeArr));
                    list.Add(UsefulFunction.maxInArr(latitudeArr));
                    list.Add(UsefulFunction.maxInArr(longitudeArr));
                    list.Add(UsefulFunction.minInArr(latitudeArr));
                    double[] ff = (double[])list.ToArray(typeof(double));
                    foreach (double f in ff)
                    {
                        sw.Write("{0} ", f);
                    }
                    sw.Write("A\r\n");
                }
                else
                {
                    ArrayList list0 = new ArrayList();
                    list0.Add(rOneLongitudeFirstArr[rOneLongitudeFirstArr.Length - 1]);
                    list0.Add(rOneLatitudeFirstArr[rOneLatitudeFirstArr.Length - 1]);
                    list0.Add(rOneLongitudeSecondArr[rOneLongitudeSecondArr.Length - 1]);
                    list0.Add(rOneLatitudeSecondArr[rOneLatitudeSecondArr.Length - 1]);
                    double[] dd = (double[])list0.ToArray(typeof(double));
                    foreach (double d in dd)
                    {
                        sw.Write("{0} ", d);
                    }
                    sw.Write("A");
                    //windows下是用\r\n实现回车换行
                    sw.Write("\r\n");
                    //string s1 = "101.45 25 123.24 41.5 B";
                    //string s1 = rTwoLongitudeFirst.ToString() + " " + rTwoLatitudeFirst.ToString() + " "
                    //    + rTwoLongitudeSecond.ToString() + " " + rTwoLatitudeSecond.ToString() + " " + "B";
                    //sw.WriteLine(s1);
                    /*
                     * 因为给定的划分桶标签数量可能会大于真实生成的桶标签数（因为在数据集过小时，划分出来的桶会不是矩形而是一个点，这样的桶将会被舍弃，并终止当前的桶划分循环）
                     * 因此在写入桶范围，循环应该由真实生成的桶标签数决定，不能将bucketNum作为循环的判断条件
                     */
                    //for (int i = 0; i < bucketNum - 1; i++)
                    for (int i = 0; i < rOneLongitudeFirstArr.Length; i++)
                    {
                        ArrayList list1 = new ArrayList();
                        list1.Add(rTwoLongitudeFirstArr[i]);
                        list1.Add(rTwoLatitudeFirstArr[i]);
                        list1.Add(rTwoLongitudeSecondArr[i]);
                        list1.Add(rTwoLatitudeSecondArr[i]);
                        double[] ee = (double[])list1.ToArray(typeof(double));
                        foreach (double e in ee)
                        {
                            sw.Write("{0} ", e);
                        }
                        char c = 'B';
                        int asii = Convert.ToInt32(c) + i;
                        c = Convert.ToChar(asii);
                        sw.Write(c + "\r\n");
                    }
                }

                //清空缓冲区内容，并把缓冲区内容写入基础流
                sw.Flush();
                //关闭写数据流
                sw.Close();
                fs.Close();
            }

        }//Main

    }//Class Program
}//namespace
