using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateB
{
    class Point
    {
        private double x, y;
        public Point() { }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double showx(Point p)
        {
            return p.x;
        }

        public double showy(Point p)
        {
            return p.y;
        }

        //计算位于对角线两点构成矩形的半周长
        public double SemiPeri(Point other)
        {
            double xDiff = Math.Abs(this.x - other.x);
            double yDiff = Math.Abs(this.y - other.y);
            double semiP = xDiff + yDiff;
            return semiP;
        }

        //比较两点经度的大小，如果第一个点的经度值小就返回ture
        public bool longitudeOneSmaller(Point other)
        {
            return (this.x < other.x);
        }

        //比较两点维度的大小，如果第一个点的纬度值小就返回true
        public bool latitudeOneSmaller(Point other)
        {
            return (this.y < other.y);
        }

        public double DistanceTo(Point other)
        {
            double xDiff = this.x - other.x;
            double yDiff = this.y - other.y;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }
    }
}
