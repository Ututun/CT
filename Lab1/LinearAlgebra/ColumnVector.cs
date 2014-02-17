using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
	public class ColumnVector
	{
		public int Height { get; private set; }
		int[] _array;

		public ColumnVector(int height)
		{
			Height = height;
			_array = new int[Height];
		}

        public RowVector GetTransposed()
        {
            var result = new RowVector(Height);

            for (int i = 0; i < Height; ++i)
                result[i] = _array[i];

            return result;
        }

		public static ColumnVector operator *(Matrix matrix, ColumnVector vector)
		{
			if (matrix.ColumnNumber != vector.Height)
				throw new IncorrectMatrixSizesException();

			var result = new ColumnVector(matrix.RowNumber);

			for (int i = 0; i < matrix.RowNumber; ++i)
				for (int j = 0; j < vector.Height; ++j)
					result[i] += matrix[i, j] * vector[j];

			return result;
		}

		public static ColumnVector operator *(ColumnVector vector, int number)
		{
			var result = new ColumnVector(vector.Height);

			for (int i = 0; i < vector.Height; ++i)
				result[i] = vector[i] * number;

			return result;
		}

		public static ColumnVector operator %(ColumnVector vector, int module)
		{
			var result = new ColumnVector(vector.Height);

			for (int i = 0; i < vector.Height; ++i)
			{
				result[i] = vector[i] % module;
				if (result[i] < 0)
					result[i] += module;
			}

			return result;
		}

		public int this[int index]
		{
			get { return _array[index]; }
			set { _array[index] = value; }
		}
	}
}
