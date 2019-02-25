using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MathTool.Tool.Coordinates
{
    public struct Cylindrical3
    {
        public float r { get; }

        public float theta { get; }

        public float z { get; }

        public Cylindrical3(float r, float theta, float z)
        {
            this.r = r;
            this.theta = theta;
            this.z = z;
        }

        public Cylindrical3(Point3 p)
        {
            z = p.z;
            r = (float)Math.Sqrt(Math.Pow(p.x, 2) + Math.Pow(p.y, 2));
            theta = (float)Math.Atan2(p.y, p.x);
        }

        public static explicit operator Point3(Cylindrical3 c)
        {
	        return ToEuclidean(c);
        }

        public static Point3 ToEuclidean(Cylindrical3 c)
        {
	        return new Point3((float)(c.r * Math.Cos(c.theta)), (float)(c.r * Math.Sin(c.theta)), c.z);
		}

        public override bool Equals(object o)
        {
            if (o == null)
                return false;
            if (o.GetType() != typeof(Point3) || o.GetType() != typeof(Cylindrical3))
                return false;

            Cylindrical3 other = (Cylindrical3)o;

            if ((r == other.r) && (theta == other.theta) && (z == other.z))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Cyl({0}, {1}, {2})", r, theta, z);
        }
    }
}