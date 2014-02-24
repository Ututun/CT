using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coders;

namespace CodersTests
{
	[TestClass]
	public class AuxiliaryAlgorithmsTests
	{
		[TestMethod]
		public void FindPrimeDividersTest1()
		{
			CollectionAssert.AreEqual(new List<int> { 3, 5 }, AuxiliaryAlgorithms.FindPrimeDividers(15));
		}

		[TestMethod]
		public void FindPrimeDividersTest2()
		{
			CollectionAssert.AreEqual(new List<int> { 2, 3, 5 }, AuxiliaryAlgorithms.FindPrimeDividers(60));
		}

		[TestMethod]
		public void FindPrimeDividersTest3()
		{
			CollectionAssert.AreEqual(new List<int> { 2, 3, 5, 11, 13 }, AuxiliaryAlgorithms.FindPrimeDividers(8580));
		}

		[TestMethod]
		public void FindPrimeDividersTest4()
		{
			CollectionAssert.AreEqual(new List<int> { 3, 5, 11, 13, 19 }, AuxiliaryAlgorithms.FindPrimeDividers(40755));
		}

		[TestMethod]
		public void FindPrimeDividersTest5()
		{
			CollectionAssert.AreEqual(new List<int> { 7, 11, 31 }, AuxiliaryAlgorithms.FindPrimeDividers(2387));
		}
		[TestMethod]
		public void FindPrimeDividersTest6()
		{
			CollectionAssert.AreEqual(new List<int> { 17, 19, 41, 59 }, AuxiliaryAlgorithms.FindPrimeDividers(781337));
		}

		[TestMethod]
		public void FindPrimeDividersTest7()
		{
			CollectionAssert.AreEqual(new List<int> { 3, 23, 73 }, AuxiliaryAlgorithms.FindPrimeDividers(5037));
		}
	}
}
