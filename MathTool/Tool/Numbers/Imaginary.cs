using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTool.Tool.Numbers
{
    /// <summary>
    /// The imaginary number.
    /// </summary>
    public struct Imaginary
    {
        /// <summary>
        /// The real part
        /// </summary>
        public double x { get; }

        /// <summary>
        /// The imaginary part
        /// </summary>
        public double y { get; }

        /// <summary>
        /// The normal. The length.
        /// </summary>
        public double Normal { get; }

        /// <summary>
        /// i
        /// </summary>
        public static readonly Imaginary i = new Imaginary(0, 1);

        /// <summary>
        /// Real to Imaginary
        /// </summary>
        /// <param name="n"></param>
        public Imaginary(double n)
        {
            x = n;
            y = 0;

            Normal = x;
        }

        /// <summary>
        /// x+yi.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Imaginary(double a, double b)
        {
            x = a;
            y = b;

            Normal = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public static Imaginary operator +(Imaginary i)
            => i;

        public static Imaginary operator +(Imaginary i1, Imaginary i2)
            => new Imaginary(i1.x + i2.x, i1.y + i2.y);

        public static Imaginary operator +(Imaginary i, double d)
            => new Imaginary(i.x + d, i.y);

        public static Imaginary operator +(double d, Imaginary i)
            => new Imaginary(i.x + d, i.y);

        public static Imaginary operator -(Imaginary i)
            => new Imaginary(-i.x, -i.y);

        public static Imaginary operator -(Imaginary i1, Imaginary i2)
            => i1 + -i2;

        public static Imaginary operator -(Imaginary i, double d)
            => i + -d;

        public static Imaginary operator -(double d, Imaginary i)
            => d + -i;

        public static Imaginary operator *(double d, Imaginary i)
            => new Imaginary(d * i.x, d * i.y);

        public static Imaginary operator *(Imaginary a, Imaginary b)
            => new Imaginary(a.x * b.x - a.y * b.y, a.y * b.x + a.x * b.y);

        public static Imaginary operator *(Imaginary i, double d)
            => new Imaginary(d * i.x, d * i.y);

        public static Imaginary operator /(Imaginary i, double d)
            => new Imaginary(i.x / d, i.y / d);

        public static Imaginary operator /(double d, Imaginary i)
        {
            double m = Math.Pow(i.x, 2) + Math.Pow(i.y, 2);
            return new Imaginary(d * i.x / m, -d * i.y / m);
        }

        public static Imaginary operator /(Imaginary i1, Imaginary i2)
        {
            if (i2 == (Imaginary)0f) throw new ArithmeticException("Divide by 0");
            double m = Math.Pow(i2.x, 2) + Math.Pow(i2.y, 2);
            return new Imaginary((i1.x * i2.x + i1.y * i2.y) / m, (i1.y * i2.x - i1.x * i2.y) / m);
        }

        public static bool operator ==(Imaginary i1, Imaginary i2)
        {
            if (i1.x.Equals(i2.x) && i1.y.Equals(i2.y))
                return true;
            return false;
        }

        public static bool operator !=(Imaginary i1, Imaginary i2)
        {
            if (!(i1.x.Equals(i2.x) && i1.y.Equals(i2.y)))
                return true;
            return false;
        }

        /// <summary>
        /// Use the constructor to transform a double to an Imaginary.
        /// </summary>
        /// <param name="d"></param>
        public static explicit operator Imaginary(double d)
            => new Imaginary(d);

        /// <summary>
        /// The length.
        /// </summary>
        /// <returns>the length.</returns>
        public double Length()
            => Normal;

        /// <summary>
        /// Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>if they are equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(Imaginary))
                return false;
            Imaginary other = (Imaginary)obj;
            if ((x == other.x) && (y == other.y))
                return true;
            return false;
        }

        /// <summary>
        /// GetHashCode()
        /// </summary>
        /// <returns>hashcode</returns>
        public override int GetHashCode()
            => (int)(x * 0xffff + y * 0xffff);

        public override string ToString()
            => x.ToString() + "+" + y.ToString() + "i";

    }
}
