using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
	class ColumnVector
	{
		public int Height { get; private set; }
		int[] _array;

		public ColumnVector(int height)
		{
			Height = height;
			_array = new int[Height];
		}

		// Would you be so kind, Marina, write a method
		//public RowVector GetTransposed()
		//{

		//}

		public static ColumnVector operator *(Matrix matrix, ColumnVector vector)
		{
			if (matrix.ColumnNumber != vector.Height)
				throw new IncorrectMatrixSizes();

			var result = new ColumnVector(matrix.RowNumber);

			for (int i = 0; i < matrix.RowNumber; ++i)
				for (int j = 0; j < vector.Height; ++j)
					result[i] += matrix[i, j] * vector[j];

			return result;
		}

		public static ColumnVector operator %(ColumnVector vector, int module)
		{
			for (int i = 0; i < vector.Height; ++i)
			{
				vector[i] %= module;
				if (vector[i] < 0)
					vector[i] += module;
			}

			return vector;
		}

		public int this[int index]
		{
			get { return _array[index]; }
			set { _array[index] = value; }
		}
	}
}
