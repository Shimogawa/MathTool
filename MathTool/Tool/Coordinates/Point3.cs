using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// Tools used in math topics.
/// </summary>
namespace MathTool.Tool.Coordinates
{
    /**
     * <summary>Describes a point in 3D space.</summary>
     */
    public struct Point3
    {
        /**
         * <summary>The x-axis position</summary>
         */
        public float x { get; }

        /**
         * <summary>The y-axis position</summary>
         */
        public float y { get; }

        /**
         * <summary>The z-axis position</summary>
         */
        public float z { get; }

        /**
         * <summary>
         * Constructor to create a point in 3D space using 3 numbers.
         * </summary>
         * <param name="x">The x position</param>
         * <param name="y">The y position</param>
         * <param name="z">The z position</param>
         * 
         * <returns>The point</returns>
         */
        public Point3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /**
         * <summary>
         * Constructor to create a point in 3D space using an array of length 3.
         * </summary>
         * <param name="li">The array</param>
         * 
         * <returns>The point</returns>
         */
        public Point3(float[] li)
        {
            if (li == null)
                throw new ArgumentException("Null array");
            if (li.Length != 3)
                throw new ArgumentException("Wrong array length.");
            x = li[0];
            y = li[1];
            z = li[2];
        }

        /// <summary>
        /// Constructor to create a point in 3D space using a 3D point.
        /// </summary>
        /// <param name="v"></param>
        public Point3(Vector3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }

        /// <summary>
        /// Changes a point to a vector.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator Vector3(Point3 p)
            => new Vector3(p);

        /// <summary>
        /// Casts a cylindrical point to a rectlineal point.
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator Cylindrical3(Point3 p)
            => new Cylindrical3(p);

        /**
         * <summary>Calculates the distance between two points.</summary>
         * <param name="p">The other point</param>
         * 
         * <returns>The distance.</returns>
         */
        public float DistanceFrom(Point3 p)
        {
            if (Equals(p))
                return 0f;
            return (float)Math.Sqrt(Math.Pow(x - p.x, 2) + Math.Pow(y - p.y, 2) + Math.Pow(z - p.z, 2));
        }

        /**
         * <summary>Calculates the distance between two points.
         * <para>Please use the non-static method for calculating distance.</para></summary>
         * <param name="p1">The first point</param>
         * <param name="p2">The second point</param>
         * 
         * <returns>The distance.</returns>
         */
        public static float DistanceFrom(Point3 p1, Point3 p2)
        {
            return p1.DistanceFrom(p2);
        }

        /**
         * <summary>Determine if this and another point are on the same position.</summary>
         * <param name="o">The object to determine.</param>
         * 
         * <returns>If they are on the same position.</returns>
         */
        public override bool Equals(object o)
        {
            if (o == null)
                return false;
            if (o.GetType() != typeof(Point3) || o.GetType() != typeof(Cylindrical3))
                return false;

            Point3 other = (Point3)o;

            if ((x == other.x) && (y == other.y) && (z == other.z))
                return true;

            return false;
        }

        /// <summary>
        /// Get hash code.
        /// </summary>
        /// <returns>hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// String representation of a point.
        /// </summary>
        /// <returns>The string representing a point.</returns>
        public override string ToString()
        {
            return "Rect(" + x + ", " + y + ", " + z + ")";
        }
    }
}