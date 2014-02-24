using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;

namespace LinearAlgebraTests
{
	[TestClass]
	public class AlgorithmTests
	{
		[TestMethod]
		public void FindInverseElementInZpTest1()
		{
			Assert.AreEqual(3, Algorithm.FindInverseElementInZp(2, 5));
		}

		[TestMethod]
		public void FindInverseElementInZpTest2()
		{
			Assert.AreEqual(8, Algorithm.FindInverseElementInZp(5, 13));
		}

		[TestMethod]
		public void GetQuotientInZpTest1()
		{
			var dividend = new Polynomial { 1, 2, 3 };
			var divider = new Polynomial { 2, 0, 2 };

			var quotient = Algorithm.GetQuotientInZp(dividend, divider, 5);

			Assert.AreEqual(4, quotient[0]);
		}

		[TestMethod]
		public void GetQuotientInZpTest2()
		{
			var dividend = new Polynomial { 3, 4, -2, -1, 5, 3 };
			var divider = new Polynomial { 1, 2, 1 };

			var quotient = Algorithm.GetQuotientInZp(dividend, divider, 3);

			CollectionAssert.AreEqual(new Polynomial { 0, 1, 2 }, quotient);
		}

		[TestMethod]
		public void GetQuotientInZpTest3()
		{
			var dividend = new Polynomial { 6, 23, 22, -4, 0, 54, -20, 8, 15, -14 };
			var divider = new Polynomial { 2, 3, 1, -4, 7 };

			var quotient = Algorithm.GetQuotientInZp(dividend, divider, 7);

			CollectionAssert.AreEqual(new Polynomial { 3, 0, 6, 2, 1, 5 }, quotient);
		}

		[TestMethod]
		public void GetQuotientInZpTest4()
		{
			var dividend = new Polynomial { 4, 12, 10, 2, 9, 5 };
			var divider = new Polynomial { 1, 3, 8, 2 };

			var quotient = Algorithm.GetQuotientInZp(dividend, divider, 13);

			CollectionAssert.AreEqual(new Polynomial { 3, 1, 9 }, quotient);
		}

		[TestMethod]
		public void GetQuotientInZpTest5()
		{
			var dividend = new Polynomial { -5, 2, 7, 0, -4, 3, 8 };
			var divider = new Polynomial { -2, 3, 5 };

			var quotient = Algorithm.GetQuotientInZp(dividend, divider, 7);

			CollectionAssert.AreEqual(new Polynomial { 6, 4, 0, 3, 3 }, quotient);
		}

		[TestMethod]
		public void GetResidueInZpTest1()
		{
			var dividend = new Polynomial { 6, 23, 22, -4, 0, 54, -20, 8, 15, -14 };
			var divider = new Polynomial { 2, 3, 1, -4, 7 };

			var quotient = Algorithm.GetResidueInZp(dividend, divider, 7);

			CollectionAssert.AreEqual(new Polynomial { 0 }, quotient);
		}

		[TestMethod]
		public void GetResidueInZpTest2()
		{
			var dividend = new Polynomial { 3, 4, -2, -1, 5, 3 };
			var divider = new Polynomial { 1, 2, 1 };

			var quotient = Algorithm.GetResidueInZp(dividend, divider, 3);

			CollectionAssert.AreEqual(new Polynomial { 0 }, quotient);
		}

		[TestMethod]
		public void GetResidueInZpTest3()
		{
			var dividend = new Polynomial { 4, 12, 10, 2, 9, 5 };
			var divider = new Polynomial { 1, 3, 8, 2 };

			var quotient = Algorithm.GetResidueInZp(dividend, divider, 13);

			CollectionAssert.AreEqual(new Polynomial { 1, 2 }, quotient);
		}

		[TestMethod]
		public void GetResidueInZpTest4()
		{
			var dividend = new Polynomial { 4, 12, 10, 2, 9, 5 };
			var divider = new Polynomial { 1, 3, 8, 2 };

			var quotient = Algorithm.GetResidueInZp(dividend, divider, 13);

			CollectionAssert.AreEqual(new Polynomial { 1, 2 }, quotient);
		}

		[TestMethod]
		public void GetResidueInZpTest5()
		{
			var dividend = new Polynomial { -5, 2, 7, 0, -4, 3, 8 };
			var divider = new Polynomial { -2, 3, 5 };

			var quotient = Algorithm.GetResidueInZp(dividend, divider, 7);

			CollectionAssert.AreEqual(new Polynomial { 0, 6 }, quotient);
		}

		[TestMethod]
		public void GCDInZpTest1()
		{
			var f = new Polynomial { -6, -1, -5, -1, 1 };
			var g = new Polynomial { -1, 0, 0, 0, 1 };

			var gcd = Algorithm.GCDInZp(f, g, 7);

			CollectionAssert.AreEqual(new Polynomial { 3, 0, 3 }, gcd);
		}

		[TestMethod]
		public void GCDInZpTest2()
		{
			var f = new Polynomial { 2, 5, 6, 4, 1 };
			var g = new Polynomial { 6, 2, 5, 1 };

			var gcd = Algorithm.GCDInZp(f, g, 7);

			CollectionAssert.AreEqual(new Polynomial { 2, 1 }, gcd);
		}

		[TestMethod]
		public void GCDInZpTest3()
		{
			var f = new Polynomial { 6, 23, 22, -4, 0, 54, -20, 8, 15, -14 };
			var g = new Polynomial { 2, 3, 1, -4, 7 };

			var gcd = Algorithm.GCDInZp(f, g, 13);

			CollectionAssert.AreEqual(new Polynomial { 2, 3, 1, 9, 7 }, gcd);
		}
	}
}
