using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;

namespace LinearAlgebraTests
{
	[TestClass]
	public class RowVectorTests
	{
		[TestMethod, ExpectedException(typeof(IncorrectMatrixSizes))]
		public void IncorrectMatrixSizesExceptionInMultiplication()
		{
			var matrix = new Matrix(1, 1);
			var vector = new RowVector(2);

			var result = vector * matrix;
		}

		[TestMethod]
		public void MultiplicationTest()
		{

		}

		[TestMethod]
		public void ModulusOperatorTest()
		{

		}

		[TestMethod]
		public void GetTransposedTest()
		{

		}
	}
}