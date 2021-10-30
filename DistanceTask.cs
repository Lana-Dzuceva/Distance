using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        public static bool IsDoteOnLine(double doteX, double doteY, double x1, double y1, double x2, double y2)
        {
            return (doteX - x1) * (y2 - y1) == (doteY - y1) * (x2 - x1);
        }

        // Расстояние от точки C(x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double vectorCAx = ax - x, vectorCAy = ay - y;
            double vectorCBx = bx - x, vectorCBy = by - y;
            double vectorABx = bx - ax, vectorABy = by - ay;
            var scalarA = (bx - ax) * (x - ax) + (by - ay) * (y - ay); // parallelogram square
            var scalarB = (ax - bx) * (x - bx) + (ay - by) * (y - by); // parallelogram square
            //var scalarA = Math.Abs((bx - ax) * (x - ax) + (y - ay) * (by - y)); // parallelogram square
            //var scalarB = Math.Abs((ax - bx) * (x - bx) + (ay - by) * (y - by));
            var ab = Math.Sqrt((bx - ax) * (bx - ax) + (by - ay) * (by - ay));// length
            var ac = Math.Sqrt(vectorCAx * vectorCAx + vectorCAy * vectorCAy); // length
            var bc = Math.Sqrt(vectorCBx * vectorCBx + vectorCBy * vectorCBy); // length

            double parallellogramArea = Math.Abs((ax - x) * (by - y) - (bx - x) * (ay - y));
            var angleB = Math.Acos(scalarB / ab / bc);
            var angleA = Math.Acos(scalarA / ac / ab);
            Console.WriteLine(angleA);
            Console.WriteLine(angleB);
            Console.WriteLine(Math.PI / 2);
            if (ab == 0 || bc == 0 || ac == 0)
            {
                return Math.Min(bc, ac);
            }
            if (IsDoteOnLine(x, y, ax, ay, bx, by))
            {
                if (ac == ab + bc || bc == ab + ac)
                {
                    return Math.Min(ac, bc);
                }
                return 0;
            }
            if (angleA > Math.PI / 2 || angleB > Math.PI / 2 || ab == 0)
            {
                return Math.Min(ac, bc);
            }
            return Math.Min(Math.Min(bc, ac), Math.Max(0, parallellogramArea / ab));

        }
    }
}