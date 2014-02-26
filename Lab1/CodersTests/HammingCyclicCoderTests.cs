using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coders;
using LinearAlgebra;

namespace CodersTests
{
	[TestClass]
	public class HammingCyclicCoderTests
	{
		[TestMethod]
		public void EncodeTest1()
		{
			var coder = new HammingCyclicCoder(4, 2);
			var information = new RowVector { 1, 1, 0, 1 };

			var result = coder.Encode(information);

			CollectionAssert.AreEqual(new RowVector { 1, 1, 1, 1, 1, 1, 1 }, result);
		}

		[TestMethod]
		public void DecodeTest1()
		{
			var coder = new HammingCyclicCoder(4, 2);
			var cipher = new RowVector { 1, 1, 1, 0, 1, 1, 1 };

			var result = coder.Decode(cipher);

			CollectionAssert.AreEqual(new RowVector { 1, 1, 0, 1 }, result);
		}

		[TestMethod]
		public void EncodeTest2()
		{
			var coder = new HammingCyclicCoder(2, 3);
			var information = new RowVector { 1, 0 };

			var result = coder.Encode(information);

			CollectionAssert.AreEqual(new RowVector { 1, 0, 1, 0 }, result);
		}

		[TestMethod]
		public void DecodeTest2()
		{
			var coder = new HammingCyclicCoder(2, 3);
			var cipher = new RowVector { 1, 1, 1, 0 };

			var result = coder.Decode(cipher);

			CollectionAssert.AreEqual(new RowVector { 1, 0 }, result);
		}

		[TestMethod]
		public void EncodeTest3()
		{
			var coder = new HammingCyclicCoder(4, 3);
			var information = new RowVector { 1, 2, 1, 2 };

			var result = coder.Encode(information);

			CollectionAssert.AreEqual(new RowVector { 1, 2, 0, 1, 1, 2, 2 }, result);
		}

		[TestMethod]
		public void DecodeTest3()
		{
			var coder = new HammingCyclicCoder(4, 3);
			var cipher = new RowVector { 1, 2, 2, 1, 1, 2, 2 };

			var result = coder.Decode(cipher);

			CollectionAssert.AreEqual(new RowVector { 1, 2, 1, 2 }, result);
		}

		[TestMethod]
		public void EncodeTest4()
		{
			var coder = new HammingCyclicCoder(11, 2);
			var information = new RowVector { 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1 };

			var result = coder.Encode(information);

			CollectionAssert.AreEqual(new RowVector { 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 }, result);
		}

		[TestMethod]
		public void DecodeTest4()
		{
			var coder = new HammingCyclicCoder(11, 2);
			var cipher = new RowVector { 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1 };

			var result = coder.Decode(cipher);

			CollectionAssert.AreEqual(new RowVector { 0, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1 }, result);
		}
	}
}
