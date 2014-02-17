using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coders;
using LinearAlgebra;

namespace CodersTests
{
	[TestClass]
	public class HammingCoderTests
	{
		[TestMethod]
		public void EncodeTest1()
		{
			var coder = new HammingCoder(1);
			var information = new RowVector(1);
			information[0] = 1;

			var result = coder.Encode(information);

			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 1);
			Assert.AreEqual(result[2], 1);
		}

		[TestMethod]
		public void EncodeTest2()
		{
			var coder = new HammingCoder(2);
			var information = new RowVector(2);
			information[0] = 0;
			information[1] = 1;

			var result = coder.Encode(information);

			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 0);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 1);
		}

		[TestMethod]
		public void EncodeTest3()
		{
			var coder = new HammingCoder(11);
			var information = new RowVector(11);
			information[0] = 1;
			information[1] = 0;
			information[2] = 0;
			information[3] = 1;
			information[4] = 1;
			information[5] = 1;
			information[6] = 0;
			information[7] = 1;
			information[8] = 0;
			information[9] = 0;
			information[10] = 1;

			var result = coder.Encode(information);

			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 0);
			Assert.AreEqual(result[2], 1);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 0);
			Assert.AreEqual(result[5], 0);
			Assert.AreEqual(result[6], 1);
			Assert.AreEqual(result[7], 0);
			Assert.AreEqual(result[8], 1);
			Assert.AreEqual(result[9], 1);
			Assert.AreEqual(result[10], 0);
			Assert.AreEqual(result[11], 1);
			Assert.AreEqual(result[12], 0);
			Assert.AreEqual(result[13], 0);
			Assert.AreEqual(result[14], 1);
		}
	}
}
