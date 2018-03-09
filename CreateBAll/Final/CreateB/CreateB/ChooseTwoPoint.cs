using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CreateB
{
    /* 
     * 选择构成R*的两点、当前最小的成本以及R*中的点数
     */
    class ChooseTwoPoint
    {
        /*
         * 注意：选择两点时有个特别重要的问题：就是如果选择的两点就是R1的边界，那么就说明该数据集不能再划分桶了，划分桶失败
         */
        static public int getTwoPoint(double[] longitudeArr, double[] latitudeArr, ref int first, ref int second, ref double minCostNewSum,
            ref int involveInRStar, ref double semiPerimeterOne, ref double semiPerimeterTwo)
        {
            //设置备份的经纬度数组
            double[] longitudeArrCopy = new double[longitudeArr.Length];
            longitudeArr.CopyTo(longitudeArrCopy, 0);
            double[] latitudeArrCopy = new double[latitudeArr.Length];
            latitudeArr.CopyTo(latitudeArrCopy, 0);
            //ArrayList list = new ArrayList(longitudeArr);
            //list.Sort();
            //longitudeArr = (double[])list.ToArray(typeof(double));
            //for (int i = 0; i < 34; i++)
            //{
            //    Console.WriteLine(longitudeArr[i]+","+longitudeArrCopy[i]);
            //}
            //Console.WriteLine(longitudeArr[0]);
            //求经度数组longitudeArr中的最大最小值之差
            double x = UsefulFunction.difference(longitudeArr);
            //求纬度数组latitudeArr中的最大最小值之差
            double y = UsefulFunction.difference(latitudeArr);
            //求出R1的半周长
            semiPerimeterOne = x + y;

            //当前R*的半周长
            semiPerimeterTwo = 0;

            //Console.WriteLine(semiPerimeterOne);
            //R1包含的数据集点数
            int countROne = longitudeArr.Length;
            //R1的开销
            double costROne = (double)countROne * semiPerimeterOne;
            //Console.WriteLine(costROne);

            //在分桶R2之前，我们需要计算在数据集中选择一对点对的数目
            //需要用到排列组合
            //其实排列实现了，组合也就实现了，组合C(N,R)=P(N,R)/P(R,R)
            //实现方法P(*,*)为static int permAndComb(int N, int R)
            int countChoose = UsefulFunction.permAndComb(countROne, 2) / UsefulFunction.permAndComb(2, 2);
            //Console.WriteLine(countChoose);

            //对于矩形R2

            //此次分桶成本的数组（因为有很多构成R*的点对，因此产生不同的成本，需存入一个数组）
            double[] costNewSum = new double[countChoose];
            //作为costNewSum数组的下标
            int k = 0;

            //存放构成R*点对的数组
            int[] arrfir = new int[countChoose];
            int[] arrsec = new int[countChoose];

            //选择一对构成R2最小成本的点
            for (int i = 0; i < longitudeArr.Length; i++)
            {
                for (int j = i + 1; j < latitudeArr.Length; j++)
                {
                    //从34个点中任选两个点试图作为构成R2对角线的两个端点（共561种情况）
                    Point pR21 = new Point(longitudeArr[i], latitudeArr[i]);
                    //Console.Write(i);
                    Point pR22 = new Point(longitudeArr[j], latitudeArr[j]);
                    //Console.WriteLine(j);
                    //Console.Write("(" + pR21.showx(pR21) + "," + pR21.showy(pR21) +
                    //    ") (" + pR22.showx(pR22) + "," + pR22.showy(pR22) + ")\t");

                    //计算当前R*的半周长
                    semiPerimeterTwo = pR21.SemiPeri(pR22);
                    //Console.Write(semiPerimeter2 + "\t");

                    //计算这两点构成的R*所包围的点数

                    //介于构成R*两点经度之间的点数countBetweenLongi
                    int countBetweenLongi = 0;
                    //介于构成R*两点之间的点数
                    int countBeRStar = 0;
                    //判断数值有无改变
                    int change = 0;
                    //保存下满足经度范围在经度数组的下标
                    int[] saveIndiceLongi = new int[longitudeArr.Length];
                    for (int i2 = 0; i2 < longitudeArr.Length; i2++)
                    {
                        if (((longitudeArrCopy[i2] > longitudeArr[i]) && (longitudeArrCopy[i2] < longitudeArr[j])) || ((longitudeArrCopy[i2] < longitudeArr[i]) && (longitudeArrCopy[i2] > longitudeArr[j])))
                        {
                            countBetweenLongi++;
                            //判断countBetweenLongi的值是否改变，如果改变了说明出现了介于经度范围之间的点
                            if ((countBetweenLongi - change) > 0)
                            {
                                change = countBetweenLongi;
                                //记录下满足经度范围的数组下标i2
                                saveIndiceLongi[countBetweenLongi] = i2;
                                //计算在满足经度范围内的点中，同时也满足维度范围的点数，这里需要注意经纬度的值并非单调递增递减，所以会有||
                                if (((latitudeArrCopy[saveIndiceLongi[countBetweenLongi]] > latitudeArr[i]) && (latitudeArrCopy[saveIndiceLongi[countBetweenLongi]] < latitudeArr[j]))
                                    || ((latitudeArrCopy[saveIndiceLongi[countBetweenLongi]] < latitudeArr[i]) && (latitudeArrCopy[saveIndiceLongi[countBetweenLongi]] > latitudeArr[j])))
                                {
                                    countBeRStar++;
                                }
                            }

                        }
                    }
                    //Console.Write(countBeRStar);
                    //构成R*的点数(根据我国省会城市分布特性，构成矩形上不会存在边界上的点，所以直接+2)
                    int countRStar = countBeRStar + 2;
                    //Console.Write(countRStar + "\t");

                    //计算当前R*的成本
                    double costRStar = countRStar * semiPerimeterTwo;
                    //Console.Write(costRStar+",");

                    //计算不包含R*中点时的矩形成本
                    double costDepartRStar = (double)(countROne - countRStar) * semiPerimeterOne;

                    //将每对点产生的成本存入数组
                    costNewSum[k] = costRStar + costDepartRStar;
                    //构成新桶的两点
                    arrfir[k] = i;
                    arrsec[k] = j;
                    k++;//k循环完后的值将==countChoose，也就是561

                }//内层for
            }//外层for
            //计算此次分桶的最小成本及最小成本桶对应的两个点
            ArrayList listCostNewSum = new ArrayList(costNewSum);
            listCostNewSum.Sort();
            //minCostNewSum是分桶R*的最小成本
            minCostNewSum = Convert.ToDouble(listCostNewSum[0]);
            //Console.WriteLine(minCostNewSum);
            for (int i = 0; i < k; i++)
            {
                if (costNewSum[i] == minCostNewSum)
                {
                    first = arrfir[i];
                    second = arrsec[i];
                    break;
                }
            }
            //构成最小成本分桶R*是两个点first和second
            //此时R*的半周长为这两个点构成矩形的半周长
            Point pFirst = new Point(longitudeArr[first], latitudeArr[first]);
            Point pSecond = new Point(longitudeArr[second], latitudeArr[second]);

            semiPerimeterTwo = pFirst.SemiPeri(pSecond);
            //Console.WriteLine(semiPerimeter2);

            //计算R*中包含的点数
            //involveInRStar = (int)(Math.Round((longitudeArr.Length * semiPerimeterOne - minCostNewSum) / (semiPerimeterOne - semiPerimeterTwo)));
            //根据公式计算有点问题，因为double精度上有问题，我们根据first和second来计算R*中包含的点数，这样也可以把边界的点算进去
                        //构成R*的两点
            //在存储更新经纬度过程中，更新后经纬度数组的下标
            for (int p = 0; p < longitudeArr.Length; p++)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<seconde.y)
                        //找出在这个R*范围外的点，分别在左右侧的经度和上下的维度外
                        if ((longitudeArr[p] >= longitudeArr[first]) && (longitudeArr[p] <= longitudeArr[second])
                            && (latitudeArr[p] >= latitudeArr[first]) && (latitudeArr[p] <= latitudeArr[second]))
                        {
                            //若在R*范围外，就存入更新的经纬度数组
                            involveInRStar++;
                        }
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>seconde.y)
                        if ((longitudeArr[p] >= longitudeArr[first]) && (longitudeArr[p] <= longitudeArr[second])
                            && (latitudeArr[p] <= latitudeArr[first]) && (latitudeArr[p] >= latitudeArr[second]))
                        {
                            //若在R*范围外，就存入更新的经纬度数组
                            involveInRStar++;
                        }
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<seconde.y)
                        //找出在这个R*范围外的点，分别在左右侧的经度和上下的维度外
                        if ((longitudeArr[p] <= longitudeArr[first]) && (longitudeArr[p] >= longitudeArr[second])
                            && (latitudeArr[p] >= latitudeArr[first]) && (latitudeArr[p] <= latitudeArr[second]))
                        {
                            //若在R*范围外，就存入更新的经纬度数组
                            involveInRStar++;
                        }
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>seconde.y)
                        if ((longitudeArr[p] <= longitudeArr[first]) && (longitudeArr[p] >= longitudeArr[second])
                            && (latitudeArr[p] <= latitudeArr[first]) && (latitudeArr[p] >= latitudeArr[second]))
                        {
                            //若在R*范围外，就存入更新的经纬度数组
                            involveInRStar++;
                        }
                    }
                }
            }//更新经纬度的for循环

            //Console.WriteLine(involveInRStar);
            return 0;
        }
    }
}
