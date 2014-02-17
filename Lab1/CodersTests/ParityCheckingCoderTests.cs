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
			var cipher = new RowVector(5);
			cipher[0] = 1;
			cipher[1] = 0;
			cipher[2] = 0;
			cipher[3] = 1;
			cipher[4] = 1;

			var result = coder.Decode(cipher);
		}

        [TestMethod, ExpectedException(typeof(ParityBitException))]
        public void IncorrectInformationRowVectorLengthExceptionInEncodeTest2()
        {
            var coder = new ParityCheckingCoder(7);
            var cipher = new RowVector(8);
            cipher[0] = 1;
            cipher[1] = 0;
            cipher[2] = 0;
            cipher[3] = 1;
            cipher[4] = 1;
            cipher[5] = 1;
            cipher[6] = 0;
            cipher[7] = 1;

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
        public void EncodeTest2()
        {
            var coder = new ParityCheckingCoder(3);
            var information = new RowVector(3);
            information[0] = 1;
            information[1] = 0;
            information[2] = 1;

            var result = coder.Encode(information);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 0);
            Assert.AreEqual(result[2], 1);
            Assert.AreEqual(result[3], 0);
        }

        [TestMethod]
        public void EncodeTest3()
        {
            var coder = new ParityCheckingCoder(10);
            var information = new RowVector(10);
            information[0] = 1;
            information[1] = 1;
            information[2] = 0;
            information[3] = 0;
            information[4] = 1;
            information[5] = 0;
            information[6] = 0;
            information[7] = 1;
            information[8] = 0;
            information[9] = 1;

            var result = coder.Encode(information);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 1);
            Assert.AreEqual(result[2], 0);
            Assert.AreEqual(result[3], 0);
            Assert.AreEqual(result[4], 1);
            Assert.AreEqual(result[5], 0);
            Assert.AreEqual(result[6], 0);
            Assert.AreEqual(result[7], 1);
            Assert.AreEqual(result[8], 0);
            Assert.AreEqual(result[9], 1);
            Assert.AreEqual(result[10], 1);
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

        [TestMethod]
        public void DecodeTest2()
        {
            var coder = new ParityCheckingCoder(7);
            var cipher = new RowVector(8);
            cipher[0] = 1;
            cipher[1] = 0;
            cipher[2] = 1;
            cipher[3] = 1;
            cipher[4] = 1;
            cipher[5] = 1;
            cipher[6] = 0;
            cipher[7] = 1;

            var result = coder.Decode(cipher);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 0);
            Assert.AreEqual(result[2], 1);
            Assert.AreEqual(result[3], 1);
            Assert.AreEqual(result[4], 1);
            Assert.AreEqual(result[5], 1);
            Assert.AreEqual(result[6], 0);
        }

        [TestMethod]
        public void DecodeTest3()
        {
            var coder = new ParityCheckingCoder(10);
            var cipher = new RowVector(11);
            cipher[0] = 1;
            cipher[1] = 0;
            cipher[2] = 1;
            cipher[3] = 1;
            cipher[4] = 1;
            cipher[5] = 1;
            cipher[6] = 0;
            cipher[7] = 1;
            cipher[8] = 1;
            cipher[9] = 0;
            cipher[10] = 1;

            var result = coder.Decode(cipher);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 0);
            Assert.AreEqual(result[2], 1);
            Assert.AreEqual(result[3], 1);
            Assert.AreEqual(result[4], 1);
            Assert.AreEqual(result[5], 1);
            Assert.AreEqual(result[6], 0);
            Assert.AreEqual(result[7], 1);
            Assert.AreEqual(result[8], 1);
            Assert.AreEqual(result[9], 0);
        }
    }
}
