using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearAlgebra
{
	public class RowVector : ICollection
	{
		public int Count { get { return _list.Count; } }
		List<int> _list;

		public RowVector()
		{
			_list = new List<int>();
		}

		public RowVector(int length) : this()
		{
			for (int i = 0; i < length; ++i)
				_list.Add(0);
		}

		public RowVector(IEnumerable<int> vector) : this()
		{
			foreach (int item in vector)
				_list.Add(item);
		}

		public ColumnVector GetTransposed()
        {
            return new ColumnVector(_list);
        }

		public ColumnVector GetReverseTransposed()
		{
			var result = new ColumnVector(Count);

			for (int i = 0; i < Count; ++i)
				result[i] = _list[Count - 1 - i];

			return result;
		}

		public RowVector GetReverse()
		{
			var result = new RowVector(Count);

			for (int i = 0; i < Count; ++i)
				result[i] = _list[Count - 1 - i];

			return result;
		}

		public RowVector GetPart(int index, int count)
		{
			return new RowVector(_list.GetRange(index, count));
		}

		public static RowVector operator +(RowVector leftHandSide, RowVector rightHandSide)
		{
			if (leftHandSide.Count != rightHandSide.Count)
				throw new IncorrectMatrixSizesException();

			var result = new RowVector();

			for (int i = 0; i < leftHandSide.Count; ++i)
				result.Add(leftHandSide[i] + rightHandSide[i]);

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
			var result = new RowVector();

			for (int i = 0; i < vector.Count; ++i)
				result.Add(vector[i] * number);

			return result;
		}

		public static bool operator ==(RowVector leftHandSide, RowVector rightHandSide)
		{
			if (leftHandSide.Count != rightHandSide.Count)
				throw new IncorrectMatrixSizesException();

			for (int i = 0; i < leftHandSide.Count; ++i)
				if (leftHandSide[i] != rightHandSide[i])
					return false;

			return true;
		}

		public static bool operator !=(RowVector leftHandSide, RowVector rightHandSide)
		{
			return !(leftHandSide == rightHandSide);
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
