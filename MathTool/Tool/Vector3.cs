using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathTool.Tool.Coordinates;

namespace MathTool.Tool
{
    public struct Vector3
    {
        /// <summary>
        /// The zero vector.
        /// </summary>
        public static readonly Vector3 ZERO = new Vector3(0f, 0f, 0f);

        /// <summary>
        /// The i vector.
        /// </summary>
        public static readonly Vector3 i = new Vector3(1f, 0f, 0f);

        /// <summary>
        /// The j vector.
        /// </summary>
        public static readonly Vector3 j = new Vector3(0f, 1f, 0f);

        /// <summary>
        /// The k vector.
        /// </summary>
        public static readonly Vector3 k = new Vector3(0f, 0f, 1f);

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
         * <summary>The endpoint of the vector</summary>
         */
        public Point3 endPoint;

        /// <summary>
        /// The length of the vector
        /// </summary>
        public float Length { get; }

        /**
         * <summary>Create a Vector in 3D space using 3 numbers.</summary>
         * <param name="x">The x position</param>
         * <param name="y">The y position</param>
         * <param name="z">The z position</param>
         * 
         * <returns>The vector.</returns>
         */
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            endPoint = new Point3(x, y, z);
            Length = (float)Math.Sqrt(Math.Pow(x, 2f) + Math.Pow(y, 2f) + Math.Pow(z, 2f));
        }

        /**
         * <summary>
         * Constructor to create a vector in 3D space using an array of length 3.
         * </summary>
         * <param name="li">The array</param>
         * 
         * <returns>The vector.</returns>
         */
        public Vector3(float[] li)
        {
            if (li == null)
                throw new ArgumentException("Null array");
            if (li.Length != 3)
                throw new ArgumentException("Wrong array length.");
            x = li[0];
            y = li[1];
            z = li[2];

            endPoint = new Point3(x, y, z);
            Length = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        /// <summary>
        /// Constructor to create a vector in 3D space using a 3D point.
        /// </summary>
        /// <param name="p">The point.</param>
        public Vector3(Point3 p)
        {
            x = p.x;
            y = p.y;
            z = p.z;

            endPoint = p;
            Length = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        /// <summary>
        /// Returns itself.
        /// </summary>
        /// <param name="v">A vector</param>
        /// <returns>Itself.</returns>
        public static Vector3 operator +(Vector3 v)
            => v;

        /// <summary>
        /// The sum of two vectors.
        /// </summary>
        /// <param name="v1">v1</param>
        /// <param name="v2">v2</param>
        /// <returns>The sum.</returns>
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
            => new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);

        /// <summary>
        /// The opposite vector towards the origin.
        /// </summary>
        /// <param name="vector">A vector</param>
        /// <returns>The opposite vector towards the origin.</returns>
        public static Vector3 operator -(Vector3 vector)
            => new Vector3(-vector.x, -vector.y, -vector.z);

        /// <summary>
        /// The difference between two vectors.
        /// </summary>
        /// <param name="v1">v1</param>
        /// <param name="v2">v2</param>
        /// <returns>the difference.</returns>
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
            => new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);

        /// <summary>
        /// Scalor multiplication.
        /// </summary>
        /// <param name="f">The scalor</param>
        /// <param name="v">The vector.</param>
        /// <returns>The new vector.</returns>
        public static Vector3 operator *(float f, Vector3 v)
            => new Vector3(f * v.x, f * v.y, f * v.z);

        /// <summary>
        /// Determine if the two vector point towards the same point.
        /// </summary>
        /// <param name="v1">v1</param>
        /// <param name="v2">v2</param>
        /// <returns>if they are equal</returns>
        public static bool operator ==(Vector3 v1, Vector3 v2)
            => v1.Equals(v2);

        /// <summary>
        /// Determine if the two vector do not point towards the same point.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>if they are not equal.</returns>
        public static bool operator !=(Vector3 v1, Vector3 v2)
            => !v1.Equals(v2);

        /// <summary>
        /// Explicitly changes an endpoint of a vector to a point.
        /// </summary>
        /// <param name="v"></param>
        public static explicit operator Point3(Vector3 v)
            => new Point3(v);

        /// <summary>
        /// The dot product of two vectors.
        /// </summary>
        /// <param name="vector">The other vector.</param>
        /// <returns>The dot product.</returns>
        public float Dot(Vector3 vector)
            => x * vector.x + y * vector.y + z * vector.z;

        /// <summary>
        /// <para>The dot product of two vectors.</para>
        /// <para>Use the non-static method <see cref="Dot(Vector3)"/> instead.</para>
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>The dot product.</returns>
        public static float Dot(Vector3 v1, Vector3 v2)
            => v1.Dot(v2);

        /// <summary>
        /// The cross product of two vectors.
        /// </summary>
        /// <param name="v">The other vector.</param>
        /// <returns>The cross product.</returns>
        public Vector3 Cross(Vector3 v)
            => (y * v.z - z * v.y) * i - (x * v.z - z * v.x) * j + (x * v.y - y * v.x) * k;

        /// <summary>
        /// <para>The cross product of two vectors.</para>
        /// <para>Use the non-static method <see cref="Cross(Vector3)"/> instead.</para>
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>The cross product.</returns>
        public static Vector3 Cross(Vector3 v1, Vector3 v2)
            => v1.Cross(v2);

        /// <summary>
        /// Abandoned. Directly use Length field.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>the length.</returns>
        public static float GetLength(Vector3 v)
            => v.Length;

        /// <summary>
        /// Calculates the angle between two vectors.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>The angle between two vectors.</returns>
        public static float AngleBetween(Vector3 v1, Vector3 v2)
        {
            float dot = v1.Dot(v2);
            float la = v1.Length;
            float lb = v2.Length;

            return (float)Math.Acos(dot / (la * lb));
        }

        /// <summary>
        /// String representation of a vector.
        /// </summary>
        /// <returns>The string representing a vector.</returns>
        public override string ToString()
        {
            return "<" + x.ToString() + ", " + y.ToString() + ", " + z.ToString() + ">";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns>If they are equal.</returns>
        public override bool Equals(object o)
        {
            if (o == null)
                return false;
            if (o.GetType() != typeof(Vector3))
                return false;

            Vector3 other = (Vector3)o;

            if ((x == other.x) && (y == other.y) && (z == other.z))
                return true;

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
