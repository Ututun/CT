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
		public void IncorrectInformationRowVectorLengthExceptionInEncodeTest1()
		{
			var coder = new ParityCheckingCoder(4);
            var cipher = new RowVector { 1, 0, 0, 1, 1 };

			var result = coder.Decode(cipher);
		}

        [TestMethod, ExpectedException(typeof(ParityBitException))]
        public void IncorrectInformationRowVectorLengthExceptionInEncodeTest2()
        {
            var coder = new ParityCheckingCoder(7);
            var cipher = new RowVector { 1, 0, 0, 1, 1, 1, 0, 1 };

            var result = coder.Decode(cipher);
        }

		[TestMethod]
		public void EncodeTest1()
		{
			var coder = new ParityCheckingCoder(4);
            var information = new RowVector { 1, 0, 0, 1 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(new[] { 1, 0, 0, 1, 0 }, result);
		}

        [TestMethod]
        public void EncodeTest2()
        {
            var coder = new ParityCheckingCoder(3);
            var information = new RowVector { 1, 0, 1 };

            var result = coder.Encode(information);

            CollectionAssert.AreEqual(new[] { 1, 0, 1, 0 }, result);
        }

        [TestMethod]
        public void EncodeTest3()
        {
            var coder = new ParityCheckingCoder(10);
            var information = new RowVector { 1, 1, 0, 0, 1, 0, 0, 1, 0, 1 };

            var result = coder.Encode(information);

            CollectionAssert.AreEqual(new[] { 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 1 }, result);
        }

		[TestMethod]
		public void DecodeTest1()
		{
			var coder = new ParityCheckingCoder(4);
            var cipher = new RowVector { 1, 0, 0, 1, 0 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(new[] { 1, 0, 0, 1 }, result);
		}

        [TestMethod]
        public void DecodeTest2()
        {
            var coder = new ParityCheckingCoder(7);
            var cipher = new RowVector { 1, 0, 1, 1, 1, 1, 0, 1 };

            var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(new[] { 1, 0, 1, 1, 1, 1, 0 }, result);
        }

        [TestMethod]
        public void DecodeTest3()
        {
            var coder = new ParityCheckingCoder(10);
            var cipher = new RowVector { 1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 1 };

            var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(new[] { 1, 0, 1, 1, 1, 1, 0, 1, 1, 0 }, result);
        }
    }
}
