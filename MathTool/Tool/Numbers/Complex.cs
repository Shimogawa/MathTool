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
    public struct Complex
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
        public static readonly Complex i = new Complex(0, 1);

        /// <summary>
        /// Real to Complex
        /// </summary>
        /// <param name="n"></param>
        public Complex(double n)
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
        public Complex(double a, double b)
        {
            x = a;
            y = b;

            Normal = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public static Complex operator +(Complex i)
            => i;

        public static Complex operator +(Complex i1, Complex i2)
            => new Complex(i1.x + i2.x, i1.y + i2.y);

        public static Complex operator +(Complex i, double d)
            => new Complex(i.x + d, i.y);

        public static Complex operator +(double d, Complex i)
            => new Complex(i.x + d, i.y);

        public static Complex operator -(Complex i)
            => new Complex(-i.x, -i.y);

        public static Complex operator -(Complex i1, Complex i2)
            => i1 + -i2;

        public static Complex operator -(Complex i, double d)
            => i + -d;

        public static Complex operator -(double d, Complex i)
            => d + -i;

        public static Complex operator *(double d, Complex i)
            => new Complex(d * i.x, d * i.y);

        public static Complex operator *(Complex a, Complex b)
            => new Complex(a.x * b.x - a.y * b.y, a.y * b.x + a.x * b.y);

        public static Complex operator *(Complex i, double d)
            => new Complex(d * i.x, d * i.y);

        public static Complex operator /(Complex i, double d)
            => new Complex(i.x / d, i.y / d);

        public static Complex operator /(double d, Complex i)
        {
            double m = Math.Pow(i.x, 2) + Math.Pow(i.y, 2);
            return new Complex(d * i.x / m, -d * i.y / m);
        }

        public static Complex operator /(Complex i1, Complex i2)
        {
            if (i2 == (Complex)0f) throw new ArithmeticException("Divide by 0");
            double m = Math.Pow(i2.x, 2) + Math.Pow(i2.y, 2);
            return new Complex((i1.x * i2.x + i1.y * i2.y) / m, (i1.y * i2.x - i1.x * i2.y) / m);
        }

        public static bool operator ==(Complex i1, Complex i2)
        {
            if (i1.x.Equals(i2.x) && i1.y.Equals(i2.y))
                return true;
            return false;
        }

        public static bool operator !=(Complex i1, Complex i2)
        {
            if (!(i1.x.Equals(i2.x) && i1.y.Equals(i2.y)))
                return true;
            return false;
        }

        /// <summary>
        /// Use the constructor to transform a double to an Complex.
        /// </summary>
        /// <param name="d"></param>
        public static explicit operator Complex(double d)
            => new Complex(d);

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
            if (obj.GetType() != typeof(Complex))
                return false;
            Complex other = (Complex)obj;
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
