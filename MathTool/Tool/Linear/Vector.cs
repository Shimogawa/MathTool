using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTool.Tool.Linear
{
	/// <summary>
	/// General Vectors
	/// </summary>
    public class Vector
    {
        private float[] data;

        public bool IsRowVector { get; private set; }

        public int Dimension { get; }

        public Vector(bool isRowVector, int dimension)
        {
            if (dimension <= 0)
                throw new ArgumentOutOfRangeException(nameof(dimension), "False dimension value.");
            IsRowVector = isRowVector;
            Dimension = dimension;
            data = new float[dimension];
        }

        public Vector(bool isRowVector, params float[] data)
        {
            IsRowVector = isRowVector;
            Dimension = data.Length;
            this.data = new float[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                this.data[i] = data[i];
            }
        }

        public void negate()
        {
            for (int i = 0; i < Dimension; i++)
            {
                data[i] = -data[i];
            }
        }

        public void invert()
        {
            IsRowVector = !IsRowVector;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.IsRowVector ^ v2.IsRowVector)
                throw new ArithmeticException("Adding vectors of different size or format.");
            if (v1.Dimension != v2.Dimension)
                throw new ArithmeticException("Adding vectors of different dimension.");
            Vector temp = new Vector(v1.IsRowVector, v1.Dimension);
            for (int i = 0; i < v1.Dimension; i++)
            {
                temp.data[i] = v1.data[i] + v2.data[i];
            }
            return temp;
        }

        public static Vector operator -(Vector v)
        {
            Vector temp = new Vector(v.IsRowVector, v.Dimension);
            for (int i = 0; i < v.Dimension; i++)
            {
                temp.data[i] = -v.data[i];
            }

            return temp;
        }
    }
}
