using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;

namespace LinearAlgebraTests
{
	[TestClass]
	public class PolynomialTests
	{
		[TestMethod]
		public void AdditionTest1()
		{
			var polynomialF = new Polynomial { -64, 32, 16, 8, -4, -2, 1, 0, -73, 69 };
			var polynomialG = new Polynomial { 1, -2, 4, -8, 16, -32, 64 };

			var result = polynomialF + polynomialG;

			CollectionAssert.AreEqual(new Polynomial { -63, 30, 20, 0, 12, -34, 65, 0, -73, 69 }, result);
		}

		[TestMethod]
		public void AdditionTest2()
		{
			var polynomialF = new Polynomial { -64, 32, 16, 8, -4, 9 };
			var polynomialG = new Polynomial { 1, -32, 4, -8, 4, -9 };

			var result = polynomialF + polynomialG;

			CollectionAssert.AreEqual(new Polynomial { -63, 0, 20 }, result);
		}

		[TestMethod]
		public void SubtractionTest1()
		{
			var polynomialF = new Polynomial { -64, 32, 16, 8, -4, -2, 1, 0, -73, 69 };
			var polynomialG = new Polynomial { 1, -2, 4, -8, 16, -32, 64 };

			var result = polynomialG - polynomialF;

			CollectionAssert.AreEqual(new Polynomial { 65, -34, -12, -16, 20, -30, 63, 0, 73, -69 }, result);
		}

		[TestMethod]
		public void SubtractionTest2()
		{
			var polynomialF = new Polynomial { -64, 32, 16, 8, -4, -2, 1 };
			var polynomialG = new Polynomial { -1, 2, -4, 8, 16, -2, 1 };

			var result = polynomialG - polynomialF;

			CollectionAssert.AreEqual(new Polynomial { 63, -30, -20, 0, 20 }, result);
		}

		[TestMethod]
		public void MultiplicationTest1()
		{
			var polynomialF = new Polynomial { 1, 2, 1 };
			var polynomialG = new Polynomial { 3, -2, -1, 3 };

			var result = polynomialG * polynomialF;

			CollectionAssert.AreEqual(new Polynomial { 3, 4, -2, -1, 5, 3 }, result);
		}

		[TestMethod]
		public void MultiplicationTest2()
		{
			var polynomialF = new Polynomial { 2, 3, 1, -4, 7 };
			var polynomialG = new Polynomial { 3, 7, -1, 2, 1, -2 };

			var result = polynomialG * polynomialF;

			CollectionAssert.AreEqual(new Polynomial { 6, 23, 22, -4, 0, 54, -20, 8, 15, -14 }, result);
		}

		[TestMethod]
		public void MultiplicationByNumberTest1()
		{
			var polynomialG = new Polynomial { 1, -2, 4, 7, -10 };

			var result = polynomialG * 7;

			CollectionAssert.AreEqual(new Polynomial { 7, -14, 28, 49, -70 }, result);
		}

		[TestMethod]
		public void CompareTest1()
		{
			var polynomialF = new Polynomial { 1, 0, 4, 5 };
			var polynomialG = new Polynomial { 1, 0, 4, 5 };

			Assert.AreEqual(polynomialF == polynomialG, true);
		}

		[TestMethod]
		public void CompareTest2()
		{
			var polynomialF = new Polynomial { 1, 0, 4, 5 };
			var polynomialG = new Polynomial { 1, 0, 4, 6 };

			Assert.AreEqual(polynomialF != polynomialG, true);
		}

		[TestMethod]
		public void CompareTest3()
		{
			var polynomialF = new Polynomial { 1, 0, 4, 5 };
			var polynomialG = new Polynomial { 1, 0, 4, 6 };

			Assert.AreEqual(polynomialF == polynomialG, false);
		}

		[TestMethod]
		public void CompareTest4()
		{
			var polynomialF = new Polynomial { 1, 0, 4, 5 };
			var polynomialG = new Polynomial { 1, 0, 4, 5 };

			Assert.AreEqual(polynomialF != polynomialG, false);
		}

		[TestMethod]
		public void ModulusOperatorTest1()
		{
			var polynomialF = new Polynomial { -64, 32, 16, 8, -4, -2, 1, 0, -73, 69 };

			var result = polynomialF % 7;

			CollectionAssert.AreEqual(new Polynomial { 6, 4, 2, 1, 3, 5, 1, 0, 4, 6 }, result);
		}
	}
}
