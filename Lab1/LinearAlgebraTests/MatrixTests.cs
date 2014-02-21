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

        [TestMethod, ExpectedException(typeof(IncorrectMatrixSizesException))]
        public void IncorrectMatrixSizesExceptionInAddRow()
        {
            var A = new Matrix(2, 3);
            var vector = new RowVector { 1, 0, 3, 4 };

            A.Add(vector);
        }

        [TestMethod, ExpectedException(typeof(IncorrectMatrixSizesException))]
        public void IncorrectMatrixSizesExceptionInAddColumn()
        {
            var A = new Matrix(2, 3);
            var vector = new ColumnVector { 1, 0, 3 };

            A.Add(vector);
        }

        [TestMethod]
		public void MultiplicationTest1()
		{
			var A = new Matrix { new RowVector { 1, 2 },
								 new RowVector { 3, 4 } };
            var B = new Matrix { new RowVector { 1, 2 },
								 new RowVector { 3, 4 } };

			var C = A * B;

            CollectionAssert.AreEqual(new[,] { { 7, 10 }, { 15, 22 } }, C);
		}

		[TestMethod]
		public void MultiplicationTest2()
		{
            var A = new Matrix { new RowVector { -1, 0, 1 },
								 new RowVector { 6, 0, 9 } };
            var B = new Matrix { new RowVector { -6, 6 },
								 new RowVector { 9, 7 },
								 new RowVector { 3, -9 } };

			var C = A * B;

            CollectionAssert.AreEqual(new[,] { { 9, -15 }, { -9, -45 } }, C);
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
            var A = new Matrix {new RowVector { 1, 2 },
								new RowVector { 3, 4 } };
            var B = new Matrix {new RowVector { 1, 2 },
								new RowVector { 3, 4 } };

            var C = A + B;

            CollectionAssert.AreEqual(new[,] { { 2, 4 }, { 6, 8 } }, C);
        }

        [TestMethod]
        public void ModulusOperatorTest1()
        {
            int module = 4;
            var A = new Matrix { new RowVector { -8, 4, -7 },
                                 new RowVector { 9, -14, 18 },
                                 new RowVector { 3, -1, 0 } };

            var C = A % module;

            CollectionAssert.AreEqual(new[,] { { 0, 0, 1  }, { 1, 2, 2 }, { 3, 3, 0 } }, C);
        }

		[TestMethod]
		public void GetTransposedTest1()
		{
            var A = new Matrix { new RowVector { 2, 3, 0 },
                                 new RowVector { 4, 5, 6 } };

            var C = A.GetTransposed();

            CollectionAssert.AreEqual(new[,] { { 2, 4 }, { 3, 5 }, { 0, 6 } }, C);
		}

        [TestMethod]
        public void GetTransposedTest2()
        {
            var A = new Matrix { new RowVector { 2, 3, 0, 1 },
                                 new RowVector { 4, 5, 6, 2 }, 
                                 new RowVector { 1, 0, 4, 7 } };

            var C = A.GetTransposed();

            CollectionAssert.AreEqual(new[,] { { 2, 4, 1 }, { 3, 5, 0 }, { 0, 6, 4 }, { 1, 2, 7 } }, C);
        }

        [TestMethod]
        public void AddRowTest1()
        {
            var A = new Matrix();
            var vector = new RowVector { 1, 0, 3, 4 };

            A.Add(vector);

            CollectionAssert.AreEqual(new[,] { { 1, 0, 3, 4 } }, A);
        }

        [TestMethod]
        public void AddRowTest2()
        {
            var A = new Matrix { new RowVector { 2, 3, 0, 1 },
                                 new RowVector { 4, 5, 6, 2 }, 
                                 new RowVector { 1, 0, 4, 7 } };
            var vector = new RowVector { 1, 0, 3, 4 };

            A.Add(vector);

            CollectionAssert.AreEqual(new[,] { { 2, 3, 0, 1 }, { 4, 5, 6, 2 }, { 1, 0, 4, 7 }, { 1, 0, 3, 4 } }, A);
        }

        [TestMethod]
        public void AddColumnTest1()
        {
            var A = new Matrix();
            var vector = new ColumnVector { 1, 0, 3 };

            A.Add(vector);

            CollectionAssert.AreEqual(new[,] { { 1 }, { 0 }, { 3 } }, A);
        }

        [TestMethod]
        public void AddColumnTest2()
        {
            var A = new Matrix { new RowVector { 2, 3, 0, 1 },
                                 new RowVector { 4, 5, 6, 2 }, 
                                 new RowVector { 1, 0, 4, 7 } };
            var vector = new ColumnVector { 1, 0, 3 };

            A.Add(vector);

            CollectionAssert.AreEqual(new[,] { { 2, 3, 0, 1, 1 }, { 4, 5, 6, 2, 0 }, { 1, 0, 4, 7, 3 } }, A);
        }

        [TestMethod]
        public void CopyToTest1()
        {
            var A = new Matrix { new RowVector { 2, 3, 0, 1 },
                                 new RowVector { 4, 5, 6, 2 }, 
                                 new RowVector { 1, 0, 4, 7 } };
            var result = new int[12];

            A.CopyTo(result, 0);

            CollectionAssert.AreEqual(new[] { 2, 3, 0, 1, 4, 5, 6, 2, 1, 0, 4, 7 }, result);
        }

        [TestMethod]
        public void CopyToTest2()
        {
            var A = new Matrix { new RowVector { 2, 3, 0, 1 },
                                 new RowVector { 4, 5, 6, 2 }, 
                                 new RowVector { 1, 0, 4, 7 } };
            var result = new int[16];

            A.CopyTo(result, 2);

            CollectionAssert.AreEqual(new[] { 0, 0, 2, 3, 0, 1, 4, 5, 6, 2, 1, 0, 4, 7, 0, 0 }, result);
        }
	}
}