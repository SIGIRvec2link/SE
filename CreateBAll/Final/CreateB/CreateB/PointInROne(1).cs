using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateB
{
    /* 
    * 在划分出R*后，统计R1中当前的点，并存入数组 
    */
    class PointInROne
    {
        static public void getNewArray(double[] longitudeArr, double[] latitudeArr, int first, int second, ref double[] longitudeArr1, ref double[] latitudeArr1)
        {
            //构成R*的两点
            Point pFirst = new Point(longitudeArr[first], latitudeArr[first]);
            Point pSecond = new Point(longitudeArr[second], latitudeArr[second]);
            //在存储更新经纬度过程中，更新后经纬度数组的下标
            int q = 0;
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
                        if ((longitudeArr[p] < longitudeArr[first]) || (longitudeArr[p] > longitudeArr[second])
                            || (latitudeArr[p] < latitudeArr[first]) || (latitudeArr[p] > latitudeArr[second]))
                        {
                            //若在R*范围外，就存入更新的经纬度数组
                            longitudeArr1[q] = longitudeArr[p];
                            latitudeArr1[q] = latitudeArr[p];
                            q++;
                        }
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>seconde.y)
                        if ((longitudeArr[p] < longitudeArr[first]) || (longitudeArr[p] > longitudeArr[second])
                            || (latitudeArr[p] > latitudeArr[first]) || (latitudeArr[p] < latitudeArr[second]))
                        {
                            //若在R*范围外，就存入更新的经纬度数组
                            longitudeArr1[q] = longitudeArr[p];
                            latitudeArr1[q] = latitudeArr[p];
                            q++;
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
                        if ((longitudeArr[p] > longitudeArr[first]) || (longitudeArr[p] < longitudeArr[second])
                            || (latitudeArr[p] < latitudeArr[first]) || (latitudeArr[p] > latitudeArr[second]))
                        {
                            //若在R*范围外，就存入更新的经纬度数组
                            longitudeArr1[q] = longitudeArr[p];
                            latitudeArr1[q] = latitudeArr[p];
                            q++;
                        }
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>seconde.y)
                        if ((longitudeArr[p] > longitudeArr[first]) || (longitudeArr[p] < longitudeArr[second])
                            || (latitudeArr[p] > latitudeArr[first]) || (latitudeArr[p] < latitudeArr[second]))
                        {
                            //若在R*范围外，就存入更新的经纬度数组
                            longitudeArr1[q] = longitudeArr[p];
                            latitudeArr1[q] = latitudeArr[p];
                            q++;
                        }
                    }
                }
            }//更新经纬度的for循环
        }

    }
}
