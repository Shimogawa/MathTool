using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A series of numbers.
/// </summary>
namespace MathTool.Tool.Numbers
{
    /// <summary>
    /// Base class for numbers. Just for completion. 
    /// <para>Use <see langword="double"/> or <inheritdoc cref="Double">Double</inheritdoc> instead.</para>
    /// </summary>
    public class Real
    {
        /// <summary>
        /// The number.
        /// </summary>
        public double Num { get; }

        private Real() { }

        /// <summary>
        /// Put the number.
        /// </summary>
        /// <param name="n"></param>
        public Real(double n)
        {
            Num = n;
        }

        /// <summary>
        /// Returns itself.
        /// </summary>
        /// <param name="n"></param>
        /// <returns>itself.</returns>
        public static Real operator +(Real n)
            => n;

        /// <summary>
        /// Plus
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>the sum</returns>
        public static Real operator +(Real n1, Real n2)
            => new Real(n1.Num + n2.Num);

        /// <summary>
        /// Plus
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>the sum</returns>
        public static Real operator +(Real n1, double n2)
            => new Real(n1.Num + n2);

        /// <summary>
        /// Plus
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>the sum</returns>
        public static Real operator +(double n1, Real n2)
            => new Real(n1 + n2.Num);

        /// <summary>
        /// the opposite number
        /// </summary>
        /// <param name="n"></param>
        /// <returns>the opposite.</returns>
        public static Real operator -(Real n)
            => new Real(-n.Num);

        /// <summary>
        /// Minus
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>the difference</returns>
        public static Real operator -(Real n1, Real n2)
            => n1 + -n2;

        public static Real operator -(Real n1, double n2)
            => new Real(n1.Num - n2);

        public static Real operator -(double n1, Real n2)
            => new Real(n1 - n2.Num);

        public static Real operator *(Real n1, Real n2)
            => new Real(n1.Num * n2.Num);

        public static Real operator *(Real n1, double n2)
            => new Real(n1.Num * n2);

        public static Real operator *(double n1, Real n2)
            => new Real(n1 * n2.Num);

        /// <summary>
        /// Divide. Throws <see cref="ArithmeticException" />.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>The division.</returns>
        public static Real operator /(Real n1, Real n2)
        {
            if (n2.Num.Equals(0f))
                throw new ArithmeticException("Divide by 0.");
            return new Real(n1.Num / n2.Num);
        }

        public static Real operator /(Real n1, double n2)
        {
            if (n2.Equals(0f))
                throw new ArithmeticException("Divide by 0.");
            return new Real(n1.Num / n2);
        }

        public static Real operator /(double n1, Real n2)
        {
            if (n2.Num.Equals(0f))
                throw new ArithmeticException("Divide by 0.");
            return new Real(n1 / n2.Num);
        }

        public static bool operator ==(Real n1, Real n2)
            => n1.Num.Equals(n2.Num);

        public static bool operator !=(Real n1, Real n2)
            => !n1.Num.Equals(n2.Num);

        public static implicit operator double(Real n)
            => n.Num;

        public static implicit operator Real(double d)
            => new Real(d);

        public static implicit operator Real(int d)
            => new Real(d);

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(Real) || obj.GetType() != typeof(double))
                return false;
            Real other = (Real)obj;
            if (Num == other.Num)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (int)Num * 10000000;
        }

        public override string ToString()
        {
            return Num.ToString();
        }
    }
}
