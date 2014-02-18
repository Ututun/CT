using System;
using System.Collections;

namespace LinearAlgebra
{
	public class RowVector : ICollection
	{
		public int Count { get; private set; }
		int[] _array;

		public RowVector()
		{
			Count = 0;
			_array = new int[Count];
		}

		public RowVector(int length)
		{
			Count = length;
			_array = new int[Count];
		}

		public ColumnVector GetTransposed()
        {
            var result = new ColumnVector(Count);

            for (int i = 0; i < Count; ++i)
                result[i] = _array[i];

            return result;
        }

		public static RowVector operator +(RowVector rightHandSide, RowVector leftHandSide)
		{
			if (rightHandSide.Count != leftHandSide.Count)
				throw new IncorrectMatrixSizesException();

			var result = new RowVector(rightHandSide.Count);

			for (int i = 0; i < rightHandSide.Count; ++i)
				result[i] = rightHandSide[i] + leftHandSide[i];

			return result;
		}

        public static RowVector operator *(RowVector vector, Matrix matrix)
		{
			if (vector.Count != matrix.RowNumber)
				throw new IncorrectMatrixSizesException();

			var result = new RowVector(matrix.ColumnNumber);

			for (int i = 0; i < matrix.ColumnNumber; ++i)
				for (int j = 0; j < vector.Count; ++j)
					result[i] += vector[j] * matrix[j, i];

			return result;
		}

		public static RowVector operator *(RowVector vector, int number)
		{
			var result = new RowVector(vector.Count);

			for (int i = 0; i < vector.Count; ++i)
				result[i] = vector[i] * number;

			return result;
		}

		public static bool operator ==(RowVector rightHandSide, RowVector leftHandSide)
		{
			if (rightHandSide.Count != leftHandSide.Count)
				throw new IncorrectMatrixSizesException();

			for (int i = 0; i < rightHandSide.Count; ++i)
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
			var result = new RowVector(vector.Count);

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
