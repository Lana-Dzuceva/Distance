using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки C(x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double vectorCAx = ax - x, vectorCAy = ay - y;
            double vectorCBx = bx - x, vectorCBy = by - y;
            var scalar = vectorCAx * vectorCBx + vectorCAy * vectorCBy; // parallelogram square
            var ab = Math.Sqrt((bx - ax) * (bx - ax) + (by - ay) * (by - ay));// length
            var ac = Math.Sqrt(vectorCAx * vectorCAx + vectorCAy * vectorCAy); // length
            var bc = Math.Sqrt(vectorCBx * vectorCBx + vectorCBy * vectorCBy); // length
            if (ab == 0)
            {
                return Math.Min(ac, bc);
            }

            var h = scalar / ab; // parallelogram height
            return Math.Min(h, Math.Min(ac, bc));
        }
    }
}