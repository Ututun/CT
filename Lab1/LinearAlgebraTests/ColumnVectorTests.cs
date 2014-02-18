using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;

namespace LinearAlgebraTests
{
	[TestClass]
	public class ColumnVectorTests
	{
		[TestMethod, ExpectedException(typeof(IncorrectMatrixSizesException))]
		public void IncorrectMatrixSizesExceptionInMultiplication()
		{
            var matrix = new Matrix(1, 1);
            var vector = new ColumnVector(2);

            var result = matrix * vector;
		}

		[TestMethod]
		public void MultiplicationTest()
		{
			var vector = new ColumnVector { 1, 1, 1 };
            var A = new Matrix(3, 3);
            A[0, 0] = -8;
            A[0, 1] = 4;
            A[0, 2] = -7;
            A[1, 0] = 9;
            A[1, 1] = -14;
            A[1, 2] = 18;
            A[2, 0] = 3;
            A[2, 1] = -1;
            A[2, 2] = 0;

            var C = A * vector;

			CollectionAssert.AreEqual(C, new[] { -11, 13, 2 });
		}

		[TestMethod]
		public void ModulusOperatorTest()
		{
            int module = 4;
			var vector = new ColumnVector { 0, 1, 4, 6, 7 };

            var result = vector % module;

			CollectionAssert.AreEqual(result, new[] { 0, 1, 0, 2, 3 });
		}

		[TestMethod]
		public void GetTransposedTest()
		{
			var vector = new ColumnVector { 1, 2, 3 };

            var result = vector.GetTransposed();

			CollectionAssert.AreEqual(result, new[] { 1, 2, 3 });
		}
	}
}