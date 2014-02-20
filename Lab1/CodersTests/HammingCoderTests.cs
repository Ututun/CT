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
            var information = new RowVector { 1 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(result, new[] { 1, 1, 1 });
		}

		[TestMethod]
		public void EncodeTest2()
		{
			var coder = new HammingCoder(2, 2);
            var information = new RowVector { 0, 1 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(result, new[] { 1, 0, 0, 1, 1 });
		}

		[TestMethod]
		public void EncodeTest3()
		{
			var coder = new HammingCoder(11, 2);
            var information = new RowVector { 1, 0, 0, 1, 1, 1, 0, 1, 0, 0, 1 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(result, new[] { 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1 });
		}

		[TestMethod]
		public void EncodeTest4()
		{
			var coder = new HammingCoder(2, 3);
			var information = new RowVector { 2, 1 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(result, new[] { 2, 0, 2, 1 });
		}

		[TestMethod]
		public void EncodeTest5()
		{
			var coder = new HammingCoder(4, 5);
            var information = new RowVector { 2, 3, 0, 1 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(result, new[] { 3, 4, 2, 3, 0, 1 });
		}

		[TestMethod]
		public void EncodeTest6()
		{
			var coder = new HammingCoder(7, 3);
            var information = new RowVector { 0, 1, 0, 2, 0, 0, 2 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(result, new[] { 2, 0, 0, 1, 2, 0, 2, 0, 0, 2 });
		}

		[TestMethod]
		public void EncodeTest7()
		{
			var coder = new HammingCoder(10, 3);
            var information = new RowVector { 0, 1, 2, 1, 0, 1, 2, 1, 0, 1 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(result, new[] { 2, 1, 0, 1, 1, 2, 1, 0, 1, 2, 1, 0, 1 });
		}

		[TestMethod]
		public void EncodeTest8()
		{
			var coder = new HammingCoder(12, 5);
            var information = new RowVector { 4, 2, 0, 1, 3, 3, 1, 2, 3, 4, 3, 4 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(result, new[] { 1, 4, 4, 2, 0, 1, 2, 3, 3, 1, 2, 3, 4, 3, 4 });
		}

		[TestMethod]
		public void DecodeTest1()
		{
			var coder = new HammingCoder(4, 5);
            var cipher = new RowVector { 3, 4, 2, 1, 0, 1 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 2, 3, 0, 1 });
		}

		[TestMethod]
		public void DecodeTest2()
		{
			var coder = new HammingCoder(7, 3);
            var cipher = new RowVector {  2, 0, 0, 1, 2, 0, 2, 0, 0, 2 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 0, 1, 0, 2, 0, 0, 2 });
		}

		[TestMethod]
		public void DecodeTest3()
		{
			var coder = new HammingCoder(7, 3);
            var cipher = new RowVector { 2, 0, 0, 1, 2, 2, 2, 0, 0, 2 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 0, 1, 0, 2, 0, 0, 2 });
		}

		[TestMethod]
		public void DecodeTest4()
		{
			var coder = new HammingCoder(7, 3);
            var cipher = new RowVector { 2, 0, 0, 1, 2, 0, 2, 1, 0, 2 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 0, 1, 0, 2, 0, 0, 2 });
		}

		[TestMethod]
		public void DecodeTest5()
		{
			var coder = new HammingCoder(10, 3);
            var cipher = new RowVector { 2, 1, 0, 1, 1, 2, 1, 0, 1, 2, 1, 0, 1 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 0, 1, 2, 1, 0, 1, 2, 1, 0, 1 });
		}

		[TestMethod]
		public void DecodeTest6()
		{
			var coder = new HammingCoder(10, 3);
            var cipher = new RowVector { 2, 1, 0, 1, 1, 2, 2, 0, 1, 2, 1, 0, 1 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 0, 1, 2, 1, 0, 1, 2, 1, 0, 1 });
		}

		[TestMethod]
		public void DecodeTest7()
		{
			var coder = new HammingCoder(10, 3);
            var cipher = new RowVector { 2, 1, 0, 1, 1, 2, 1, 0, 1, 2, 1, 0, 0 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 0, 1, 2, 1, 0, 1, 2, 1, 0, 1 });
		}

		[TestMethod]
		public void DecodeTest8()
		{
			var coder = new HammingCoder(12, 5);
			var cipher = new RowVector { 1, 4, 4, 2, 0, 1, 2, 3, 3, 1, 2, 3, 4, 3, 4 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 4, 2, 0, 1, 3, 3, 1, 2, 3, 4, 3, 4 });
		}

		[TestMethod]
		public void DecodeTest9()
		{
			var coder = new HammingCoder(12, 5);
            var cipher = new RowVector { 1, 4, 4, 2, 0, 1, 2, 3, 3, 1, 4, 3, 4, 3, 4 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 4, 2, 0, 1, 3, 3, 1, 2, 3, 4, 3, 4 });
		}

		[TestMethod]
		public void DecodeTest10()
		{
			var coder = new HammingCoder(12, 5);
            var cipher = new RowVector { 1, 4, 4, 2, 0, 1, 2, 3, 3, 1, 2, 3, 4, 3, 1 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 4, 2, 0, 1, 3, 3, 1, 2, 3, 4, 3, 4 });
		}

		[TestMethod]
		public void DecodeTest11()
		{
			var coder = new HammingCoder(12, 5);
            var cipher = new RowVector { 1, 4, 4, 2, 0, 1, 2, 3, 3, 1, 4, 3, 4, 3, 4 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(result, new[] { 4, 2, 0, 1, 3, 3, 1, 2, 3, 4, 3, 4 });
		}
	}
}
