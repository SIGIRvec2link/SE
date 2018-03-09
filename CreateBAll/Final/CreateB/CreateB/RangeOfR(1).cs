using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CreateB
{
    /*
     * 矩形范围的相关计算
     */
    class RangeOfR
    {
        /* 
         * R*加入距离最近点后的R*范围
         */
        static public void getRangeOfRStar(double shortestDistance, double diffLeft, double diffRight, double diffTop, double diffBottom,
            double diffTopLeft, double diffTopRight, double diffBottomLeft, double diffBottomRight,
            int first, int second, int indexRStarLeft, int indexRStarRight, int indexRStarTop, int indexRStarBottom,
            int indexRStarTopLeft, int indexRStarTopRight, int indexRStarBottomLeft, int indexRStarBottomRight,
            ref int rTwoIndexLongitudeFirst, ref int rTwoIndexLatitudeFirst, ref int rTwoIndexLongitudeSecond, ref int rTwoIndexLatitudeSecond,
            ref double rTwoLongitudeFirst, ref double rTwoLatitudeFirst, ref double rTwoLongitudeSecond, ref double rTwoLatitudeSecond,
            double[] longitudeArr, double[] latitudeArr, double[] longitudeArr1, double[] latitudeArr1, double[] longitudeArrClose5, double[] latitudeArrClose5)
        {
            //以下是确定调整R*后R*范围的方法，还有一种方法就是先把调整前R*内的点的经纬度存放在两个数组里，再将加入的点pJoinInRStar的经纬度添加到这两个数组中
            //这两个数组的最小最大值就构成了调整后的R*的范围

            //需要查找是R*外8个位置哪个位置的点
            /*说明：
             * 1、indexRStarLeft、indexRStarRight、indexRStarTop、indexRStarBottom是R*外上下左右侧最近点的下标，通过数组longitudeArr1和latitudeArr1来访问
             * 2、indexRStarTopLeft、indexRStarTopRight、indexRStarBottomLeft、indexRStarBottomRight是R*外四个顶角最近点的下标，通过数组longitudeArrClose5和latitudeArrClose5来访问
             * 3、first、second是R*顶角的两个点，通过数组longitudeArr和latitudeArr来访问
            */
            Point pFirst = new Point(longitudeArr[first], latitudeArr[first]);
            Point pSecond = new Point(longitudeArr[second], latitudeArr[second]);
            //如果是左边的点,只需要改变R*左侧的经度，其余的均不变
            if (shortestDistance == diffLeft)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<seconde.y)
                        rTwoIndexLongitudeFirst = indexRStarLeft;//确定下标--数组
                        rTwoLongitudeFirst = longitudeArr1[rTwoIndexLongitudeFirst];//找到对应值确定R*边界范围
                        rTwoIndexLatitudeFirst = first;
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoIndexLongitudeSecond = second;
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoIndexLatitudeSecond = second;
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = indexRStarLeft;
                        rTwoLongitudeFirst = longitudeArr1[rTwoIndexLongitudeFirst];
                        rTwoIndexLatitudeFirst = first;
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoIndexLongitudeSecond = second;
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoIndexLatitudeSecond = second;
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = indexRStarLeft;
                        rTwoLongitudeFirst = longitudeArr1[rTwoIndexLongitudeFirst];
                        rTwoIndexLatitudeFirst = second;
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoIndexLongitudeSecond = first;
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoIndexLatitudeSecond = first;
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = indexRStarLeft;//只需要改变R*左侧的经度，其余的均不变
                        rTwoLongitudeFirst = longitudeArr1[rTwoIndexLongitudeFirst];
                        rTwoIndexLatitudeFirst = second;
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoIndexLongitudeSecond = first;
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoIndexLatitudeSecond = first;
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
            }


            //如果是右边的点,只需要改变R*右侧的经度，其余的均不变
            if (shortestDistance == diffRight)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoIndexLatitudeFirst = first;
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoIndexLongitudeSecond = indexRStarRight;
                        rTwoLongitudeSecond = longitudeArr1[rTwoIndexLongitudeSecond];
                        rTwoIndexLatitudeSecond = second;
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoIndexLatitudeFirst = first;
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoIndexLongitudeSecond = indexRStarRight;
                        rTwoLongitudeSecond = longitudeArr1[rTwoIndexLongitudeSecond];
                        rTwoIndexLatitudeSecond = second;
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = second;
                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoIndexLatitudeFirst = second;
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoIndexLongitudeSecond = indexRStarRight;
                        rTwoLongitudeSecond = longitudeArr1[rTwoIndexLongitudeSecond];
                        rTwoIndexLatitudeSecond = first;
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = second;
                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoIndexLatitudeFirst = second;
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoIndexLongitudeSecond = indexRStarRight;
                        rTwoLongitudeSecond = longitudeArr1[rTwoIndexLongitudeSecond];
                        rTwoIndexLatitudeSecond = first;
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
            }


            //如果是上边的点,只需要改变R*上侧的纬度，其余的均不变
            if (shortestDistance == diffTop)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoIndexLatitudeFirst = first;
                        rTwoIndexLongitudeSecond = second;
                        rTwoIndexLatitudeSecond = indexRStarTop;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr1[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoIndexLatitudeFirst = indexRStarTop;
                        rTwoIndexLongitudeSecond = second;
                        rTwoIndexLatitudeSecond = second;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr1[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
                else
                {
                    //first.x>second.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = second;
                        rTwoIndexLatitudeFirst = indexRStarTop;
                        rTwoIndexLongitudeSecond = first;
                        rTwoIndexLatitudeSecond = first;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr1[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = second;
                        rTwoIndexLatitudeFirst = second;
                        rTwoIndexLongitudeSecond = first;
                        rTwoIndexLatitudeSecond = indexRStarTop;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr1[rTwoIndexLatitudeSecond];
                    }
                }
            }


            //如果是下边的点，只需要改变R*下侧的纬度，其余的均不变
            if (shortestDistance == diffBottom)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoIndexLatitudeFirst = indexRStarBottom;
                        rTwoIndexLongitudeSecond = second;
                        rTwoIndexLatitudeSecond = second;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr1[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoIndexLatitudeFirst = first;
                        rTwoIndexLongitudeSecond = second;
                        rTwoIndexLatitudeSecond = indexRStarBottom;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr1[rTwoIndexLatitudeSecond];
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = second;
                        rTwoIndexLatitudeFirst = second;
                        rTwoIndexLongitudeSecond = first;
                        rTwoIndexLatitudeSecond = indexRStarBottom;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr1[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>second.y)
                        //只是R*下侧的纬度发生改变，其经度还是原来的
                        rTwoIndexLongitudeFirst = second;
                        rTwoIndexLatitudeFirst = indexRStarBottom;
                        rTwoIndexLongitudeSecond = first;
                        rTwoIndexLatitudeSecond = first;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr1[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
            }

            //......还有四个顶角
            //左上角
            if (shortestDistance == diffTopLeft)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = indexRStarTopLeft;
                        rTwoIndexLatitudeFirst = first;
                        rTwoIndexLongitudeSecond = second;
                        rTwoIndexLatitudeSecond = indexRStarTopLeft;

                        rTwoLongitudeFirst = longitudeArrClose5[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArrClose5[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = indexRStarTopLeft;
                        rTwoIndexLatitudeFirst = indexRStarTopLeft;
                        rTwoIndexLongitudeSecond = second;
                        rTwoIndexLatitudeSecond = second;

                        rTwoLongitudeFirst = longitudeArrClose5[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArrClose5[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = indexRStarTopLeft;
                        rTwoIndexLatitudeFirst = indexRStarTopLeft;
                        rTwoIndexLongitudeSecond = first;
                        rTwoIndexLatitudeSecond = first;

                        rTwoLongitudeFirst = longitudeArrClose5[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArrClose5[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>second.y)
                        //只是R*下侧的纬度发生改变，其经度还是原来的
                        rTwoIndexLongitudeFirst = indexRStarTopLeft;
                        rTwoIndexLatitudeFirst = second;
                        rTwoIndexLongitudeSecond = first;
                        rTwoIndexLatitudeSecond = indexRStarTopLeft;

                        rTwoLongitudeFirst = longitudeArrClose5[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArrClose5[rTwoIndexLatitudeSecond];
                    }
                }
            }

            //右上角
            if (shortestDistance == diffTopRight)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoIndexLatitudeFirst = first;
                        rTwoIndexLongitudeSecond = indexRStarTopRight;
                        rTwoIndexLatitudeSecond = indexRStarTopRight;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArrClose5[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArrClose5[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoIndexLatitudeFirst = indexRStarTopRight;
                        rTwoIndexLongitudeSecond = indexRStarTopRight;
                        rTwoIndexLatitudeSecond = second;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArrClose5[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArrClose5[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = second;
                        rTwoIndexLatitudeFirst = indexRStarTopRight;
                        rTwoIndexLongitudeSecond = indexRStarTopRight;
                        rTwoIndexLatitudeSecond = first;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArrClose5[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArrClose5[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>second.y)
                        //只是R*下侧的纬度发生改变，其经度还是原来的
                        rTwoIndexLongitudeFirst = second;
                        rTwoIndexLatitudeFirst = second;
                        rTwoIndexLongitudeSecond = indexRStarTopRight;
                        rTwoIndexLatitudeSecond = indexRStarTopRight;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArrClose5[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArrClose5[rTwoIndexLatitudeSecond];
                    }
                }
            }

            //左下角
            if (shortestDistance == diffBottomLeft)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = indexRStarBottomLeft;
                        rTwoIndexLatitudeFirst = indexRStarBottomLeft;
                        rTwoIndexLongitudeSecond = second;
                        rTwoIndexLatitudeSecond = second;

                        rTwoLongitudeFirst = longitudeArrClose5[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArrClose5[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = indexRStarBottomLeft;
                        rTwoIndexLatitudeFirst = first;
                        rTwoIndexLongitudeSecond = second;
                        rTwoIndexLatitudeSecond = indexRStarBottomLeft;

                        rTwoLongitudeFirst = longitudeArrClose5[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArrClose5[rTwoIndexLatitudeSecond];
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = indexRStarBottomLeft;
                        rTwoIndexLatitudeFirst = second;
                        rTwoIndexLongitudeSecond = first;
                        rTwoIndexLatitudeSecond = indexRStarBottomLeft;

                        rTwoLongitudeFirst = longitudeArrClose5[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArr[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArrClose5[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>second.y)
                        //只是R*下侧的纬度发生改变，其经度还是原来的
                        rTwoIndexLongitudeFirst = indexRStarBottomLeft;
                        rTwoIndexLatitudeFirst = indexRStarBottomLeft;
                        rTwoIndexLongitudeSecond = first;
                        rTwoIndexLatitudeSecond = first;

                        rTwoLongitudeFirst = longitudeArrClose5[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArrClose5[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
            }

            //右下角
            if (shortestDistance == diffBottomRight)
            {
                //先判断两点经度的大小
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoIndexLatitudeFirst = indexRStarBottomRight;
                        rTwoIndexLongitudeSecond = indexRStarBottomRight;
                        rTwoIndexLatitudeSecond = second;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArrClose5[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArrClose5[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>second.y)
                        rTwoIndexLongitudeFirst = first;
                        rTwoIndexLatitudeFirst = first;
                        rTwoIndexLongitudeSecond = indexRStarBottomRight;
                        rTwoIndexLatitudeSecond = indexRStarBottomRight;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArrClose5[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArrClose5[rTwoIndexLatitudeSecond];
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<second.y)
                        rTwoIndexLongitudeFirst = second;
                        rTwoIndexLatitudeFirst = second;
                        rTwoIndexLongitudeSecond = indexRStarBottomRight;
                        rTwoIndexLatitudeSecond = indexRStarBottomRight;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArr[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArrClose5[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArrClose5[rTwoIndexLatitudeSecond];
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>second.y)
                        //只是R*下侧的纬度发生改变，其经度还是原来的
                        rTwoIndexLongitudeFirst = second;
                        rTwoIndexLatitudeFirst = indexRStarBottomRight;
                        rTwoIndexLongitudeSecond = indexRStarBottomRight;
                        rTwoIndexLatitudeSecond = first;

                        rTwoLongitudeFirst = longitudeArr[rTwoIndexLongitudeFirst];
                        rTwoLatitudeFirst = latitudeArrClose5[rTwoIndexLatitudeFirst];
                        rTwoLongitudeSecond = longitudeArrClose5[rTwoIndexLongitudeSecond];
                        rTwoLatitudeSecond = latitudeArr[rTwoIndexLatitudeSecond];
                    }
                }
            }
            //Console.WriteLine(rTwoLongitudeFirst + "," + rTwoLatitudeFirst);
            //Console.WriteLine(rTwoLongitudeSecond + "," + rTwoLatitudeSecond);
            //此时形成了R*第一次调整后的范围
        }

        ///* 
        // * R*加入距离最近点后的R1范围
        // */
        //static public void getRangeOfROne(double[] longitudeArr1, double[] latitudeArr1,
        //    ref double rOneAfterRejustLongitudeFirst, ref double rOneAfterRejustLatitudeFirst, ref double rOneAfterRejustLongitudeSecond, ref double rOneAfterRejustLatitudeSecond,
        //    ref double rOneLongitudeFirst, ref double rOneLatitudeFirst, ref double rOneLongitudeSecond, ref double rOneLatitudeSecond)
        //{
        //    //R*调整后的R1的范围
        //    rOneAfterRejustLongitudeFirst = UsefulFunction.minInArr(longitudeArr1);
        //    rOneAfterRejustLatitudeFirst = UsefulFunction.minInArr(latitudeArr1);
        //    rOneAfterRejustLongitudeSecond = UsefulFunction.maxInArr(longitudeArr1);
        //    rOneAfterRejustLatitudeSecond = UsefulFunction.maxInArr(latitudeArr1);

        //    if ((rOneLongitudeFirst == rOneAfterRejustLongitudeFirst) && (rOneLatitudeFirst == rOneAfterRejustLatitudeFirst)
        //        && (rOneLongitudeSecond == rOneAfterRejustLongitudeSecond) && (rOneLatitudeSecond == rOneAfterRejustLatitudeSecond))
        //    {
        //        //划分出R2后R1的范围没有变化
        //        rOneLongitudeFirst = rOneAfterRejustLongitudeFirst;
        //        rOneLatitudeFirst = rOneAfterRejustLatitudeFirst;
        //        rOneLongitudeSecond = rOneAfterRejustLongitudeSecond;
        //        rOneLatitudeSecond = rOneAfterRejustLatitudeSecond;
        //    }
        //    else
        //    {
        //        //Console.WriteLine("R1改变");first和second是原来R1的范围，first1和second1是划分出R2后R1的范围
        //        //我们假设first(1)比second(1)的经纬度都小，并且first(second)的范围肯定包含first1(second1)
        //        //一共会有7种情况
        //        //当(first.x<first1.x)&&(first.y<first1.y)&&(second.x>second1.x)&&(second.y>second1.y)
        //        if ((rOneLongitudeFirst < rOneAfterRejustLongitudeFirst) && (rOneLatitudeFirst < rOneAfterRejustLatitudeFirst)
        //            && (rOneLongitudeSecond > rOneAfterRejustLongitudeSecond) && (rOneLatitudeSecond > rOneAfterRejustLatitudeSecond))
        //        {
        //            rOneLongitudeFirst = rOneAfterRejustLongitudeFirst;
        //            rOneLatitudeFirst = rOneAfterRejustLatitudeFirst;
        //            rOneLongitudeSecond = rOneAfterRejustLongitudeSecond;
        //            rOneLatitudeSecond = rOneAfterRejustLatitudeSecond;
        //        }
        //        //当(first.x<first1.x)&&(first.y==first1.y)&&(second.x==second1.x)&&(second.y==second1.y)                
        //        else if ((rOneLongitudeFirst < rOneAfterRejustLongitudeFirst) && (rOneLatitudeFirst == rOneAfterRejustLatitudeFirst)
        //            && (rOneLongitudeSecond == rOneAfterRejustLongitudeSecond) && (rOneLatitudeSecond == rOneAfterRejustLatitudeSecond))
        //        {
        //            rOneLongitudeFirst = rOneAfterRejustLongitudeFirst;
        //            //另外三个数据均不会发生改变
        //        }
        //        //当(first.x<first1.x)&&(first.y<first1.y)&&(second.x==second1.x)&&(second.y==second1.y)                
        //        else if ((rOneLongitudeFirst < rOneAfterRejustLongitudeFirst) && (rOneLatitudeFirst < rOneAfterRejustLatitudeFirst)
        //            && (rOneLongitudeSecond == rOneAfterRejustLongitudeSecond) && (rOneLatitudeSecond == rOneAfterRejustLatitudeSecond))
        //        {
        //            rOneLongitudeFirst = rOneAfterRejustLongitudeFirst;
        //            rOneLatitudeFirst = rOneAfterRejustLatitudeFirst;
        //            //另外两个数据均不会发生改变
        //        }
        //        //当(first.x==first1.x)&&(first.y<first1.y)&&(second.x==second1.x)&&(second.y==second1.y)                
        //        else if ((rOneLongitudeFirst == rOneAfterRejustLongitudeFirst) && (rOneLatitudeFirst < rOneAfterRejustLatitudeFirst)
        //            && (rOneLongitudeSecond == rOneAfterRejustLongitudeSecond) && (rOneLatitudeSecond == rOneAfterRejustLatitudeSecond))
        //        {
        //            rOneLatitudeFirst = rOneAfterRejustLatitudeFirst;
        //            //另外三个数据均不会发生改变
        //        }
        //        //当(first.x==first1.x)&&(first.y==first1.y)&&(second.x>second1.x)&&(second.y==second1.y)                
        //        else if ((rOneLongitudeFirst == rOneAfterRejustLongitudeFirst) && (rOneLatitudeFirst == rOneAfterRejustLatitudeFirst)
        //            && (rOneLongitudeSecond > rOneAfterRejustLongitudeSecond) && (rOneLatitudeSecond == rOneAfterRejustLatitudeSecond))
        //        {
        //            rOneLongitudeSecond = rOneAfterRejustLongitudeSecond;
        //            //另外三个数据均不会发生改变
        //        }
        //        //当(first.x==first1.x)&&(first.y==first1.y)&&(second.x>second1.x)&&(second.y>second1.y)                
        //        else if ((rOneLongitudeFirst == rOneAfterRejustLongitudeFirst) && (rOneLatitudeFirst == rOneAfterRejustLatitudeFirst)
        //            && (rOneLongitudeSecond > rOneAfterRejustLongitudeSecond) && (rOneLatitudeSecond > rOneAfterRejustLatitudeSecond))
        //        {
        //            rOneLongitudeSecond = rOneAfterRejustLongitudeSecond;
        //            rOneLatitudeSecond = rOneAfterRejustLatitudeSecond;
        //            //另外两个数据均不会发生改变
        //        }
        //        //当(first.x==first1.x)&&(first.y==first1.y)&&(second.x==second1.x)&&(second.y>second1.y)                
        //        else if ((rOneLongitudeFirst == rOneAfterRejustLongitudeFirst) && (rOneLatitudeFirst == rOneAfterRejustLatitudeFirst)
        //            && (rOneLongitudeSecond == rOneAfterRejustLongitudeSecond) && (rOneLatitudeSecond > rOneAfterRejustLatitudeSecond))
        //        {
        //            rOneLatitudeSecond = rOneAfterRejustLatitudeSecond;
        //            //另外三个数据均不会发生改变
        //        }
        //        else
        //        {
        //            Console.Write("出现异常");
        //        }
        //    }
        //}

        /* 
         * R*加入距离最近点后的R1范围
         * （R1的范围可能会有8种情况，不管哪一种都不用分别讨论，因为最后其范围都是由其中包含的点所决定）
         */
        static public void getRangeOfROne(double[] longitudeArr1, double[] latitudeArr1,
            ref double rOneAfterRejustLongitudeFirst, ref double rOneAfterRejustLatitudeFirst, ref double rOneAfterRejustLongitudeSecond, ref double rOneAfterRejustLatitudeSecond,
            ref double rOneLongitudeFirst, ref double rOneLatitudeFirst, ref double rOneLongitudeSecond, ref double rOneLatitudeSecond)
        {
            //R*调整后的R1的范围
            rOneAfterRejustLongitudeFirst = UsefulFunction.minInArr(longitudeArr1);
            rOneAfterRejustLatitudeFirst = UsefulFunction.minInArr(latitudeArr1);
            rOneAfterRejustLongitudeSecond = UsefulFunction.maxInArr(longitudeArr1);
            rOneAfterRejustLatitudeSecond = UsefulFunction.maxInArr(latitudeArr1);

            rOneLongitudeFirst = rOneAfterRejustLongitudeFirst;
            rOneLatitudeFirst = rOneAfterRejustLatitudeFirst;
            rOneLongitudeSecond = rOneAfterRejustLongitudeSecond;
            rOneLatitudeSecond = rOneAfterRejustLatitudeSecond;

        }

        /* 
         * 不管最近点加入R*与否，根据成本判断决定R1和R*的最终范围
         */
        static public void getRangeOfFinalR(double semiPerimeterTwo, double semiPerimeterOne, double shortestDistance, double minCostNewSum,
            double rOneTempLongitudeFirst, double rOneTempLatitudeFirst, double rOneTempLongitudeSecond, double rOneTempLatitudeSecond,
            int involveInRStar, int first, int second, double[] longitudeArr, double[] latitudeArr, ref bool flag,
            ref double semiPerimeterRejust, ref double costRStarRejust, ref double costDepartRStarRejust, ref double minCostNewSumRejust,
            ref double rOneLongitudeFirst, ref double rOneLatitudeFirst, ref double rOneLongitudeSecond, ref double rOneLatitudeSecond,
            ref double rTwoLongitudeFirst, ref double rTwoLatitudeFirst, ref double rTwoLongitudeSecond, ref double rTwoLatitudeSecond,
            ref ArrayList listCost,ref ArrayList listCostFinal)
        {
            /*
             * 目前离R*最近的点已加入，同时我们也计算出加入R*后可能发生改变了的R*和R1的范围，现在用这个最新的范围参与成本运算
             * 如果此次的成本比原来的高，那么R*的范围为调整前的范围 
             * 如果此次的成本比原来的低，那么R*的范围为调整后的范围
             */
            //把这个距离最短的点加入R*，计算调整后的R*成本，并与原来的R*成本比较
            double costRStarOrigi = 0;//未经过调整的R*成本
            costRStarOrigi = semiPerimeterTwo * involveInRStar;
            semiPerimeterRejust = semiPerimeterTwo + shortestDistance;//R*调整后的半周长
            costRStarRejust = (involveInRStar + 1) * semiPerimeterRejust;//调整后的R*划分成本
            costDepartRStarRejust = (longitudeArr.Length - involveInRStar - 1) * semiPerimeterOne;//不包含调整后R*的R1的成本
            minCostNewSumRejust = costDepartRStarRejust + costRStarRejust;
            //Console.WriteLine(minCostNewSum);
            //Console.WriteLine(minCostNewSumRejust);

            //现在将调整前后的成本值进行比较，来决定该点是否加入R*中，从而确定矩形最终的范围
            //在最终的范围生成后，确定R1中剩余的点作为新的数据集，继续迭代实现划分算法
            if (minCostNewSumRejust <= minCostNewSum)
            {
                //如果调整后的成本比调整前小，那么该点是加入R*中的，所以调整后R*和R1的范围就是前面所求的
                //确定R*范围是加入最近点后的范围，R1的范围就是加入点到R*后R1的范围（可能有变化）
                Console.WriteLine("add a point into R* succeed! \t\t"+ minCostNewSumRejust + "\t\t" + "   " + costRStarRejust);
                listCost.Add(costRStarRejust);
                listCostFinal.Add(minCostNewSumRejust);
                //此时的数据集（R1）取自数组longitudeArr1和latitudeArr1
            }
            else
            {
                //如果调整后的成本比调整前大，那么该点不该加入R*中，所以R*和R1的范围不变
                //确定R*范围的就是来自于数据集的两点，且这两点正好位于R*的对角线端点
                Console.WriteLine("discard the point!           \t\t" + minCostNewSum + "\t\t"+ "   " + costRStarOrigi);
                listCost.Add(costRStarOrigi);
                listCostFinal.Add(minCostNewSum);
                flag = false;//R*是否加入点的标记，来判断R*的最终范围
                rTwoLongitudeFirst = longitudeArr[first];
                rTwoLatitudeFirst = latitudeArr[first];
                rTwoLongitudeSecond = longitudeArr[second];
                rTwoLatitudeSecond = latitudeArr[second];
                //确定R1的范围就是初始划分出R*时R1的范围（可能受影响）
                rOneLongitudeFirst = rOneTempLongitudeFirst;
                rOneLatitudeFirst = rOneTempLatitudeFirst;
                rOneLongitudeSecond = rOneTempLongitudeSecond;
                rOneLatitudeSecond = rOneTempLatitudeSecond;
                //此时的数据集（R1）取自数组longitudeArrTemp和latitudeArrTemp
            }

            //Console.WriteLine("(" + rTwoLongitudeFirst + "," + rTwoLatitudeFirst + "),(" + rTwoLongitudeSecond + "," + rTwoLatitudeSecond + ")");
            //Console.WriteLine("(" + rOneLongitudeFirst + "," + rOneLatitudeFirst + "),(" + rOneLongitudeSecond + "," + rOneLatitudeSecond + ")");
            //for (int i = 0; i < longitudeArr1.Length; i++)
            //{
            //    Console.WriteLine(longitudeArr1[i]);
            //}
        }


    }
}
