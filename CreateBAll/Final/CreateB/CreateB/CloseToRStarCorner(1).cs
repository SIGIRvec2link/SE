using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CreateB
{
    /*
     * R*外四个顶角的相关计算
     */
    class CloseToRStarCorner
    {
        /* 
         * 求R*外各个顶角范围的点到R*距离的集合并且将这些点的索引存储在四个数组中
         * ArrayList listDiffTopLeft：R*外左上角点到R*距离的集合            indexRStarTopLeftArr：存储R*外左上角点下标的数组
         * ArrayList listDiffTopRight：R*外左上角点到R*距离的集合;          indexRStarTopRightArr：存储R*外左上角点下标的数组
         * ArrayList listDiffBottomLeft：R*外左上角点到R*距离的集合         indexRStarBottomLeftArr：存储R*外左上角点下标的数组
         * ArrayList listDiffBottomRight：R*外左上角点到R*距离的集合        indexRStarBottomRightArrt：存储R*外左上角点下标的数组
         */
        static public void getDiffNewList(double[] longitudeArr, double[] latitudeArr, int first, int second, double[] longitudeArrClose5, double[] latitudeArrClose5,
            ref int[] indexRStarTopLeftArr, ref int[] indexRStarTopRightArr, ref int[] indexRStarBottomLeftArr, ref int[] indexRStarBottomRightArr,
            ref ArrayList listDiffTopLeft, ref ArrayList listDiffTopRight, ref ArrayList listDiffBottomLeft, ref ArrayList listDiffBottomRight)
        {
            //临时变量，用于暂存R*外四个顶角到R*距离时，四个数组indexRStarTopLeft...的下标
            int countTL = 0;
            int countTR = 0;
            int countBL = 0;
            int countBR = 0;
            Point pFirst = new Point(longitudeArr[first], latitudeArr[first]);
            Point pSecond = new Point(longitudeArr[second], latitudeArr[second]);
            //计算R*各顶角到R*的距离
            for (int i = 0; i < longitudeArrClose5.Length; i++)
            {
                if (pFirst.longitudeOneSmaller(pSecond))
                {
                    //如果第一个点的经度值小，在比较两点的维度大小
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //此时就是第一个点的经度和维度都小于第二个点，即(first.x<second.x)&&(first.y<seconde.y)
                        if ((latitudeArrClose5[i] > latitudeArr[second]) && (longitudeArrClose5[i] < longitudeArr[first]))
                        {
                            //如果点在左上角
                            listDiffTopLeft.Add((longitudeArr[first] - longitudeArrClose5[i]) + (latitudeArrClose5[i] - latitudeArr[second]));
                            indexRStarTopLeftArr[countTL] = i;
                            countTL++;
                        }
                        else if ((latitudeArrClose5[i] > latitudeArr[second]) && (longitudeArrClose5[i] > longitudeArr[second]))
                        {
                            //如果点在右上角
                            listDiffTopRight.Add((longitudeArrClose5[i] - longitudeArr[first]) + (latitudeArrClose5[i] - latitudeArr[second]));
                            indexRStarTopRightArr[countTR] = i;
                            countTR++;
                        }
                        else if ((latitudeArrClose5[i] < latitudeArr[first]) && (longitudeArrClose5[i] < longitudeArr[first]))
                        {
                            //如果在左下角
                            listDiffBottomLeft.Add((longitudeArr[first] - longitudeArrClose5[i]) + (latitudeArr[first] - latitudeArrClose5[i]));
                            indexRStarBottomLeftArr[countBL] = i;
                            countBL++;
                        }
                        else
                        {
                            //如果在右下角
                            listDiffBottomRight.Add((longitudeArrClose5[i] - longitudeArr[second]) + (latitudeArr[first] - latitudeArrClose5[i]));
                            indexRStarBottomRightArr[countBR] = i;
                            countBR++;
                        }
                    }
                    else
                    {
                        //即(first.x<second.x)&&(first.y>seconde.y)
                        if ((latitudeArrClose5[i] > latitudeArr[first]) && (longitudeArrClose5[i] < longitudeArr[first]))
                        {
                            //如果点在左上角
                            listDiffTopLeft.Add((longitudeArr[first] - longitudeArrClose5[i]) + (latitudeArrClose5[i] - latitudeArr[first]));
                            indexRStarTopLeftArr[countTL] = i;
                            countTL++;
                        }
                        else if ((latitudeArrClose5[i] > latitudeArr[first]) && (longitudeArrClose5[i] > longitudeArr[second]))
                        {
                            //如果点在右上角
                            listDiffTopRight.Add((longitudeArrClose5[i] - longitudeArr[second]) + (latitudeArrClose5[i] - latitudeArr[first]));
                            indexRStarTopRightArr[countTR] = i;
                            countTR++;
                        }
                        else if ((latitudeArrClose5[i] < latitudeArr[second]) && (longitudeArrClose5[i] < longitudeArr[first]))
                        {
                            //如果在左下角
                            listDiffBottomLeft.Add((longitudeArr[first] - longitudeArrClose5[i]) + (latitudeArr[second] - latitudeArrClose5[i]));
                            indexRStarBottomLeftArr[countBL] = i;
                            countBL++;
                        }
                        else
                        {
                            //如果在右下角
                            listDiffBottomRight.Add((longitudeArrClose5[i] - longitudeArr[second]) + (latitudeArr[second] - latitudeArrClose5[i]));
                            indexRStarBottomRightArr[countBR] = i;
                            countBR++;
                        }
                    }
                }
                else
                {
                    //first.x>seconde.x
                    if (pFirst.latitudeOneSmaller(pSecond))
                    {
                        //即(first.x>second.x)&&(first.y<seconde.y)
                        if ((latitudeArrClose5[i] > latitudeArr[second]) && (longitudeArrClose5[i] < longitudeArr[second]))
                        {
                            //如果点在左上角
                            listDiffTopLeft.Add((longitudeArr[second] - longitudeArrClose5[i]) + (latitudeArrClose5[i] - latitudeArr[second]));
                            indexRStarTopLeftArr[countTL] = i;
                            countTL++;
                        }
                        else if ((latitudeArrClose5[i] > latitudeArr[second]) && (longitudeArrClose5[i] > longitudeArr[first]))
                        {
                            //如果点在右上角
                            listDiffTopRight.Add((longitudeArrClose5[i] - longitudeArr[first]) + (latitudeArrClose5[i] - latitudeArr[second]));
                            indexRStarTopRightArr[countTR] = i;
                            countTR++;
                        }
                        else if ((latitudeArrClose5[i] < latitudeArr[first]) && (longitudeArrClose5[i] < longitudeArr[second]))
                        {
                            //如果在左下角
                            listDiffBottomLeft.Add((longitudeArr[second] - longitudeArrClose5[i]) + (latitudeArr[first] - latitudeArrClose5[i]));
                            indexRStarBottomLeftArr[countBL] = i;
                            countBL++;
                        }
                        else
                        {
                            //如果在右下角
                            listDiffBottomRight.Add((longitudeArrClose5[i] - longitudeArr[first]) + (latitudeArr[first] - latitudeArrClose5[i]));
                            indexRStarBottomRightArr[countBR] = i;
                            countBR++;
                        }
                    }
                    else
                    {
                        //即(first.x>second.x)&&(first.y>second.y)
                        if ((latitudeArrClose5[i] > latitudeArr[first]) && (longitudeArrClose5[i] < longitudeArr[second]))
                        {
                            //如果点在左上角
                            listDiffTopLeft.Add((longitudeArr[second] - longitudeArrClose5[i]) + (latitudeArrClose5[i] - latitudeArr[first]));
                            indexRStarTopLeftArr[countTL] = i;
                            countTL++;
                        }
                        else if ((latitudeArrClose5[i] > latitudeArr[first]) && (longitudeArrClose5[i] > longitudeArr[first]))
                        {
                            //如果点在右上角
                            listDiffTopRight.Add((longitudeArrClose5[i] - longitudeArr[first]) + (latitudeArrClose5[i] - latitudeArr[first]));
                            indexRStarTopRightArr[countTR] = i;
                            countTR++;
                        }
                        else if ((latitudeArrClose5[i] < latitudeArr[second]) && (longitudeArrClose5[i] < longitudeArr[second]))
                        {
                            //如果在左下角
                            listDiffBottomLeft.Add((longitudeArr[second] - longitudeArrClose5[i]) + (latitudeArr[second] - latitudeArrClose5[i]));
                            indexRStarBottomLeftArr[countBL] = i;
                            countBL++;
                        }
                        else
                        {
                            //如果在右下角
                            listDiffBottomRight.Add((longitudeArrClose5[i] - longitudeArr[first]) + (latitudeArr[second] - latitudeArrClose5[i]));
                            indexRStarBottomRightArr[countBR] = i;
                            countBR++;
                        }
                    }
                }
            }
        }

        /* 
         * 求在R*外四个顶角范围内的点的最近距离及最近点的下标
         * diffTopLeft：R*外左上角最近的距离值             indexRStarTopLeft：R*外左上角最近点的下标（通过longitudeArrClose5和latitudeArrClose5访问）
         * diffTopRight：R*外右上角最近的距离值            indexRStarTopRight：R*外右上角最近点的下标（通过longitudeArrClose5和latitudeArrClose5访问）
         * diffBottomLeft：R*外左下角最近的距离值              indexRStarBottomLeft：R*外左下角最近点的下标（通过longitudeArrClose5和latitudeArrClose5访问）
         * diffBottomRight：R*外右下角最近的距离值           indexRStarBottomRight：R*外右上角最近点的下标（通过longitudeArrClose5和latitudeArrClose5访问）
         */
        static public void getClosest(ArrayList listDiffTopLeft, ArrayList listDiffTopRight, ArrayList listDiffBottomLeft, ArrayList listDiffBottomRight,
            int[] indexRStarTopLeftArr, int[] indexRStarTopRightArr, int[] indexRStarBottomLeftArr, int[] indexRStarBottomRightArr,
            ref double diffTopLeft, ref double diffTopRight, ref double diffBottomLeft, ref double diffBottomRight,
            ref int indexRStarTopLeft, ref int indexRStarTopRight, ref int indexRStarBottomLeft, ref int indexRStarBottomRight)
        {
            //左上角最小距离及最近点下标的计算
            double[] diffTopLeftArr = (double[])listDiffTopLeft.ToArray(typeof(double));
            listDiffTopLeft.Sort();
            if (listDiffTopLeft.Count == 0)
            {
                diffTopLeft = 100;
            }
            else
            {
                diffTopLeft = (double)listDiffTopLeft[0];
            }
            //找到左上角最近点距离左上角的距离在数组diffTopLeftArr中的下标
            int temp0 = UsefulFunction.search(diffTopLeftArr, diffTopLeftArr.Length, diffTopLeft);
            if (temp0 != -1)
            {
                indexRStarTopLeft = indexRStarTopLeftArr[temp0];
            }
            //double longi = longitudeArrClose5[indexRStarTopLeft];


            //右上角最小距离及最近点下标的计算
            double[] diffTopRightArr = (double[])listDiffTopRight.ToArray(typeof(double));
            listDiffTopRight.Sort();
            if (listDiffTopRight.Count == 0)
            {
                diffTopRight = 100;
            }
            else
            {
                diffTopRight = (double)listDiffTopRight[0];
            }
            //Console.WriteLine(diffTopRight);
            //找到右上角最近点距离右上角的距离在数组diffTopRightArr中的下标
            int temp1 = UsefulFunction.search(diffTopRightArr, diffTopRightArr.Length, diffTopRight);
            if (temp1 != -1)
            {
                indexRStarTopRight = indexRStarTopRightArr[temp1];
            }
            //double longi = longitudeArrClose5[indexRStarTopRight];


            //左下角最小距离及最近点下标的计算
            double[] diffBottomLeftArr = (double[])listDiffBottomLeft.ToArray(typeof(double));
            listDiffBottomLeft.Sort();
            if (listDiffBottomLeft.Count == 0)
            {
                diffBottomLeft = 100;
            }
            else
            {
                diffBottomLeft = (double)listDiffBottomLeft[0];
            }
            //找到左下角最近点距离左下角的距离在数组diffTopRightArr中的下标
            int temp2 = UsefulFunction.search(diffBottomLeftArr, diffBottomLeftArr.Length, diffBottomLeft);
            if (temp2 != -1)
            {
                indexRStarBottomLeft = indexRStarBottomLeftArr[temp2];
            }
            //double longi = longitudeArrClose5[indexRStarBottomLeft];


            //右下角最小距离及最近点下标的计算
            double[] diffBottomRightArr = (double[])listDiffBottomRight.ToArray(typeof(double));
            listDiffBottomRight.Sort();
            if (listDiffBottomRight.Count == 0)
            {
                diffBottomRight = 100;
            }
            else
            {
                diffBottomRight = (double)listDiffBottomRight[0];
            }
            //找到左下角最近点距离左下角的距离在数组diffTopRightArr中的下标
            int temp3 = UsefulFunction.search(diffBottomRightArr, diffBottomRightArr.Length, diffBottomRight);
            if (temp3 != -1)
            {
                indexRStarBottomRight = indexRStarBottomRightArr[temp3];
            }
            //double longi = longitudeArrClose5[indexRStarBottomLeft];
        }

    }
}
