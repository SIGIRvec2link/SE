using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CreateB
{
    /* 
     * 一些有用的函数  
     */
    class UsefulFunction
    {
        //求数组中的最小值
        /*************************************************
          Function:          minInArr
          Description:    // 求数组中的最小值
          Calls:          // 被本函数调用的函数清单
          Called By:      // 调用本函数的函数清单
          Table Accessed: // 被访问的表（此项仅对于牵扯到数据库操作的程序）
          Table Updated:  // 被修改的表（此项仅对于牵扯到数据库操作的程序）
          Input:             数组
          Output:         
          Return:         // 返回数组中的最小值
          Others:         
        *************************************************/
        static public double minInArr(double[] d)
        {
            ArrayList list = new ArrayList(d);
            list.Sort();
            double min = Convert.ToDouble(list[0]);
            return min;
        }

        //求数组中的最大值
        static public double maxInArr(double[] d)
        {
            ArrayList list = new ArrayList(d);
            list.Sort();
            double max = Convert.ToDouble(list[list.Count - 1]);
            return max;
        }

        //求数组中最大最小值之差
        static public double difference(double[] d)
        {
            double min = minInArr(d);
            double max = maxInArr(d);
            double diff = max - min;
            return diff;
        }

        //计算C(N,R)
        static public int permAndComb(int N, int R)
        {
            if (R > N || R <= 0 || N <= 0)
                throw new ArgumentException("params invalid!");
            int t = 1;
            int i = N;

            while (i != N - R)
            {
                try
                {
                    //因为溢出也是一种异常，但是它不会被系统自动抛出，所以需要用checked手动将其抛出
                    checked
                    {
                        t *= i;
                    }
                }
                catch
                {
                    throw new OverflowException("overflow happens！");
                }
                --i;
            }
            return t;
        }

        //找出R*调整后包含进去点的经度或纬度
        //d1:经度数组;d2：纬度数组;两个点的经纬度(a1,a2),(b1,b2)
        static public double findOut(double[] d1, double[] d2, double a1, double a2, double b1, double b2)
        {
            for (int i = 0; i < d1.Length; i++)
            {
                if (d1[i] == a1)
                    return a1;
                if (d1[i] == b1)
                    return b1;
                if (d2[i] == a2)
                    return a2;
                if (d2[i] == b2)
                    return b2;
            }
            return -1;
        }

        //返回一个数在数组中的下标
        static public int search(double[] a, int n, double t)//a是数组，n是数组大小，t是要查找的数
        {
            for (int i = 0; i < n; i++)
            {
                if (a[i] == t)
                    return i;
            }
            return -1;
        }


        //删除数组中某一下标的元素形成新的数组
        static public double[] newArr(double[] d, int index)
        {
            ArrayList list = new ArrayList(d);
            list.RemoveAt(index);
            return ((double[])list.ToArray(typeof(double)));
        }

        //计算已知矩形范围，但是其对角线的两点不为数据集中点的矩形的半周长
        //一个矩形的范围(a,c),(b,d)
        static public double semiPeriU(double a, double b, double c, double d)
        {
            double t1 = Math.Abs(a - c);
            double t2 = Math.Abs(b - d);
            return (t1 + t2);
        }


        /*
         * 使两个数从小到大排列
         */
        static public void swap(ref double a, ref double b)
        {
            if (a > b)
            {
                double temp = a;
                a = b;
                b = temp;
            }
        }

    }
}
