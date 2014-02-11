using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra
{
    public class ModularMatrix
    {
		public int RowNumber, ColumnNumber, Module;
		int[,] _matrix;

		public ModularMatrix(int rowNumber, int columnNumber)
		{
			RowNumber = rowNumber;
			ColumnNumber = columnNumber;
			_matrix = new int[RowNumber, ColumnNumber];
		}

        public static ModularMatrix operator+(ModularMatrix leftHandSide, ModularMatrix rightHandSide)
        {
            var result = new ModularMatrix(leftHandSide.RowNumber, rightHandSide.ColumnNumber);

            for (int i = 0; i < leftHandSide.RowNumber; ++i)
                for (int j = 0; j < rightHandSide.ColumnNumber; ++j)
                    result[i, j] = leftHandSide[i, j] + rightHandSide[i, j];

            return result;
        }

		public static ModularMatrix operator*(ModularMatrix leftHandSide, ModularMatrix rightHandSide)
		{
			var result = new ModularMatrix(leftHandSide.RowNumber, rightHandSide.ColumnNumber);

			for (int i = 0; i < leftHandSide.RowNumber; ++i)
				for (int j = 0; j < rightHandSide.ColumnNumber; ++j)
					for (int k = 0; k < leftHandSide.ColumnNumber; ++k)
						result[i, j] += leftHandSide[i, k] * rightHandSide[k, j];

			return result;
		}

		public int this[int rowIndex, int columnIndex]
		{
			get { return _matrix[rowIndex, columnIndex]; }
			set { _matrix[rowIndex, columnIndex] = value; }
		}
    }
}
