using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;

namespace LinearAlgebraTests
{
	[TestClass]
	public class Tests
	{
		[TestMethod, ExpectedException(typeof(IncorrectMatrixSizesException))]
		public void IncorrectMatrixSizesExceptionInMultiplication()
		{
			var A = new Matrix(2, 3);
			var B = new Matrix(2, 2);

			var C = A * B;
		}

        [TestMethod]
		public void MultiplicationTest1()
		{
			var A = new Matrix(2, 2);
			A[0, 0] = 1;
			A[0, 1] = 2;
			A[1, 0] = 3;
			A[1, 1] = 4;
			var B = new Matrix(2, 2);
			B[0, 0] = 1;
			B[0, 1] = 2;
			B[1, 0] = 3;
			B[1, 1] = 4;

			var C = A * B;

			Assert.AreEqual(C[0, 0], 7);
			Assert.AreEqual(C[0, 1], 10);
			Assert.AreEqual(C[1, 0], 15);
			Assert.AreEqual(C[1, 1], 22);
		}

		[TestMethod]
		public void MultiplicationTest2()
		{
			var A = new Matrix(2, 3);
			A[0, 0] = -1;
			A[0, 1] = 0;
			A[0, 2] = 1;
			A[1, 0] = 6;
			A[1, 1] = 0;
			A[1, 2] = 9;
			var B = new Matrix(3, 2);
			B[0, 0] = -6;
			B[0, 1] = 6;
			B[1, 0] = 9;
			B[1, 1] = 7;
			B[2, 0] = 3;
			B[2, 1] = -9;

			var C = A * B;

			Assert.AreEqual(C[0, 0], 9);
			Assert.AreEqual(C[0, 1], -15);
			Assert.AreEqual(C[1, 0], -9);
			Assert.AreEqual(C[1, 1], -45);
		}

        [TestMethod, ExpectedException(typeof(IncorrectMatrixSizesException))]
        public void IncorrectMatrixSizesExceptionInAddition1()
        {
            var A = new Matrix(2, 3);
            var B = new Matrix(2, 2);

            var C = A + B;
        }

        [TestMethod, ExpectedException(typeof(IncorrectMatrixSizesException))]
        public void IncorrectMatrixSizesExceptionInAddition2()
        {
            var A = new Matrix(3, 2);
            var B = new Matrix(2, 2);

            var C = A + B;
        }

        [TestMethod, ExpectedException(typeof(IncorrectMatrixSizesException))]
        public void IncorrectMatrixSizesExceptionInAddition3()
        {
            var A = new Matrix(3, 3);
            var B = new Matrix(2, 2);

            var C = A + B;
        }

        [TestMethod]
        public void AdditionTest1()
        {
            var A = new Matrix(2, 2);
            A[0, 0] = 1;
            A[0, 1] = 2;
            A[1, 0] = 3;
            A[1, 1] = 4;
            var B = new Matrix(2, 2);
            B[0, 0] = 1;
            B[0, 1] = 2;
            B[1, 0] = 3;
            B[1, 1] = 4;

            var C = A + B;

            Assert.AreEqual(C[0, 0], 2);
            Assert.AreEqual(C[0, 1], 4);
            Assert.AreEqual(C[1, 0], 6);
            Assert.AreEqual(C[1, 1], 8);
        }

        [TestMethod]
        public void ModulusOperatorTest1()
        {
            int module = 4;
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

            var C = A % module;

            Assert.AreEqual(C[0, 0], 0);
            Assert.AreEqual(C[0, 1], 0);
            Assert.AreEqual(C[0, 2], 1);
            Assert.AreEqual(C[1, 0], 1);
			Assert.AreEqual(C[1, 1], 2);
			Assert.AreEqual(C[1, 2], 2);
			Assert.AreEqual(C[2, 0], 3);
			Assert.AreEqual(C[2, 1], 3);
			Assert.AreEqual(C[2, 2], 0);
        }

		[TestMethod]
		public void GetTransposedTest()
		{
            var A = new Matrix(2, 3);
            A[0, 0] = 2;
            A[0, 1] = 3;
            A[0, 2] = 0;
            A[1, 0] = 4;
            A[1, 1] = 5;
            A[1, 2] = 6;

            var C = A.GetTransposed();

            Assert.AreEqual(C[0, 0], 2);
            Assert.AreEqual(C[0, 1], 4);
            Assert.AreEqual(C[1, 0], 3);
            Assert.AreEqual(C[1, 1], 5);
            Assert.AreEqual(C[2, 0], 0);
            Assert.AreEqual(C[2, 1], 6);
		}
	}
}