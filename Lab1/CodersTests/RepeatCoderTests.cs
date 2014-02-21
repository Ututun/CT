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
            var information = new RowVector { 1, 0, 0 };

			var result = coder.Encode(information);
		}

        [TestMethod, ExpectedException(typeof(IncorrectInformationRowVectorLengthException))]
        public void IncorrectInformationRowVectorLengthExceptionInEncodeTest2()
        {
            var coder = new RepeatCoder(5, 2);
            var information = new RowVector { 1, 1, 0 };

            var result = coder.Encode(information);
        }

		[TestMethod]
		public void EncodeTest1()
		{
			var coder = new RepeatCoder(4, 1);
            var information = new RowVector { 1, 0, 0, 1 };

			var result = coder.Encode(information);

            CollectionAssert.AreEqual(new[] { 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1 }, result);
		}

        [TestMethod]
        public void EncodeTest2()
        {
            var coder = new RepeatCoder(2, 2);
            var information = new RowVector { 1, 0 };

            var result = coder.Encode(information);

            CollectionAssert.AreEqual(new[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }, result);
        }

        [TestMethod]
        public void EncodeTest3()
        {
            var coder = new RepeatCoder(2, 3);
            var information = new RowVector { 1, 0 };

            var result = coder.Encode(information);

            CollectionAssert.AreEqual(new[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }, result);
        }

		[TestMethod]
		public void DecodeTest1()
		{
			var coder = new RepeatCoder(4, 1);
			var cipher = new RowVector { 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1 };

			var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(new[] { 1, 0, 0, 1 }, result);
		}

        [TestMethod]
        public void DecodeTest2()
        {
            var coder = new RepeatCoder(3, 2);
            var cipher = new RowVector { 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 0, 0 };

            var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(new[] { 1, 0, 0 }, result);
        }

        [TestMethod]
        public void DecodeTest3()
        {
            var coder = new RepeatCoder(2, 3);
            var cipher = new RowVector { 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0 };

            var result = coder.Decode(cipher);

            CollectionAssert.AreEqual(new[] { 1, 0 }, result);
        }
	}
}
