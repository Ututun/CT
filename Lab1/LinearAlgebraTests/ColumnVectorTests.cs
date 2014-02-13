using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;

namespace LinearAlgebraTests
{
	[TestClass]
	public class ColumnVectorTests
	{
		[TestMethod, ExpectedException(typeof(IncorrectMatrixSizes))]
		public void IncorrectMatrixSizesExceptionInMultiplication()
		{
            var matrix = new Matrix(1, 1);
            var vector = new ColumnVector(2);

            var result = matrix * vector;
		}

		[TestMethod]
		public void MultiplicationTest()
		{
            var vector = new ColumnVector(3);
            vector[0] = 1;
            vector[1] = 1;
            vector[2] = 1;
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

            Assert.AreEqual(C[0], -11);
            Assert.AreEqual(C[1], 13);
            Assert.AreEqual(C[2], 2);   
		}

		[TestMethod]
		public void ModulusOperatorTest()
		{
            int module = 4;
            var vector = new ColumnVector(5);
            vector[0] = 0;
            vector[1] = 1;
            vector[2] = 4;
            vector[3] = 6;
            vector[4] = 7;

            var result = vector % module;

            Assert.AreEqual(result[0], 0);
            Assert.AreEqual(result[1], 1);
            Assert.AreEqual(result[2], 0);
            Assert.AreEqual(result[3], 2);
            Assert.AreEqual(result[4], 3);
		}

		[TestMethod]
		public void GetTransposedTest()
		{
            var vector = new ColumnVector(3);
            vector[0] = 1;
            vector[1] = 2;
            vector[2] = 3;

            var result = vector.GetTransposed();

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
            Assert.AreEqual(result[2], 3);
		}
	}
}