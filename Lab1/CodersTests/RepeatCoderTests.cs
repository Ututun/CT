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
		public void IncorrectInformationRowVectorLengthExceptionInEncodeTest1()
		{
			var coder = new RepeatCoder(4, 1);
			var information = new RowVector(3);
			information[0] = 1;
			information[1] = 0;
			information[2] = 0;

			var result = coder.Encode(information);
		}

        [TestMethod, ExpectedException(typeof(IncorrectInformationRowVectorLengthException))]
        public void IncorrectInformationRowVectorLengthExceptionInEncodeTest2()
        {
            var coder = new RepeatCoder(5, 2);
            var information = new RowVector(3);
            information[0] = 1;
            information[1] = 1;
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
        public void EncodeTest2()
        {
            var coder = new RepeatCoder(2, 2);
            var information = new RowVector(2);
            information[0] = 1;
            information[1] = 0;

            var result = coder.Encode(information);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 0);
            Assert.AreEqual(result[2], 1);
            Assert.AreEqual(result[3], 0);
            Assert.AreEqual(result[4], 1);
            Assert.AreEqual(result[5], 0);
            Assert.AreEqual(result[6], 1);
            Assert.AreEqual(result[7], 0);
            Assert.AreEqual(result[8], 1);
            Assert.AreEqual(result[9], 0);
        }

        [TestMethod]
        public void EncodeTest3()
        {
            var coder = new RepeatCoder(2, 3);
            var information = new RowVector(2);
            information[0] = 1;
            information[1] = 0;

            var result = coder.Encode(information);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 0);
            Assert.AreEqual(result[2], 1);
            Assert.AreEqual(result[3], 0);
            Assert.AreEqual(result[4], 1);
            Assert.AreEqual(result[5], 0);
            Assert.AreEqual(result[6], 1);
            Assert.AreEqual(result[7], 0);
            Assert.AreEqual(result[8], 1);
            Assert.AreEqual(result[9], 0);
            Assert.AreEqual(result[10], 1);
            Assert.AreEqual(result[11], 0);
            Assert.AreEqual(result[12], 1);
            Assert.AreEqual(result[13], 0);
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

        [TestMethod]
        public void DecodeTest2()
        {
            var coder = new RepeatCoder(3, 2);
            var cipher = new RowVector(15);
            cipher[0] = 1;
            cipher[1] = 0;
            cipher[2] = 1;
            cipher[3] = 1;
            cipher[4] = 0;
            cipher[5] = 0;
            cipher[6] = 1;
            cipher[7] = 1;
            cipher[8] = 0;
            cipher[9] = 1;
            cipher[10] = 0;
            cipher[11] = 0;
            cipher[12] = 1;
            cipher[13] = 0;
            cipher[14] = 0;

            var result = coder.Decode(cipher);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 0);
            Assert.AreEqual(result[2], 0);
        }

        [TestMethod]
        public void DecodeTest3()
        {
            var coder = new RepeatCoder(2, 3);
            var cipher = new RowVector(14);
            cipher[0] = 1;
            cipher[1] = 1;
            cipher[2] = 1;
            cipher[3] = 0;
            cipher[4] = 1;
            cipher[5] = 1;
            cipher[6] = 1;
            cipher[7] = 0;
            cipher[8] = 1;
            cipher[9] = 0;
            cipher[10] = 0;
            cipher[11] = 0;
            cipher[12] = 1;
            cipher[13] = 0;

            var result = coder.Decode(cipher);

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 0);
        }
	}
}
