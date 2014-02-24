using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearAlgebra
{
	public class ColumnVector : ICollection
	{
		public int Count { get { return _list.Count; } }
		List<int> _list;

		public ColumnVector()
		{
			_list = new List<int>();
		}

		public ColumnVector(int height) : this()
		{
			for (int i = 0; i < height; ++i)
				_list.Add(0);
		}

		public ColumnVector(IEnumerable<int> vector) : this()
		{
			foreach (int item in vector)
				_list.Add(item);
		}

        public RowVector GetTransposed()
        {
            return new RowVector(_list);
        }

		public ColumnVector GetPart(int index, int count)
		{
			return new ColumnVector(_list.GetRange(index, count));
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

		public static bool operator ==(ColumnVector leftHandSide, ColumnVector rightHandSide)
		{
			if (leftHandSide.Count != rightHandSide.Count)
				throw new IncorrectMatrixSizesException();

			for (int i = 0; i < leftHandSide.Count; ++i)
				if (leftHandSide[i] != rightHandSide[i])
					return false;

			return true;
		}

		public static bool operator !=(ColumnVector leftHandSide, ColumnVector rightHandSide)
		{
			return !(leftHandSide == rightHandSide);
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
			get { return _list[index]; }
			set { _list[index] = value; }
		}

		public void Add(int item)
		{
			_list.Add(item);
		}

		#region ICollection

		public IEnumerator GetEnumerator()
		{
			return _list.GetEnumerator();
		}

		public void CopyTo(Array array, int index)
		{
			for (int i = 0; i < Count; ++i)
				array.SetValue(_list[i], index + i);
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
