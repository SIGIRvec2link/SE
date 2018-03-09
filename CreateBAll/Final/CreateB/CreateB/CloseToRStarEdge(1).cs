using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CreateB
{
    /*
     * R*外上下左右四边的相关计算
     */
    class CloseToRStarEdge
    {
        /* 
         * 求在R*外上下左右四处范围内的点的集合
         * listLongitudeArrClose1（经度）:R*外左侧点的集合
         * listLongitudeArrClose2（经度）：R*外右侧点的集合
         * listLatitudeArrClose1（纬度）：R*外上侧点的集合
         * listLatitudeArrClose2（纬度）：R*外下侧点的集合
         */
        static public void getNewList(double[] longitudeArr, double[] latitudeArr, int first, int second, int involveInRStar, double[] longitudeArr1, double[] latitudeArr1,
            ref ArrayList listLongitudeArrClose1, ref ArrayList listLongitudeArrClose2, ref ArrayList listLatitudeArrClose1, ref ArrayList listLatitudeArrClose2)
        {
            Point pFirst = new Point(longitudeArr[first], latitudeArr[first]);
            Point pSecond = new Point(longitudeArr[second], latitudeArr[second]);
            for (int i = 0; i < (longitudeArr.Length - involveInRStar); i++)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<seconde.y)
                        //此时计算介于两点经纬度之间，R*外的点到四条经纬度线之间的最小距离
                        if ((latitudeArr1[i] > latitudeArr[first]) && (latitudeArr1[i] < latitudeArr[second])
                            || ((longitudeArr1[i] > longitudeArr[first]) && (longitudeArr1[i] < longitudeArr[second])))
                        {
                            if ((longitudeArr[first] - longitudeArr1[i]) > 0)//离R*左边最近的点
                            {
                                listLongitudeArrClose1.Add(longitudeArr1[i]);
                            }
                            if ((longitudeArr1[i] - longitudeArr[second]) > 0)//R*右边
                            {
                                listLongitudeArrClose2.Add(longitudeArr1[i]);
                            }
                            if ((latitudeArr1[i] - latitudeArr[second]) > 0)//R*上边
                            {
                                listLatitudeArrClose1.Add(latitudeArr1[i]);
                            }
                            if ((latitudeArr[first] - latitudeArr1[i]) > 0)//R*下边
                            {
                                listLatitudeArrClose2.Add(latitudeArr1[i]);
                            }
                        }
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>seconde.y)
                        //此时计算介于两点经纬度之间，R*外的点到四条经纬度线之间的最小距离
                        if ((latitudeArr1[i] < latitudeArr[first]) && (latitudeArr1[i] > latitudeArr[second])
                            || ((longitudeArr1[i] > longitudeArr[first]) && (longitudeArr1[i] < longitudeArr[second])))
                        {
                            if ((longitudeArr[first] - longitudeArr1[i]) > 0)//离R*左边最近的点
                            {
                                listLongitudeArrClose1.Add(longitudeArr1[i]);
                            }
                            if ((longitudeArr1[i] - longitudeArr[second]) > 0)//R*右边
                            {
                                listLongitudeArrClose2.Add(longitudeArr1[i]);
                            }
                            if ((latitudeArr1[i] - latitudeArr[first]) > 0)//R*上边
                            {
                                listLatitudeArrClose1.Add(latitudeArr1[i]);
                            }
                            if ((latitudeArr[second] - latitudeArr1[i]) > 0)//R*下边
                            {
                                listLatitudeArrClose2.Add(latitudeArr1[i]);
                            }
                        }
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<seconde.y)
                        //此时计算介于两点经纬度之间，R*外的点到四条经纬度线之间的最小距离
                        if ((latitudeArr1[i] > latitudeArr[first]) && (latitudeArr1[i] < latitudeArr[second])
                            || ((longitudeArr1[i] < longitudeArr[first]) && (longitudeArr1[i] > longitudeArr[second])))
                        {
                            if ((longitudeArr[second] - longitudeArr1[i]) > 0)//离R*左边最近的点
                            {
                                listLongitudeArrClose1.Add(longitudeArr1[i]);
                            }
                            if ((longitudeArr1[i] - longitudeArr[first]) > 0)//R*右边
                            {
                                listLongitudeArrClose2.Add(longitudeArr1[i]);
                            }
                            if ((latitudeArr1[i] - latitudeArr[second]) > 0)//R*上边
                            {
                                listLatitudeArrClose1.Add(latitudeArr1[i]);
                            }
                            if ((latitudeArr[first] - latitudeArr1[i]) > 0)//R*下边
                            {
                                listLatitudeArrClose2.Add(latitudeArr1[i]);
                            }
                        }
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>seconde.y)
                        //此时计算介于两点经纬度之间，R*外的点到四条经纬度线之间的最小距离
                        if ((latitudeArr1[i] < latitudeArr[first]) && (latitudeArr1[i] > latitudeArr[second])
                            || ((longitudeArr1[i] < longitudeArr[first]) && (longitudeArr1[i] > longitudeArr[second])))
                        {
                            if ((longitudeArr[second] - longitudeArr1[i]) > 0)
                            {
                                //longitudeArrClose1.Add(longitudeArr[second] - longitudeArr1[i]);
                                listLongitudeArrClose1.Add(longitudeArr1[i]);
                            }
                            if ((longitudeArr1[i] - longitudeArr[first]) > 0)
                            {
                                listLongitudeArrClose2.Add(longitudeArr1[i]);
                            }
                            if ((latitudeArr1[i] - latitudeArr[first]) > 0)
                            {
                                listLatitudeArrClose1.Add(latitudeArr1[i]);
                            }
                            if ((latitudeArr[second] - latitudeArr1[i]) > 0)
                            {
                                listLatitudeArrClose2.Add(latitudeArr1[i]);
                            }
                        }
                    }
                }
            }//存储介于两点经纬度之间，R*外的点到四条经纬度线之间的最小距离的for循环
        }


        /* 
         * 求在R*外上下两处范围内的点的集合
         * listLongitudeArrClose3（经度）:R*外上侧点的集合
         * listLongitudeArrClose4（经度）：R*外上侧点的集合
         */
        static public void getLongitudeNewList(double[] latitudeArrClose1, double[] latitudeArrClose2, double[] longitudeArr, double[] latitudeArr,
            ref ArrayList listLongitudeArrClose3, ref ArrayList listLongitudeArrClose4)
        {
            //因为latitudeArrClose1、2里存的是纬度，必须要先找到其经度，再使用Except
            for (int i = 0; i < latitudeArrClose1.Length; i++)
            {
                int indexTemp = UsefulFunction.search(latitudeArr, latitudeArr.Length, latitudeArrClose1[i]);
                listLongitudeArrClose3.Add(longitudeArr[indexTemp]);
            }

            for (int i = 0; i < latitudeArrClose2.Length; i++)
            {
                int indexTemp = UsefulFunction.search(latitudeArr, latitudeArr.Length, latitudeArrClose2[i]);
                listLongitudeArrClose4.Add(longitudeArr[indexTemp]);
            }
        }


        /* 
         * 求在R*外上下左右四处范围内的点的最近距离及最近点的下标
         * diffLeft：R*外左侧最近的距离值             indexRStarLeft：R*外左侧最近点的下标（通过longitudeArr1和latitudeArr1访问）
         * diffRight：R*外右侧最近的距离值            indexRStarRight：R*外右侧最近点的下标（通过longitudeArr1和latitudeArr1访问）
         * diffTop：R*外上侧最近的距离值              indexRStarTop：R*外上侧最近点的下标（通过longitudeArr1和latitudeArr1访问）
         * diffBottom：R*外下侧最近的距离值           indexRStarBottom：R*外下侧最近点的下标（通过longitudeArr1和latitudeArr1访问）
         */
        static public void getClosest(double[] longitudeArr, double[] latitudeArr, double[] longitudeArr1, double[] latitudeArr1, int first, int second, int r,
            ArrayList listLongitudeArrClose1, ArrayList listLongitudeArrClose2, ArrayList listLatitudeArrClose1, ArrayList listLatitudeArrClose2,
            ref double diffLeft, ref double diffRight, ref double diffTop, ref double diffBottom,
            ref int indexRStarLeft, ref int indexRStarRight, ref int indexRStarTop, ref int indexRStarBottom)
        {
            Point pFirst = new Point(longitudeArr[first], latitudeArr[first]);
            Point pSecond = new Point(longitudeArr[second], latitudeArr[second]);
            //我们先看R*左边最近的点
            listLongitudeArrClose1.Sort();
            //for (int i = 0; i < longitudeArrClose1.Count; i++)
            //{
            //    Console.WriteLine(longitudeArrClose1[i]);
            //}
            if (listLongitudeArrClose1.Count == 0)
            {
                diffLeft = 100;
            }
            else
            {
                double maxRStarLeft = (double)listLongitudeArrClose1[listLongitudeArrClose1.Count - 1];//左边离R*最近点就是选择经度最大的
                indexRStarLeft = UsefulFunction.search(longitudeArr1, r, maxRStarLeft);//r是R*外R1内的点数
                //Console.Write(indexRStarLeft);
                Point pLeft = new Point(longitudeArr1[indexRStarLeft], latitudeArr1[indexRStarLeft]);
                //Console.WriteLine(pLeft.showx(pLeft) + "," + pLeft.showy(pLeft)); 
                //计算diffLeft
                //先判断两点经度的大小，需要确定左边那根经度是点一确定的还是点二
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<seconde.y)
                        //R*左边的线由点一的经度确定
                        diffLeft = longitudeArr[first] - pLeft.showx(pLeft);
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>seconde.y)
                        //R*左边的线由点一的经度确定
                        diffLeft = longitudeArr[first] - pLeft.showx(pLeft);
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<seconde.y)
                        //R*左边的线由点二的经度决定
                        diffLeft = longitudeArr[second] - pLeft.showx(pLeft);
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>seconde.y)
                        //R*左边的线由点二的经度决定
                        diffLeft = longitudeArr[second] - pLeft.showx(pLeft);
                    }
                }
            }
            //Console.WriteLine(diffLeft);

            //Console.WriteLine("右");
            ////我们先看R*右边最近的点
            listLongitudeArrClose2.Sort();
            //for (int i = 0; i < longitudeArrClose2.Count; i++)
            //{
            //    Console.WriteLine(longitudeArrClose2[i]);
            //}

            if (listLongitudeArrClose2.Count == 0)
            {
                diffRight = 100;
            }
            else
            {
                double minRStarRight = (double)listLongitudeArrClose2[0];//右边就是选择经度最小的
                indexRStarRight = UsefulFunction.search(longitudeArr1, r, minRStarRight);
                //Console.Write(indexRStarRight);
                Point pRight = new Point(longitudeArr1[indexRStarRight], latitudeArr1[indexRStarRight]);
                //Console.WriteLine(pLeft.showx(pRight) + "," + pLeft.showy(pRight));
                //计算diffRight
                //先判断两点经度的大小，需要确定右边那根经度是点一确定的还是点二
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<seconde.y)
                        //R*右边的线由点二的经度确定
                        diffRight = pRight.showx(pRight) - longitudeArr[second];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>seconde.y)
                        //R*右边的线由点二的经度确定
                        diffRight = pRight.showx(pRight) - longitudeArr[second];
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<seconde.y)
                        //R*右边的线由点一的经度决定
                        diffRight = pRight.showx(pRight) - longitudeArr[first];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>seconde.y)
                        //R*右边的线由点一的经度决定
                        diffRight = pRight.showx(pRight) - longitudeArr[first];
                    }
                }
            }
            //Console.WriteLine(diffRight);



            //Console.WriteLine("上");
            ////我们先看R*上边最近的点
            listLatitudeArrClose1.Sort();
            //for (int i = 0; i < listLatitudeArrClose1.Count; i++)
            //{
            //    Console.WriteLine(listLatitudeArrClose1[i]);
            //}
            if (listLatitudeArrClose1.Count == 0)
            {
                diffTop = 100;
            }
            else
            {
                double minRStarTop = (double)listLatitudeArrClose1[0];//上边就是选择维度最小的
                indexRStarTop = UsefulFunction.search(latitudeArr1, r, minRStarTop);
                //Console.Write(indexRStarTop);
                Point pTop = new Point(longitudeArr1[indexRStarTop], latitudeArr1[indexRStarTop]);
                //Console.WriteLine(pTop.showx(pTop) + "," + pTop.showy(pTop)); 
                //计算diffTop
                //先判断两点经度的大小，需要确定上边那根纬度是点一确定的还是点二
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<seconde.y)
                        //R*上边的线由点二的纬度确定
                        diffTop = pTop.showy(pTop) - latitudeArr[second];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>seconde.y)
                        //R*上边的线由点一的纬度确定
                        diffTop = pTop.showy(pTop) - latitudeArr[first];
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<seconde.y)
                        //R*上边的线由点二的纬度决定
                        diffTop = pTop.showy(pTop) - latitudeArr[second];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>seconde.y)
                        //R*上边的线由点一的纬度决定
                        diffTop = pTop.showy(pTop) - latitudeArr[first];
                    }
                }
            }
            //Console.WriteLine(diffTop);

            //Console.WriteLine("下");
            ////我们先看R*下边最近的点
            listLatitudeArrClose2.Sort();
            //for (int i = 0; i < latitudeArrClose2.Count; i++)
            //{
            //    Console.WriteLine(latitudeArrClose2[i]);
            //}
            if (listLatitudeArrClose2.Count == 0)
            {
                diffBottom = 100;
            }
            else
            {
                double maxRStarBottom = (double)listLatitudeArrClose2[listLatitudeArrClose2.Count - 1];//下边就是选择维度最大的
                indexRStarBottom = UsefulFunction.search(latitudeArr1, r, maxRStarBottom);
                //Console.Write(indexRStarBottom);
                Point pBottom = new Point(longitudeArr1[indexRStarBottom], latitudeArr1[indexRStarBottom]);
                //Console.WriteLine(pBottom.showx(pBottom) + "," + pBottom.showy(pBottom)); 
                //计算diffBottom
                //先判断两点经度的大小，需要确定下边那根纬度是点一确定的还是点二
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<seconde.y)
                        //R*下边的线由点一的纬度确定
                        diffBottom = latitudeArr[first] - pBottom.showy(pBottom);
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>seconde.y)
                        //R*下边的线由点二的纬度确定
                        diffBottom = latitudeArr[second] - pBottom.showy(pBottom);
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<seconde.y)
                        //R*下边的线由点一的纬度决定
                        diffBottom = latitudeArr[first] - pBottom.showy(pBottom);
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>seconde.y)
                        //R*下边的线由点二的纬度决定
                        diffBottom = latitudeArr[second] - pBottom.showy(pBottom);
                    }
                }
            }
            //Console.WriteLine(diffBottom);     
        }

    }
}
