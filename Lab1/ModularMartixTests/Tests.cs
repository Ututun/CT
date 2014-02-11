﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra;

namespace ModularMartixTests
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void MultiplicationTest1()
		{
			var A = new ModularMatrix(2, 2);
			A[0, 0] = 1;
			A[0, 1] = 2;
			A[1, 0] = 3;
			A[1, 1] = 4;
			var B = new ModularMatrix(2, 2);
			B[0, 0] = 1;
			B[0, 1] = 2;
			B[1, 0] = 3;
			B[1, 1] = 4;

			var C = A * B;

			Assert.AreEqual(C[0, 0], 7);
			Assert.AreEqual(C[0, 1], 10);
			Assert.AreEqual(C[1, 0], 15);
			Assert.AreEqual(C[1, 1], 22);
		}

		[TestMethod]
		public void MultiplicationTest2()
		{
			var A = new ModularMatrix(2, 3);
			A[0, 0] = -1;
			A[0, 1] = 0;
			A[0, 2] = 1;
			A[1, 0] = 6;
			A[1, 1] = 0;
			A[1, 2] = 9;
			var B = new ModularMatrix(3, 2);
			B[0, 0] = -6;
			B[0, 1] = 6;
			B[1, 0] = 9;
			B[1, 1] = 7;
			B[2, 0] = 3;
			B[2, 1] = -9;

			var C = A * B;

			Assert.AreEqual(C[0, 0], 9);
			Assert.AreEqual(C[0, 1], -15);
			Assert.AreEqual(C[1, 0], -9);
			Assert.AreEqual(C[1, 1], -45);
		}
	}
}
