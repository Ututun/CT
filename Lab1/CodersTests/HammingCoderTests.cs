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
			var coder = new HammingCoder(1, 2);
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
			var coder = new HammingCoder(2, 2);
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
			var coder = new HammingCoder(11, 2);
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

		[TestMethod]
		public void EncodeTest4()
		{
			var coder = new HammingCoder(2, 3);
			var information = new RowVector(2);
			information[0] = 2;
			information[1] = 1;

			var result = coder.Encode(information);

			Assert.AreEqual(result[0], 2);
			Assert.AreEqual(result[1], 0);
			Assert.AreEqual(result[2], 2);
			Assert.AreEqual(result[3], 1);
		}

		[TestMethod]
		public void EncodeTest5()
		{
			var coder = new HammingCoder(4, 5);
			var information = new RowVector(4);
			information[0] = 2;
			information[1] = 3;
			information[2] = 0;
			information[3] = 1;

			var result = coder.Encode(information);

			Assert.AreEqual(result[0], 3);
			Assert.AreEqual(result[1], 4);
			Assert.AreEqual(result[2], 2);
			Assert.AreEqual(result[3], 3);
			Assert.AreEqual(result[4], 0);
			Assert.AreEqual(result[5], 1);
		}

		[TestMethod]
		public void EncodeTest6()
		{
			var coder = new HammingCoder(7, 3);
			var information = new RowVector(7);
			information[0] = 0;
			information[1] = 1;
			information[2] = 0;
			information[3] = 2;
			information[4] = 0;
			information[5] = 0;
			information[6] = 2;

			var result = coder.Encode(information);

			Assert.AreEqual(result[0], 2);
			Assert.AreEqual(result[1], 0);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 2);
			Assert.AreEqual(result[5], 0);
			Assert.AreEqual(result[6], 2);
			Assert.AreEqual(result[7], 0);
			Assert.AreEqual(result[8], 0);
			Assert.AreEqual(result[9], 2);
		}

		[TestMethod]
		public void EncodeTest7()
		{
			var coder = new HammingCoder(10, 3);
			var information = new RowVector(10);
			information[0] = 0;
			information[1] = 1;
			information[2] = 2;
			information[3] = 1;
			information[4] = 0;
			information[5] = 1;
			information[6] = 2;
			information[7] = 1;
			information[8] = 0;
			information[9] = 1;

			var result = coder.Encode(information);

			Assert.AreEqual(result[0], 2);
			Assert.AreEqual(result[1], 1);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 1);
			Assert.AreEqual(result[5], 2);
			Assert.AreEqual(result[6], 1);
			Assert.AreEqual(result[7], 0);
			Assert.AreEqual(result[8], 1);
			Assert.AreEqual(result[9], 2);
			Assert.AreEqual(result[10], 1);
			Assert.AreEqual(result[11], 0);
			Assert.AreEqual(result[12], 1);
		}

		[TestMethod]
		public void EncodeTest8()
		{
			var coder = new HammingCoder(12, 5);
			var information = new RowVector(12);
			information[0] = 4;
			information[1] = 2;
			information[2] = 0;
			information[3] = 1;
			information[4] = 3;
			information[5] = 3;
			information[6] = 1;
			information[7] = 2;
			information[8] = 3;
			information[9] = 4;
			information[10] = 3;
			information[11] = 4;

			var result = coder.Encode(information);

			Assert.AreEqual(result[0], 1);
			Assert.AreEqual(result[1], 4);
			Assert.AreEqual(result[2], 4);
			Assert.AreEqual(result[3], 2);
			Assert.AreEqual(result[4], 0);
			Assert.AreEqual(result[5], 1);
			Assert.AreEqual(result[6], 2);
			Assert.AreEqual(result[7], 3);
			Assert.AreEqual(result[8], 3);
			Assert.AreEqual(result[9], 1);
			Assert.AreEqual(result[10], 2);
			Assert.AreEqual(result[11], 3);
			Assert.AreEqual(result[12], 4);
			Assert.AreEqual(result[13], 3);
			Assert.AreEqual(result[14], 4);
		}

		[TestMethod]
		public void DecodeTest1()
		{
			var coder = new HammingCoder(4, 5);
			var cipher = new RowVector(6);
			cipher[0] = 3;
			cipher[1] = 4;
			cipher[2] = 2;
			cipher[3] = 1;
			cipher[4] = 0;
			cipher[5] = 1;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 2);
			Assert.AreEqual(result[1], 3);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
		}

		[TestMethod]
		public void DecodeTest2()
		{
			var coder = new HammingCoder(7, 3);
			var cipher = new RowVector(10);
			cipher[0] = 2;
			cipher[1] = 0;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 2;
			cipher[5] = 0;
			cipher[6] = 2;
			cipher[7] = 0;
			cipher[8] = 0;
			cipher[9] = 2;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 2);
			Assert.AreEqual(result[4], 0);
			Assert.AreEqual(result[5], 0);
			Assert.AreEqual(result[6], 2);
		}

		[TestMethod]
		public void DecodeTest3()
		{
			var coder = new HammingCoder(7, 3);
			var cipher = new RowVector(10);
			cipher[0] = 2;
			cipher[1] = 0;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 2;
			cipher[5] = 2;
			cipher[6] = 2;
			cipher[7] = 0;
			cipher[8] = 0;
			cipher[9] = 2;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 2);
			Assert.AreEqual(result[4], 0);
			Assert.AreEqual(result[5], 0);
			Assert.AreEqual(result[6], 2);
		}

		[TestMethod]
		public void DecodeTest4()
		{
			var coder = new HammingCoder(7, 3);
			var cipher = new RowVector(10);
			cipher[0] = 2;
			cipher[1] = 0;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 2;
			cipher[5] = 0;
			cipher[6] = 2;
			cipher[7] = 1;
			cipher[8] = 0;
			cipher[9] = 2;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 2);
			Assert.AreEqual(result[4], 0);
			Assert.AreEqual(result[5], 0);
			Assert.AreEqual(result[6], 2);
		}

		[TestMethod]
		public void DecodeTest5()
		{
			var coder = new HammingCoder(10, 3);
			var cipher = new RowVector(13);
			cipher[0] = 2;
			cipher[1] = 1;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 1;
			cipher[5] = 2;
			cipher[6] = 1;
			cipher[7] = 0;
			cipher[8] = 1;
			cipher[9] = 2;
			cipher[10] = 1;
			cipher[11] = 0;
			cipher[12] = 1;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
			Assert.AreEqual(result[2], 2);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 0);
			Assert.AreEqual(result[5], 1);
			Assert.AreEqual(result[6], 2);
			Assert.AreEqual(result[7], 1);
			Assert.AreEqual(result[8], 0);
			Assert.AreEqual(result[9], 1);
		}

		[TestMethod]
		public void DecodeTest6()
		{
			var coder = new HammingCoder(10, 3);
			var cipher = new RowVector(13);
			cipher[0] = 2;
			cipher[1] = 1;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 1;
			cipher[5] = 2;
			cipher[6] = 2;
			cipher[7] = 0;
			cipher[8] = 1;
			cipher[9] = 2;
			cipher[10] = 1;
			cipher[11] = 0;
			cipher[12] = 1;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
			Assert.AreEqual(result[2], 2);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 0);
			Assert.AreEqual(result[5], 1);
			Assert.AreEqual(result[6], 2);
			Assert.AreEqual(result[7], 1);
			Assert.AreEqual(result[8], 0);
			Assert.AreEqual(result[9], 1);
		}

		[TestMethod]
		public void DecodeTest7()
		{
			var coder = new HammingCoder(10, 3);
			var cipher = new RowVector(13);
			cipher[0] = 2;
			cipher[1] = 1;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 1;
			cipher[5] = 2;
			cipher[6] = 1;
			cipher[7] = 0;
			cipher[8] = 1;
			cipher[9] = 2;
			cipher[10] = 1;
			cipher[11] = 0;
			cipher[12] = 0;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 0);
			Assert.AreEqual(result[1], 1);
			Assert.AreEqual(result[2], 2);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 0);
			Assert.AreEqual(result[5], 1);
			Assert.AreEqual(result[6], 2);
			Assert.AreEqual(result[7], 1);
			Assert.AreEqual(result[8], 0);
			Assert.AreEqual(result[9], 1);
		}

		[TestMethod]
		public void DecodeTest8()
		{
			var coder = new HammingCoder(12, 5);
			var cipher = new RowVector(15);
			cipher[0] = 1;
			cipher[1] = 4;
			cipher[2] = 4;
			cipher[3] = 2;
			cipher[4] = 0;
			cipher[5] = 1;
			cipher[6] = 2;
			cipher[7] = 3;
			cipher[8] = 3;
			cipher[9] = 1;
			cipher[10] = 2;
			cipher[11] = 3;
			cipher[12] = 4;
			cipher[13] = 3;
			cipher[14] = 4;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 4);
			Assert.AreEqual(result[1], 2);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 3);
			Assert.AreEqual(result[5], 3);
			Assert.AreEqual(result[6], 1);
			Assert.AreEqual(result[7], 2);
			Assert.AreEqual(result[8], 3);
			Assert.AreEqual(result[9], 4);
			Assert.AreEqual(result[10], 3);
			Assert.AreEqual(result[11], 4);
		}

		[TestMethod]
		public void DecodeTest9()
		{
			var coder = new HammingCoder(12, 5);
			var cipher = new RowVector(15);
			cipher[0] = 1;
			cipher[1] = 4;
			cipher[2] = 4;
			cipher[3] = 2;
			cipher[4] = 0;
			cipher[5] = 1;
			cipher[6] = 2;
			cipher[7] = 3;
			cipher[8] = 3;
			cipher[9] = 1;
			cipher[10] = 4;
			cipher[11] = 3;
			cipher[12] = 4;
			cipher[13] = 3;
			cipher[14] = 4;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 4);
			Assert.AreEqual(result[1], 2);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 3);
			Assert.AreEqual(result[5], 3);
			Assert.AreEqual(result[6], 1);
			Assert.AreEqual(result[7], 2);
			Assert.AreEqual(result[8], 3);
			Assert.AreEqual(result[9], 4);
			Assert.AreEqual(result[10], 3);
			Assert.AreEqual(result[11], 4);
		}

		[TestMethod]
		public void DecodeTest10()
		{
			var coder = new HammingCoder(12, 5);
			var cipher = new RowVector(15);
			cipher[0] = 1;
			cipher[1] = 4;
			cipher[2] = 4;
			cipher[3] = 2;
			cipher[4] = 0;
			cipher[5] = 1;
			cipher[6] = 2;
			cipher[7] = 3;
			cipher[8] = 3;
			cipher[9] = 1;
			cipher[10] = 2;
			cipher[11] = 3;
			cipher[12] = 4;
			cipher[13] = 3;
			cipher[14] = 1;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 4);
			Assert.AreEqual(result[1], 2);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 3);
			Assert.AreEqual(result[5], 3);
			Assert.AreEqual(result[6], 1);
			Assert.AreEqual(result[7], 2);
			Assert.AreEqual(result[8], 3);
			Assert.AreEqual(result[9], 4);
			Assert.AreEqual(result[10], 3);
			Assert.AreEqual(result[11], 4);
		}

		[TestMethod]
		public void DecodeTest11()
		{
			var coder = new HammingCoder(12, 5);
			var cipher = new RowVector(15);
			cipher[0] = 1;
			cipher[1] = 4;
			cipher[2] = 4;
			cipher[3] = 2;
			cipher[4] = 0;
			cipher[5] = 1;
			cipher[6] = 2;
			cipher[7] = 3;
			cipher[8] = 3;
			cipher[9] = 1;
			cipher[10] = 4;
			cipher[11] = 3;
			cipher[12] = 4;
			cipher[13] = 3;
			cipher[14] = 4;

			var result = coder.Decode(cipher);

			Assert.AreEqual(result[0], 4);
			Assert.AreEqual(result[1], 2);
			Assert.AreEqual(result[2], 0);
			Assert.AreEqual(result[3], 1);
			Assert.AreEqual(result[4], 3);
			Assert.AreEqual(result[5], 3);
			Assert.AreEqual(result[6], 1);
			Assert.AreEqual(result[7], 2);
			Assert.AreEqual(result[8], 3);
			Assert.AreEqual(result[9], 4);
			Assert.AreEqual(result[10], 3);
			Assert.AreEqual(result[11], 4);
		}
	}
}
