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
		public void MultiplicationTest1()
		{
			var vector = new RowVector { 1, 1, 1 };
			var A = new Matrix { new RowVector { -8, 4, -7 },
								 new RowVector { 9, -14, 18},
								 new RowVector { 3, -1, 0} };

            var C = vector * A;

			CollectionAssert.AreEqual(C, new [] { 4, -11, 11 });
		}

        [TestMethod]
        public void MultiplicationTest2()
        {
            var vector = new RowVector { -1, 0, 5 };
            var A = new Matrix { new RowVector { 4, -5, 3 },
								 new RowVector { -5, 12, -8},
								 new RowVector { -3, 1, 0} };

            var C = vector * A;

            CollectionAssert.AreEqual(C, new[] { -19, 10, -3 });
        }

        [TestMethod]
        public void MultiplicationTest3()
        {
            var vector = new RowVector { 5, -3, 12, 2 };
            var A = new Matrix { new RowVector { 1, -5, 3, 9},
								 new RowVector { -7, 13, 2, -1},
								 new RowVector { 0, 5, -2, 4},
                                 new RowVector { 4, 0, -7, 11}};

            var C = vector * A;

            CollectionAssert.AreEqual(C, new[] { 34, -4, -29, 118 });
        }

		[TestMethod]
		public void ModulusOperatorTest1()
		{
            int module = 4;
			var vector = new RowVector { 0, 1, 4, 6, 7 };

            var result = vector % module;

			CollectionAssert.AreEqual(result, new[] { 0, 1, 0, 2, 3 });
		}

        [TestMethod]
        public void ModulusOperatorTest2()
        {
            int module = 7;
            var vector = new RowVector { 24, 16, 0, -6, 19, 8, -16 };

            var result = vector % module;

            CollectionAssert.AreEqual(result, new[] { 3, 2, 0, 1, 5, 1, 5 });
        }

		[TestMethod]
		public void GetTransposedTest()
		{
			var vector = new RowVector { 1, 2, 3 };

            var result = vector.GetTransposed();

			CollectionAssert.AreEqual(result, new[] { 1, 2, 3 });
		}

        [TestMethod]
        public void AddTest()
        {
            var vector = new RowVector { 1, 6, 4 };

            vector.Add(10);

            CollectionAssert.AreEqual(vector, new[] { 1, 6, 4, 10 });
        }

        [TestMethod]
        public void CopyToTest1()
        {
            var vector = new RowVector { -5, 8, 2, 3, 7 };
            var result = new int[5];

            vector.CopyTo(result, 0);

            CollectionAssert.AreEqual(result, new[] { -5, 8, 2, 3, 7 });           
        }

        [TestMethod]
        public void CopyToTest2()
        {
            var vector = new RowVector { -5, 8, 2, 3, 7 };
            var result = new int[7];

            vector.CopyTo(result, 2);

            CollectionAssert.AreEqual(result, new[] { 0, 0, -5, 8, 2, 3, 7 });
        }
	}
}