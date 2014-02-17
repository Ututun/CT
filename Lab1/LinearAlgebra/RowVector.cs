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

        public ColumnVector GetTransposed()
        {
            var result = new ColumnVector(Length);

            for (int i = 0; i < Length; ++i)
                result[i] = _array[i];

            return result;
        }

		public static RowVector operator +(RowVector rightHandSide, RowVector leftHandSide)
		{
			if (rightHandSide.Length != leftHandSide.Length)
				throw new IncorrectMatrixSizesException();

			var result = new RowVector(rightHandSide.Length);

			for (int i = 0; i < rightHandSide.Length; ++i)
				result[i] = rightHandSide[i] + leftHandSide[i];

			return result;
		}

        public static RowVector operator *(RowVector vector, Matrix matrix)
		{
			if (vector.Length != matrix.RowNumber)
				throw new IncorrectMatrixSizesException();

			var result = new RowVector(matrix.ColumnNumber);

			for (int i = 0; i < matrix.ColumnNumber; ++i)
				for (int j = 0; j < vector.Length; ++j)
					result[i] += vector[j] * matrix[j, i];

			return result;
		}

		public static RowVector operator *(RowVector vector, int number)
		{
			var result = new RowVector(vector.Length);

			for (int i = 0; i < vector.Length; ++i)
				result[i] = vector[i] * number;

			return result;
		}

		public static bool operator ==(RowVector rightHandSide, RowVector leftHandSide)
		{
			if (rightHandSide.Length != leftHandSide.Length)
				throw new IncorrectMatrixSizesException();

			for (int i = 0; i < rightHandSide.Length; ++i)
				if (rightHandSide[i] != leftHandSide[i])
					return false;

			return true;
		}

		public static bool operator !=(RowVector rightHandSide, RowVector leftHandSide)
		{
			return !(rightHandSide == leftHandSide);
		}

		public static RowVector operator %(RowVector vector, int module)
		{
			var result = new RowVector(vector.Length);

			for (int i = 0; i < vector.Length; ++i)
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
