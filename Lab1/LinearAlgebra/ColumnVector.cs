using System;
using System.Collections;

namespace LinearAlgebra
{
	public class ColumnVector : ICollection
	{
		public int Count { get; private set; }
		int[] _array;

		public ColumnVector()
		{
			Count = 0;
			_array = new int[Count];
		}

		public ColumnVector(int height)
		{
			Count = height;
			_array = new int[Count];
		}

        public RowVector GetTransposed()
        {
            var result = new RowVector(Count);

            for (int i = 0; i < Count; ++i)
                result[i] = _array[i];

            return result;
        }

		public static ColumnVector operator *(Matrix matrix, ColumnVector vector)
		{
			if (matrix.ColumnNumber != vector.Count)
				throw new IncorrectMatrixSizesException();

			var result = new ColumnVector(matrix.RowNumber);

			for (int i = 0; i < matrix.RowNumber; ++i)
				for (int j = 0; j < vector.Count; ++j)
					result[i] += matrix[i, j] * vector[j];

			return result;
		}

		public static ColumnVector operator *(ColumnVector vector, int number)
		{
			var result = new ColumnVector(vector.Count);

			for (int i = 0; i < vector.Count; ++i)
				result[i] = vector[i] * number;

			return result;
		}

		public static bool operator ==(ColumnVector rightHandSide, ColumnVector leftHandSide)
		{
			if (rightHandSide.Count != leftHandSide.Count)
				throw new IncorrectMatrixSizesException();

			for (int i = 0; i < rightHandSide.Count; ++i)
				if (rightHandSide[i] != leftHandSide[i])
					return false;

			return true;
		}

		public static bool operator !=(ColumnVector rightHandSide, ColumnVector leftHandSide)
		{
			return !(rightHandSide == leftHandSide);
		}

		public static ColumnVector operator %(ColumnVector vector, int module)
		{
			var result = new ColumnVector(vector.Count);

			for (int i = 0; i < vector.Count; ++i)
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

		public void Add(int item)
		{
			var newArray = new int[Count + 1];
			_array.CopyTo(newArray, 0);
			_array = newArray;
			newArray[Count++] = item;
		}

		#region ICollection

		public IEnumerator GetEnumerator()
		{
			return _array.GetEnumerator();
		}

		public void CopyTo(Array array, int index)
		{
			for (int i = 0; i < Count; ++i)
				array.SetValue(_array[i], index + i);
		}

		public bool IsSynchronized
		{
			get { throw new System.NotImplementedException(); }
		}

		public object SyncRoot
		{
			get { throw new System.NotImplementedException(); }
		}

		#endregion
	}
}
