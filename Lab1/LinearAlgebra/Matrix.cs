using System;
using System.Collections;

namespace LinearAlgebra
{
	public class IncorrectMatrixSizesException : Exception { }

	public class Matrix : ICollection
	{
		public int RowNumber { get; private set; }
		public int ColumnNumber { get; private set; }
		int[,] _matrix;

		public Matrix()
		{
			RowNumber = 0;
			ColumnNumber = 0;
			_matrix = new int[RowNumber, ColumnNumber];
		}

		public Matrix(int rowNumber, int columnNumber)
		{
			RowNumber = rowNumber;
			ColumnNumber = columnNumber;
			_matrix = new int[RowNumber, ColumnNumber];
		}

        public Matrix GetTransposed()
        {
            var result = new Matrix(ColumnNumber, RowNumber);

            for (int i = 0; i < RowNumber; ++i)
                for (int j = 0; j < ColumnNumber; ++j)
                    result[j, i] = _matrix[i, j];

            return result;
        }

		public static Matrix operator +(Matrix rightHandSide, Matrix leftHandSide)
		{
			if (rightHandSide.RowNumber != leftHandSide.RowNumber || rightHandSide.ColumnNumber != leftHandSide.ColumnNumber)
				throw new IncorrectMatrixSizesException();

			var result = new Matrix(rightHandSide.RowNumber, leftHandSide.ColumnNumber);

			for (int i = 0; i < rightHandSide.RowNumber; ++i)
				for (int j = 0; j < leftHandSide.ColumnNumber; ++j)
					result[i, j] = rightHandSide[i, j] + leftHandSide[i, j];

			return result;
		}

		public static Matrix operator *(Matrix rightHandSide, Matrix leftHandSide)
		{
			if (rightHandSide.ColumnNumber != leftHandSide.RowNumber)
				throw new IncorrectMatrixSizesException();

			var result = new Matrix(rightHandSide.RowNumber, leftHandSide.ColumnNumber);

			for (int i = 0; i < rightHandSide.RowNumber; ++i)
				for (int j = 0; j < leftHandSide.ColumnNumber; ++j)
					for (int k = 0; k < rightHandSide.ColumnNumber; ++k)
						result[i, j] += rightHandSide[i, k] * leftHandSide[k, j];

			return result;
		}

		public static Matrix operator %(Matrix matrix, int module)
		{
			var result = new Matrix(matrix.RowNumber, matrix.ColumnNumber);

			for (int i = 0; i < matrix.RowNumber; ++i)
				for (int j = 0; j < matrix.ColumnNumber; ++j)
				{
					result[i, j] = matrix[i, j] % module;
					if (result[i, j] < 0)
						result[i, j] += module;
				}

			return result;
		}

		public int this[int rowIndex, int columnIndex]
		{
			get { return _matrix[rowIndex, columnIndex]; }
			set { _matrix[rowIndex, columnIndex] = value; }
		}

		public ColumnVector this[int index]
		{
			get 
			{
				var result = new ColumnVector(RowNumber);
				for (int i = 0; i < RowNumber; ++i)
					result[i] = _matrix[i, index];
				return result;
			}
			set 
			{
				for (int i = 0; i < RowNumber; ++i)
					_matrix[i, index] = value[i];
			}
		}

		public void Add(RowVector item)
		{
			if (ColumnNumber == 0)
				ColumnNumber = item.Count;

			if (ColumnNumber != item.Count)
				throw new IncorrectMatrixSizesException();

			var newMatrix = new int[RowNumber + 1, ColumnNumber];

			MatricesCopy(_matrix, newMatrix, 0, RowNumber, 0, ColumnNumber);

			for (int i = 0; i < ColumnNumber; ++i)
				newMatrix[RowNumber, i] = item[i];

			_matrix = newMatrix;
			++RowNumber;
		}

		public void Add(ColumnVector item)
		{
			if (RowNumber == 0)
				RowNumber = item.Count;

			if (RowNumber != item.Count)
				throw new IncorrectMatrixSizesException();

			var newMatrix = new int[RowNumber, ColumnNumber + 1];

			MatricesCopy(_matrix, newMatrix, 0, RowNumber, 0, ColumnNumber);

			for (int i = 0; i < RowNumber; ++i)
				newMatrix[i, ColumnNumber] = item[i];

			_matrix = newMatrix;
			++ColumnNumber;
		}

		private void MatricesCopy(int[,] sourceMatrix, int[,] destinationMatrix, 
								  int rowBegin, int rowEnd, int columnBegin, int columnEnd)
		{
			for (int i = rowBegin; i < rowEnd; ++i)
				for (int j = columnBegin; j < columnEnd; ++j)
					destinationMatrix[i, j] = sourceMatrix[i, j];
		}

		#region ICollection

		public void CopyTo(Array array, int index)
		{
			for (int i = 0; i < RowNumber; ++i)
				for (int j = 0; j < ColumnNumber; ++j)
					array.SetValue(_matrix[i, j], index + i * ColumnNumber + j);
		}

		public int Count
		{
			get { return RowNumber * ColumnNumber; }
		}

		public bool IsSynchronized
		{
			get { throw new NotImplementedException(); }
		}

		public object SyncRoot
		{
			get { throw new NotImplementedException(); }
		}

		public IEnumerator GetEnumerator()
		{
			return _matrix.GetEnumerator();
		}

		#endregion
	}
}
