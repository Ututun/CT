using System;
using LinearAlgebra;

namespace Lab5
{
	class Program
	{
		static readonly Polynomial irreduciblePolynomial = new Polynomial { 1, 0, 1, 1 };
		const int module = 2;

		static void Main(string[] args)
		{
			var f = new Polynomial { 0, 1, 1 };
			var g = new Polynomial { 1, 1 };

			var result = Algorithm.GetResidueInZp(((f * g) % module), irreduciblePolynomial, module);

			for (int i = 0; i < result.Count; ++i)
				Console.Write(result[i] + " ");

			Console.WriteLine();
		}
	}
}
