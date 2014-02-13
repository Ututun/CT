using System;
using System.Collections;

namespace LinearAlgebra
{
	public class IncorrectMatrixSizes : Exception { }

	public class Matrix
	{
		public int RowNumber { get; private set; }
		public int ColumnNumber { get; private set; }
		int[,] _matrix;

		public Matrix(int rowNumber, int columnNumber)
		{
			RowNumber = rowNumber;
			ColumnNumber = columnNumber;
			_matrix = new int[RowNumber, ColumnNumber];
		}

		// Would you be so kind, Marina, write a method
		//public Matrix GetTransposed()
		//{
			
		//}

		public static Matrix operator +(Matrix leftHandSide, Matrix rightHandSide)
		{
			if (leftHandSide.RowNumber != rightHandSide.RowNumber || leftHandSide.ColumnNumber != rightHandSide.ColumnNumber)
				throw new IncorrectMatrixSizes();

			var result = new Matrix(leftHandSide.RowNumber, rightHandSide.ColumnNumber);

			for (int i = 0; i < leftHandSide.RowNumber; ++i)
				for (int j = 0; j < rightHandSide.ColumnNumber; ++j)
					result[i, j] = leftHandSide[i, j] + rightHandSide[i, j];

			return result;
		}

		public static Matrix operator *(Matrix leftHandSide, Matrix rightHandSide)
		{
			if (leftHandSide.ColumnNumber != rightHandSide.RowNumber)
				throw new IncorrectMatrixSizes();

			var result = new Matrix(leftHandSide.RowNumber, rightHandSide.ColumnNumber);

			for (int i = 0; i < leftHandSide.RowNumber; ++i)
				for (int j = 0; j < rightHandSide.ColumnNumber; ++j)
					for (int k = 0; k < leftHandSide.ColumnNumber; ++k)
						result[i, j] += leftHandSide[i, k] * rightHandSide[k, j];

			return result;
		}

		public static Matrix operator %(Matrix matrix, int module)
		{
			for (int i = 0; i < matrix.RowNumber; ++i)
				for (int j = 0; j < matrix.ColumnNumber; ++j)
				{
					matrix[i, j] %= module;
					if (matrix[i, j] < 0)
						matrix[i, j] += module;
				}

			return matrix;
		}

		public int this[int rowIndex, int columnIndex]
		{
			get { return _matrix[rowIndex, columnIndex]; }
			set { _matrix[rowIndex, columnIndex] = value; }
		}
	}
}
