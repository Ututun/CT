using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
	public class Vector : Matrix
	{
		public Vector(int length) : base(1, length) { }

		public static Vector operator*(Vector vector, Matrix matrix)
		{
			if (vector.ColumnNumber != matrix.RowNumber)
				throw new IncorrectMatrixSizes();

			var result = new Vector(matrix.ColumnNumber);

			for (int i = 0; i < matrix.ColumnNumber; ++i)
				for (int j = 0; j < vector.ColumnNumber; ++j)
					result[i] += vector[j] * matrix[j, i];

			return result;
		}

		public int this[int index]
		{
			get { return this[0, index]; }
			set { this[0, index] = value; }
		}
	}
}
