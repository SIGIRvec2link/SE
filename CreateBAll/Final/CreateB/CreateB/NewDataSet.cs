using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CreateB
{
    /*
     * 每次划分出一个新的桶就更新数据集
     */
    class NewDataSet
    {
        static public void getNewDataSet(double[] longitudeArr, double[] latitudeArr, ref ArrayList listLongitudeArr, ref ArrayList listLatitudeArr,
            ref double rOneLongitudeFirst, ref double rOneLatitudeFirst, ref double rOneLongitudeSecond, ref double rOneLatitudeSecond,
            ref double rTwoLongitudeFirst, ref double rTwoLatitudeFirst, ref double rTwoLongitudeSecond, ref double rTwoLatitudeSecond,
            ref ArrayList listCost, ref ArrayList listCostFinal)
        {
            /*
             * ======================================================================================================================================================
             */
            //存放最小成本R*的点对在数组longitudeArr和latitudeArr中的下标
            int first = 0;
            int second = 0;

            double minCostNewSum = 0;            //minCostNewSum是分桶R*的最小成本

            int involveInRStar = 0;            //计算R*中包含的点数

            double semiPerimeterOne = 0;            //R1的半周长

            double semiPerimeterTwo = 0;            //当前R*的半周长
            ChooseTwoPoint.getTwoPoint(longitudeArr, latitudeArr, ref first, ref second, ref minCostNewSum, ref involveInRStar, ref semiPerimeterOne, ref semiPerimeterTwo);
            //Console.WriteLine(first + "," + second);

            //此时R*的半周长为这两个点构成矩形的半周长
            Point pFirst = new Point(longitudeArr[first], latitudeArr[first]);
            Point pSecond = new Point(longitudeArr[second], latitudeArr[second]);
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            /* 
             * 现在对R*进行调整为R2
             * 首先计算离R*最近的在R*外的点（判断将其加入R*后成本是否会比不加入的小）
             * 注意目前R1中的点（也就是在R*之外的点，有变化）所以longitudeArr和latitudeArr会改变 
             */

            //更新后的经纬度数组(R*外的点构成的数组)
            double[] longitudeArr1 = new double[longitudeArr.Length - involveInRStar];
            double[] latitudeArr1 = new double[latitudeArr.Length - involveInRStar];

            PointInROne.getNewArray(longitudeArr, latitudeArr, first, second, ref longitudeArr1, ref latitudeArr1);
            //for (int i = 0; i < (longitudeArr.Length - involveInRStar); i++)
            //{
            //    Console.WriteLine(longitudeArr1[i]);
            //}
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            /*
             * 此时R1的范围可能会因为R*的形成有所变化，但是在R*初次形成时并不是使用R1变化后的范围参与成本计算（这个在调整R*才用到）
             * R*初次形成参与成本运算的是R1受影响变化之前的范围
             * 所以我们先用四个临时变量暂存R1的范围，之后将用于如果调整失败（最近点不能加入R*时）求解当时R1的范围
             */
            //R*形成后的R1的范围（暂存），目前是去除R*中点后剩余数据集中的点构成的矩形
            double rOneTempLongitudeFirst = UsefulFunction.minInArr(longitudeArr1);
            double rOneTempLatitudeFirst = UsefulFunction.minInArr(latitudeArr1);
            double rOneTempLongitudeSecond = UsefulFunction.maxInArr(longitudeArr1);
            double rOneTempLatitudeSecond = UsefulFunction.maxInArr(latitudeArr1);

            //初始R1的范围
            rOneLongitudeFirst = UsefulFunction.minInArr(longitudeArr);
            rOneLatitudeFirst = UsefulFunction.minInArr(latitudeArr);
            rOneLongitudeSecond = UsefulFunction.maxInArr(longitudeArr);
            rOneLatitudeSecond = UsefulFunction.maxInArr(latitudeArr);

            //Console.WriteLine("(" + rOneLongitudeFirst + "," + rOnelatitudeFirst + ")" + " (" + rOneLongitudeSecond + "," + rOneLatitudeSecond + ")");
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            //找出在R*外离R*最近的点

            //存放R*上下左右四侧的四个数组，因为R*是个矩形有四条边，找出每边距离最近的点前先找出每边外的所有点
            //需要注意在first.x,first.y,second.x,second.x,second.y范围外，还有四个顶角范围的点
            //所以要进行分别讨论

            //先计算离四边最近的点
            int r = longitudeArr.Length - involveInRStar;//存放R*外R1内的点数
            //因为存放最近距离的个数不确定，所以不能在使用数组，改用ArrayList，之后转化为数组即可
            ArrayList listLongitudeArrClose1 = new ArrayList();
            ArrayList listLongitudeArrClose2 = new ArrayList();
            ArrayList listLatitudeArrClose1 = new ArrayList();
            ArrayList listLatitudeArrClose2 = new ArrayList();

            CloseToRStarEdge.getNewList(longitudeArr, latitudeArr, first, second, involveInRStar, longitudeArr1, latitudeArr1, ref listLongitudeArrClose1, ref listLongitudeArrClose2, ref listLatitudeArrClose1, ref listLatitudeArrClose2);
            //Console.WriteLine();
            //for (int i = 0; i < listLongitudeArrClose2.Count; i++)
            //{
            //    Console.WriteLine(listLongitudeArrClose2[i]);
            //}
            //把集合转化为double型数组
            double[] longitudeArrClose1 = (double[])listLongitudeArrClose1.ToArray(typeof(double));
            double[] longitudeArrClose2 = (double[])listLongitudeArrClose2.ToArray(typeof(double));
            double[] latitudeArrClose1 = (double[])listLatitudeArrClose1.ToArray(typeof(double));
            double[] latitudeArrClose2 = (double[])listLatitudeArrClose2.ToArray(typeof(double));
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            //R*外四边距离R*的最近值
            double diffLeft = 0;            //R*外左侧最近的距离值
            double diffRight = 0;
            double diffTop = 0;
            double diffBottom = 0;

            //距离R*四边最近的点的下标，通过longitudeArr1和latitudeArr1数组访问
            int indexRStarLeft = 0;
            int indexRStarRight = 0;
            int indexRStarTop = 0;
            int indexRStarBottom = 0;

            CloseToRStarEdge.getClosest(longitudeArr, latitudeArr, longitudeArr1, latitudeArr1, first, second, r,
                listLongitudeArrClose1, listLongitudeArrClose2, listLatitudeArrClose1, listLatitudeArrClose2,
                ref diffLeft, ref diffRight, ref diffTop, ref diffBottom, ref indexRStarLeft, ref indexRStarRight, ref indexRStarTop, ref indexRStarBottom);
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            /*算完R*四边外的点到各边的距离后，接下来计算R*四个顶角到R*的距离
             * 但是这个距离并不是单纯的math.sqrt((this.x-x)*(this.x-x)+(this.y-y)*(this.y-y))
             * 仔细观察我们可以发现在包含点数确定的情况下，成本和矩形半周长成正比
             * 因此，对于顶角的点，调整时包含进去的话R*的长宽都会改变，而不是前面的那四种只会改变长和宽之一
             * 所以R*顶角范围的点到R*的距离为=到经度+到纬度 
             */
            //找出R*各个顶角范围的点
            ArrayList listLongitudeArrClose3 = new ArrayList();
            ArrayList listLongitudeArrClose4 = new ArrayList();

            CloseToRStarEdge.getLongitudeNewList(latitudeArrClose1, latitudeArrClose2, longitudeArr, latitudeArr, ref listLongitudeArrClose3, ref listLongitudeArrClose4);

            //存放R*外边上下范围外点的经度
            double[] longitudeArrClose3 = (double[])listLongitudeArrClose3.ToArray(typeof(double));
            double[] longitudeArrClose4 = (double[])listLongitudeArrClose4.ToArray(typeof(double));
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            //double[] longitudeArrClose5存放R*四个顶角范围的点的经度
            double[] longitudeArrClose5 = longitudeArr1.Except(longitudeArrClose1).Except(longitudeArrClose2).Except(longitudeArrClose3).Except(longitudeArrClose4).ToArray();
            //for (int i = 0; i < longitudeArr1.Length; i++)
            //{
            //    Console.WriteLine(longitudeArr1.Length);
            //    Console.Write(longitudeArr1[i] + " ");
            //}
            //double[] longitudeArrClose5 = new double[longitudeArr1.Length - longitudeArrClose1.Length - longitudeArrClose2.Length - longitudeArrClose3.Length - longitudeArrClose4.Length];
            //ArrayList listLongitudeClose5 = new ArrayList();
            //for (int i = 0; i < longitudeArr1.Length; i++)
            //{
            //    Console.WriteLine(longitudeArr1.Length);
            //    Console.WriteLine(longitudeArr1[i]);
            //}
            //    for (int i = 0; i < longitudeArrClose1.Length; i++)
            //    {
            //        if (longitudeArr1[i] != longitudeArrClose1[i])
            //        {
            //            listLongitudeClose5.Add(longitudeArrClose1[i]);
            //        }
            //    }
            //for (int i = 0; i < longitudeArrClose2.Length; i++)
            //{
            //    if (longitudeArr1[i] != longitudeArrClose2[i])
            //    {
            //        listLongitudeClose5.Add(longitudeArrClose2[i]);
            //    }
            //}
            //for (int i = 0; i < longitudeArrClose3.Length; i++)
            //{
            //    if (longitudeArr1[i] != longitudeArrClose3[i])
            //    {
            //        listLongitudeClose5.Add(longitudeArrClose3[i]);
            //    }
            //}
            //for (int i = 0; i < longitudeArrClose4.Length; i++)
            //{
            //    if (longitudeArr1[i] != longitudeArrClose4[i])
            //    {
            //        listLongitudeClose5.Add(longitudeArrClose4[i]);
            //    }
            //}
            //Console.WriteLine(longitudeArrClose5.Length);
            //Console.WriteLine(listLongitudeClose5.Count);


            //再根据double[] longitudeArrClose5找到存放R*四个顶角范围的点的纬度double[] latitudeArrClose5
            double[] latitudeArrClose5 = new double[longitudeArrClose5.Length];
            for (int i = 0; i < longitudeArrClose5.Length; i++)
            {
                int indexTemp = UsefulFunction.search(longitudeArr, longitudeArr.Length, longitudeArrClose5[i]);
                //if (indexTemp != -1)
                //{
                latitudeArrClose5[i] = latitudeArr[indexTemp];
                //}
            }
            //for (int i = 0; i < latitudeArrClose5.Length; i++)
            //{
            //    Console.WriteLine(latitudeArrClose5[i]);
            //}
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            //各顶角的距离R*的最短距离以及确定最短距离的顶角点的获取

            //存储R*外各个顶角范围的点到R*距离的集合
            ArrayList listDiffTopLeft = new ArrayList();
            ArrayList listDiffTopRight = new ArrayList();
            ArrayList listDiffBottomLeft = new ArrayList();
            ArrayList listDiffBottomRight = new ArrayList();

            //R*外右上角最近点的下标，通过longitudeArrClose5和latitudeArrClose5两数组来访问
            int indexRStarTopLeft = 0;
            int[] indexRStarTopLeftArr = new int[longitudeArrClose5.Length];
            int indexRStarTopRight = 0;
            int[] indexRStarTopRightArr = new int[longitudeArrClose5.Length];
            int indexRStarBottomLeft = 0;
            int[] indexRStarBottomLeftArr = new int[longitudeArrClose5.Length];
            int indexRStarBottomRight = 0;
            int[] indexRStarBottomRightArr = new int[longitudeArrClose5.Length];

            CloseToRStarCorner.getDiffNewList(longitudeArr, latitudeArr, first, second, longitudeArrClose5, latitudeArrClose5,
                ref indexRStarTopLeftArr, ref indexRStarTopRightArr, ref indexRStarBottomLeftArr, ref indexRStarBottomRightArr,
                ref listDiffTopLeft, ref listDiffTopRight, ref listDiffBottomLeft, ref listDiffBottomRight);

            //for (int i = 0; i < listDiffBottomLeft.Count; i++)
            //{
            //    Console.WriteLine(listDiffBottomLeft[i]);
            //}
            double diffTopLeft = 0;            //R*外左上角点到R*的最小距离
            double diffTopRight = 0;            //R*外右上角点到R*的最小距离
            double diffBottomLeft = 0;            //R*外左下角点到R*的最小距离
            double diffBottomRight = 0;            //R*外右下角点到R*的最小距离

            CloseToRStarCorner.getClosest(listDiffTopLeft, listDiffTopRight, listDiffBottomLeft, listDiffBottomRight,
                indexRStarTopLeftArr, indexRStarTopRightArr, indexRStarBottomLeftArr, indexRStarBottomRightArr,
                ref diffTopLeft, ref diffTopRight, ref diffBottomLeft, ref diffBottomRight,
                ref indexRStarTopLeft, ref indexRStarTopRight, ref indexRStarBottomLeft, ref indexRStarBottomRight);
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            //现在开始计算成本
            //我们矩形的8个（R*的上、下、左、右、左上、右上、左下、右下）距离中选择出距离最小的来计算成本
            //double[] shortestDistance存放这8个距离的数组
            double[] shortestDistanceArr = new double[8];
            CloseToRStar.closestDiff(diffLeft, diffRight, diffTop, diffBottom, diffTopLeft, diffTopRight, diffBottomLeft, diffBottomRight, ref shortestDistanceArr);
            //for (int i = 0; i < shortestDistanceArr.Length; i++)
            //{
            //    Console.WriteLine(shortestDistanceArr[i]);
            //}
            double shortestDistance = UsefulFunction.minInArr(shortestDistanceArr);//R*外的点到R*的最小距离
            //Console.WriteLine(shortestDistance);
            /*
             * 在计算不包含调整后R*的R1的成本之前，我们需要先判断并计算R1随着R*的调整，其范围有无改变
             * 计算并找到这个最短距离对应的点
             * 找到调整加入的这个点位于R*外8个位置中的哪个位置
             */
            //int indexOfShortestDistanceArr = search(shortestDistanceArr, shortestDistanceArr.Length, shortestDistance);

            //找到经过调整而加入R*的点pJoinInRStar
            Point pJoinInRStar = new Point();
            pJoinInRStar = CloseToRStar.getClosestPoint(shortestDistance, diffLeft, diffRight, diffTop, diffBottom,
                diffTopLeft, diffTopRight, diffBottomLeft, diffBottomRight,
                indexRStarLeft, indexRStarRight, indexRStarTop, indexRStarBottom,
                indexRStarTopLeft, indexRStarTopRight, indexRStarBottomLeft, indexRStarBottomRight,
                longitudeArr1, latitudeArr1, longitudeArrClose5, latitudeArrClose5);
            /*
             * ======================================================================================================================================================
             */

            /*
             * ======================================================================================================================================================
             */
            //找到调整加入到R*中的点后，我们需要计算经过R*调整后，R1的范围有无改变
            //我们先确定调整后的R*的范围


            int rTwoIndexLongitudeFirst = 0;//存放R*调整后，拥有最小成本R2划分的第一个点的经度下标
            int rTwoIndexLatitudeFirst = 0;//存放R*调整后，拥有最小成本R2划分的第一个点的纬度下标
            int rTwoIndexLongitudeSecond = 0;//存放R*调整后，拥有最小成本R2划分的第二个点的经度下标
            int rTwoIndexLatitudeSecond = 0;//存放R*调整后，拥有最小成本R2划分的第二个点的纬度下标

            //double rTwoLongitudeFirst = 0;//存放R*调整后，拥有最小成本R2划分的第一个点的经度
            //double rTwoLatitudeFirst = 0;//存放R*调整后，拥有最小成本R2划分的第一个点的纬度
            //double rTwoLongitudeSecond = 0;//存放R*调整后，拥有最小成本R2划分的第二个点的经度
            //double rTwoLatitudeSecond = 0;//存放R*调整后，拥有最小成本R2划分的第二个点的纬度

            RangeOfR.getRangeOfRStar(shortestDistance, diffLeft, diffRight, diffTop, diffBottom, diffTopLeft, diffTopRight, diffBottomLeft, diffBottomRight, first,
                second, indexRStarLeft, indexRStarRight, indexRStarTop, indexRStarBottom, indexRStarTopLeft, indexRStarTopRight, indexRStarBottomLeft, indexRStarBottomRight,
                ref rTwoIndexLongitudeFirst, ref rTwoIndexLatitudeFirst, ref rTwoIndexLongitudeSecond, ref rTwoIndexLatitudeSecond, ref rTwoLongitudeFirst,
                ref rTwoLatitudeFirst, ref rTwoLongitudeSecond, ref rTwoLatitudeSecond, longitudeArr, latitudeArr, longitudeArr1, latitudeArr1, longitudeArrClose5, latitudeArrClose5);
            /*
            * ======================================================================================================================================================
            */

            /*
             * ======================================================================================================================================================
             */
            //实际上R*经过第一次调整后R*1，还需要判断R1的边界有无发生改变，
            //然后再找离R*1最近的点，计算将其包含进去和不包含进去时的成本，直到包含进去成本变大就停止计算，从而确定下来最终的R2

            //再对R*1（经过第一次调整的R*）进行第二次调整，步骤同上
            /*
             * 以上不再实现
             * 
             */


            //我们先计算R1边界有无变化


            /*
             * 这里是计算哪个点加入了R*的算法，但是之前计算过，加入的点为pJoinInRStar，因此它可以直接使用这个点，不必在用下面的算法计算
             */


            ////找出R*第一次调整后R1中的点
            //double receive = findOut(longitudeArr1, latitudeArr1, rTwoLongitudeFirst, rTwoLatitudeFirst, rTwoLongitudeSecond, rTwoLatitudeSecond);
            ////Console.WriteLine(receive);
            ////但是我们并不知道该点是来自longitudeArr1还是来自latitudeArr1
            //int index=0;
            //for (int i = 0; i < longitudeArr1.Length; i++)
            //{
            //    if (receive == longitudeArr1[i])
            //        index = search(longitudeArr1, longitudeArr1.Length, receive);
            //    if (receive == latitudeArr1[i])
            //        index = search(latitudeArr1, latitudeArr1.Length, receive);
            //}
            ////所以经过调整后包含到R*中的点就是
            //Console.WriteLine(longitudeArr1[index] + "," + latitudeArr1[index]);
            //double te = pJoinInRStar.showx(pJoinInRStar);





            //提前保存在最近点未加入R*的R1中的点
            double[] longitudeArrTemp = new double[longitudeArr1.Length];
            longitudeArr1.CopyTo(longitudeArrTemp, 0);
            double[] latitudeArrTemp = new double[latitudeArr1.Length];
            latitudeArr1.CopyTo(latitudeArrTemp, 0);

            //再将此点从longitudeArr1和latitudeArr1中剔除，形成新的数组（R*调整后，在R*外的点的数组）
            int index = 0;
            index = UsefulFunction.search(longitudeArr1, longitudeArr1.Length, pJoinInRStar.showx(pJoinInRStar));
            longitudeArr1 = UsefulFunction.newArr(longitudeArr1, index);
            latitudeArr1 = UsefulFunction.newArr(latitudeArr1, index);
            //for (int i = 0; i < latitudeArr1.Length; i++)
            //{
            //    Console.WriteLine(latitudeArr1[i]);
            //}
            //R*调整后的R1的范围
            double rOneAfterRejustLongitudeFirst = 0;
            double rOneAfterRejustLatitudeFirst = 0;
            double rOneAfterRejustLongitudeSecond = 0;
            double rOneAfterRejustLatitudeSecond = 0;

            RangeOfR.getRangeOfROne(longitudeArr1, latitudeArr1, ref rOneAfterRejustLongitudeFirst, ref rOneAfterRejustLatitudeFirst, ref rOneAfterRejustLongitudeSecond,
                ref rOneAfterRejustLatitudeSecond, ref rOneLongitudeFirst, ref rOneLatitudeFirst, ref rOneLongitudeSecond, ref rOneLatitudeSecond);

            /*
             * 注意：在此桶划分中，调整R*时计算的成本，如果R1的范围因调整受到了影响，在计算成本时，参与运算的R1的半周长应当为调整后改变了的R1的半周长
             * 但是在最初形成R*之时，即使可能因为R*的形成改变了R1的范围，计算成本时参与运算的仍为R1的原始半周长
             */
            /*
            * ======================================================================================================================================================
            */

            /*
             * ======================================================================================================================================================
             */
            /*
             * 计算R1和R*的最终范围
             */
            //R*加入一个点后，R1的范围也许也需要调整，所以R1的半周长得重新计算
            semiPerimeterOne = UsefulFunction.semiPeriU(rOneLongitudeFirst, rOneLatitudeFirst, rOneLongitudeSecond, rOneLatitudeSecond);

            double semiPerimeterRejust = 0;//R*调整后的半周长
            double costRStarRejust = 0;//调整后的R*划分成本
            double costDepartRStarRejust = 0;//不包含调整后R*的R1的成本
            double minCostNewSumRejust = 0;//总成本（最小）

            bool flag = true;//决定R*是否加入点，以此判断R*的范围

            RangeOfR.getRangeOfFinalR(semiPerimeterTwo, semiPerimeterOne, shortestDistance, minCostNewSum, rOneTempLongitudeFirst, rOneTempLatitudeFirst,
                rOneTempLongitudeSecond, rOneTempLatitudeSecond, involveInRStar, first, second, longitudeArr, latitudeArr, ref flag,
                ref semiPerimeterRejust, ref costRStarRejust, ref costDepartRStarRejust, ref minCostNewSumRejust, ref rOneLongitudeFirst, ref rOneLatitudeFirst,
                ref rOneLongitudeSecond, ref rOneLatitudeSecond, ref rTwoLongitudeFirst, ref rTwoLatitudeFirst, ref rTwoLongitudeSecond, ref rTwoLatitudeSecond,
                ref listCost, ref listCostFinal);
            /*
            * ======================================================================================================================================================
            */

            /*
             * ======================================================================================================================================================
             */

            /*
             * R2的范围是(rTwoLongitudeFirst,rTwoLatitudeFirst),(rTwoLongitudeSecond,rTwoLatitudeSecond)
             * R1的范围是(rOneLongitudeFirst,rOneLatitudeFirst),(rOneLongitudeSecond,rOneLatitudeSecond);
             * R*未加入最近点时R1中点存放的数组：longitudeArrTemp，latitudeArrTemp
             * R*加入最近点时R1中点存放的数组：longitudeArr1，latitudeArr1
             * 现在我们需要将这个过程循环，将当前R1中的点（不管是R*中是否加入了点）的数组拷贝给longitudeArr和latitudeArr，以之作为新的数据集
             * 并进一步在新的数据集中（R1）划分出R3，R2因为已经划出就不再考虑而存入文档了
             * 划分出R3后桶R2一样存入文档不再考虑，再将剩余的点作为新的数据集进一步划分，直至循环结束
             */

            if (flag)
            {
                //如果是加入了点的话，那么新的数据集位于数组longitudeArr1和latitudeArr1
                for (int i = 0; i < longitudeArr1.Length; i++)
                {
                    listLongitudeArr.Add(longitudeArr1[i]);
                    listLatitudeArr.Add(latitudeArr1[i]);
                }
            }
            else
            {
                //调整R*没有加入点，新的数据集位于数组longitudeArrTemp和latitudeArrTemp
                for (int i = 0; i < longitudeArrTemp.Length; i++)
                {
                    listLongitudeArr.Add(longitudeArrTemp[i]);
                    listLatitudeArr.Add(latitudeArrTemp[i]);
                }
            }
            /*
            * ======================================================================================================================================================
            */
        }

    }
}
