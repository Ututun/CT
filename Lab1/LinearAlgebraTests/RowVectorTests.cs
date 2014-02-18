using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;

namespace LinearAlgebraTests
{
	[TestClass]
	public class RowVectorTests
	{
		[TestMethod, ExpectedException(typeof(IncorrectMatrixSizesException))]
		public void IncorrectMatrixSizesExceptionInMultiplication()
		{
			var matrix = new Matrix(1, 1);
			var vector = new RowVector(2);

			var result = vector * matrix;
		}

		[TestMethod]
		public void MultiplicationTest()
		{
			var vector = new RowVector { 1, 1, 1 };
			var A = new Matrix { new RowVector { -8, 4, -7 },
								 new RowVector { 9, -14, 18},
								 new RowVector { 3, -1, 0} };

            var C = vector * A;

			CollectionAssert.AreEqual(C, new [] { 4, -11, 11 });
		}

		[TestMethod]
		public void ModulusOperatorTest()
		{
            int module = 4;
			var vector = new RowVector { 0, 1, 4, 6, 7 };

            var result = vector % module;

			CollectionAssert.AreEqual(result, new[] { 0, 1, 0, 2, 3 });
		}

		[TestMethod]
		public void GetTransposedTest()
		{
			var vector = new RowVector { 1, 2, 3 };

            var result = vector.GetTransposed();

			CollectionAssert.AreEqual(result, new[] { 1, 2, 3 });
		}
	}
}