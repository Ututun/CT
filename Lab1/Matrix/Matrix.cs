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

		// Marina's task
		public static ModularMatrix operator+(ModularMatrix leftHandSide, ModularMatrix rightHandSide)
		{

		}

		// Vova's task
		public static ModularMatrix operator*(ModularMatrix leftHandSide, ModularMatrix rightHandSide)
		{

		}

		public int this[int rowIndex, int columnIndex]
		{
			get { return _matrix[rowIndex, columnIndex]; }
			set { _matrix[rowIndex, columnIndex] = value; }
		}
    }
}
