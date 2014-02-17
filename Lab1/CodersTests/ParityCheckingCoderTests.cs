using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coders;
using LinearAlgebra;

namespace CodersTests
{
	[TestClass]
	public class ParityCheckingCoderTests
	{
		[TestMethod, ExpectedException(typeof(ParityBitException))]
		public void IncorrectInformationRowVectorLengthExceptionInEncodeTest()
		{
			var coder = new ParityCheckingCoder(4);
			var cipher = new RowVector(5);
			cipher[0] = 1;
			cipher[1] = 0;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 1;

			var result = coder.Decode(cipher);
		}

		[TestMethod]
		public void EncodeTest1()
		{
			var coder = new ParityCheckingCoder(4);
			var information = new RowVector(4);
			information[0] = 1;
			information[1] = 0;
			information[2] = 0;
			information[3] = 1;

			var result = coder.Encode(information);

			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 0);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 0);
		}

		[TestMethod]
		public void DecodeTest1()
		{
			var coder = new ParityCheckingCoder(4);
			var cipher = new RowVector(5);
			cipher[0] = 1;
			cipher[1] = 0;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 0;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 0);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
		}
	}
}
