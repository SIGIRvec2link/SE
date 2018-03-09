using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateB
{
    /*
     * R*外点（上下左右和四个顶角）的相关计算
     */
    class CloseToRStar
    {
        /* 
         * 矩形的8个（R*的上、下、左、右、左上、右上、左下、右下）距离中选择出距离最小的 
         */
        static public void closestDiff(double diffLeft, double diffRight, double diffTop, double diffBottom,
            double diffTopLeft, double diffTopRight, double diffBottomLeft, double diffBottomRight,
            ref double[] shortestDistanceArr)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == 0)
                    shortestDistanceArr[i] = diffLeft;
                if (i == 1)
                    shortestDistanceArr[i] = diffRight;
                if (i == 2)
                    shortestDistanceArr[i] = diffTop;
                if (i == 3)
                    shortestDistanceArr[i] = diffBottom;
                if (i == 4)
                    shortestDistanceArr[i] = diffTopLeft;
                if (i == 5)
                    shortestDistanceArr[i] = diffTopRight;
                if (i == 6)
                    shortestDistanceArr[i] = diffBottomLeft;
                if (i == 7)
                    shortestDistanceArr[i] = diffBottomRight;
            }
        }

        /* 
         * 找出矩形的8个（R*的上、下、左、右、左上、右上、左下、右下）距离中选择出距离最小的点
         */
        static public Point getClosestPoint(double shortestDistance, double diffLeft, double diffRight, double diffTop, double diffBottom,
            double diffTopLeft, double diffTopRight, double diffBottomLeft, double diffBottomRight,
            int indexRStarLeft, int indexRStarRight, int indexRStarTop, int indexRStarBottom,
            int indexRStarTopLeft, int indexRStarTopRight, int indexRStarBottomLeft, int indexRStarBottomRight,
            double[] longitudeArr1, double[] latitudeArr1, double[] longitudeArrClose5, double[] latitudeArrClose5)
        {
            //找到经过调整而加入R*的点pJoinInRStar
            Point pJoinInRStar = new Point();
            if (shortestDistance == diffLeft)
            {
                //如果该点来自R*外的左侧
                pJoinInRStar = new Point(longitudeArr1[indexRStarLeft], latitudeArr1[indexRStarLeft]);
            }
            if (shortestDistance == diffRight)
            {
                //如果该点来自R*外的右侧
                pJoinInRStar = new Point(longitudeArr1[indexRStarRight], latitudeArr1[indexRStarRight]);
            }
            if (shortestDistance == diffTop)
            {
                //如果该点来自R*外的上侧
                pJoinInRStar = new Point(longitudeArr1[indexRStarTop], latitudeArr1[indexRStarTop]);
            }
            if (shortestDistance == diffBottom)
            {
                //如果该点来自R*外的下侧
                pJoinInRStar = new Point(longitudeArr1[indexRStarBottom], latitudeArr1[indexRStarBottom]);
            }
            if (shortestDistance == diffTopLeft)
            {
                //如果该点来自R*外的左上角
                pJoinInRStar = new Point(longitudeArrClose5[indexRStarTopLeft], latitudeArrClose5[indexRStarTopLeft]);
            }
            if (shortestDistance == diffTopRight)
            {
                //如果该点来自R*外的右上角
                pJoinInRStar = new Point(longitudeArrClose5[indexRStarTopRight], latitudeArrClose5[indexRStarTopRight]);
            }
            if (shortestDistance == diffBottomLeft)
            {
                //如果该点来自R*外的左下角
                pJoinInRStar = new Point(longitudeArrClose5[indexRStarBottomLeft], latitudeArrClose5[indexRStarBottomLeft]);
            }
            if (shortestDistance == diffBottomRight)
            {
                //如果该点来自R*外的右下角
                pJoinInRStar = new Point(longitudeArrClose5[indexRStarBottomRight], latitudeArrClose5[indexRStarBottomRight]);
            }
            //Console.WriteLine(pJoinInRStar.showx(pJoinInRStar));
            return pJoinInRStar;
        }

    }
}
