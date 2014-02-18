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
		public void MultiplicationTest1()
		{
			var vector = new ColumnVector { 1, 1, 1 };
            var A = new Matrix { new RowVector { -8, 4, -7 },
                                 new RowVector { 9, -14, 18 },
                                 new RowVector { 3, -1, 0 } };

            var C = A * vector;

			CollectionAssert.AreEqual(C, new[] { -11, 13, 2 });
		}

        [TestMethod]
        public void MultiplicationTest2()
        {
            var vector = new ColumnVector { -11, 4, 1, -8 };
            var A = new Matrix { new RowVector { 1, 12, -9, 5 },
                                 new RowVector { 9, 14, 11, 0 },
                                 new RowVector { 3, -1, 0, -9 },
                                 new RowVector { 1, 5, 8, 1 }};

            var C = A * vector;

            CollectionAssert.AreEqual(C, new[] { -12, -32, 35, 9 });
        }

		[TestMethod]
		public void ModulusOperatorTest1()
		{
            int module = 4;
			var vector = new ColumnVector { 0, 1, 4, 6, 7 };

            var result = vector % module;

			CollectionAssert.AreEqual(result, new[] { 0, 1, 0, 2, 3 });
		}

        [TestMethod]
        public void ModulusOperatorTest2()
        {
            int module = 8;
            var vector = new ColumnVector { 11, 4, 16, -7, -8, 5 };

            var result = vector % module;

            CollectionAssert.AreEqual(result, new[] { 3, 4, 0, 1, 0, 5 });
        }

		[TestMethod]
		public void GetTransposedTest()
		{
			var vector = new ColumnVector { 1, 2, 3 };

            var result = vector.GetTransposed();

			CollectionAssert.AreEqual(result, new[] { 1, 2, 3 });
		}

        [TestMethod]
        public void AddTest()
        {
            var vector = new ColumnVector { 1, 6, 4, 0 };

            vector.Add(-5);

            CollectionAssert.AreEqual(vector, new[] { 1, 6, 4, 0, -5 });
        }

        [TestMethod]
        public void CopyToTest1()
        {
            var vector = new ColumnVector { -5, 8, 2, 3, 7 };
            var result = new int[5];

            vector.CopyTo(result, 0);

            CollectionAssert.AreEqual(result, new[] { -5, 8, 2, 3, 7 });
        }

        [TestMethod]
        public void CopyToTest2()
        {
            var vector = new ColumnVector { -5, 8, 2, 3, 7 };
            var result = new int[8];

            vector.CopyTo(result, 2);

            CollectionAssert.AreEqual(result, new[] { 0, 0, -5, 8, 2, 3, 7, 0 });
        }
	}
}