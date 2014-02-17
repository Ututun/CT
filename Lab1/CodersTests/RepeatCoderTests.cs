using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coders;
using LinearAlgebra;

namespace CodersTests
{
	[TestClass]
	public class RepeatCoderTests
	{
		[TestMethod, ExpectedException(typeof(IncorrectInformationRowVectorLengthException))]
		public void IncorrectInformationRowVectorLengthExceptionInEncodeTest()
		{
			var coder = new RepeatCoder(4, 1);
			var information = new RowVector(3);
			information[0] = 1;
			information[1] = 0;
			information[2] = 0;

			var result = coder.Encode(information);
		}

		[TestMethod]
		public void EncodeTest1()
		{
			var coder = new RepeatCoder(4, 1);
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
			Assert.AreEqual(result[4], 1);
			Assert.AreEqual(result[5], 0);
			Assert.AreEqual(result[6], 0);
			Assert.AreEqual(result[7], 1);
			Assert.AreEqual(result[8], 1);
			Assert.AreEqual(result[9], 0);
			Assert.AreEqual(result[10], 0);
			Assert.AreEqual(result[11], 1);
		}

		[TestMethod]
		public void DecodeTest1()
		{
			var coder = new RepeatCoder(4, 1);
			var cipher = new RowVector(12);
			cipher[0] = 1;
			cipher[1] = 0;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 0;
			cipher[5] = 0;
			cipher[6] = 0;
			cipher[7] = 1;
			cipher[8] = 1;
			cipher[9] = 0;
			cipher[10] = 0;
			cipher[11] = 1;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 0);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
			
		}
	}
}
