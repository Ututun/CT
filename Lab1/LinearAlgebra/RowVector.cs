namespace LinearAlgebra
{
	public class RowVector
	{
		public int Length { get; private set; }
		int[] _array;

		public RowVector(int length)
		{
			Length = length;
			_array = new int[Length];
		}

		// Would you be so kind, Marina, write a method
		//public ColumnVector GetTransposed()
		//{

		//}

		public static RowVector operator *(RowVector vector, Matrix matrix)
		{
			if (vector.Length != matrix.RowNumber)
				throw new IncorrectMatrixSizes();

			var result = new RowVector(matrix.ColumnNumber);

			for (int i = 0; i < matrix.ColumnNumber; ++i)
				for (int j = 0; j < vector.Length; ++j)
					result[i] += vector[j] * matrix[j, i];

			return result;
		}

		public static RowVector operator %(RowVector vector, int module)
		{
			for (int i = 0; i < vector.Length; ++i)
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
