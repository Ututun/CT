using System;
using System.Collections.Generic;
using LinearAlgebra;

namespace Lab6
{
	public static class IrreducibleTrinomialsFinder
	{
		static List<Polynomial> _checkingPolynomials = new List<Polynomial>();
		static List<Polynomial> _irreducibleTrinomials = new List<Polynomial>();

		public static List<Polynomial> FindIrreducibleTrinomials(int maximalDegree, int module)
		{
			for (int degree = 2; degree <= maximalDegree; ++degree)
			{
				FindCheckingPolynomials(degree, module);

				var trinomial = new Polynomial(degree);

				for (int leadingCoefficient = 1; leadingCoefficient < module; ++leadingCoefficient)
				{
					trinomial.LeadingCoefficient = leadingCoefficient;
					for (int freeCoefficient = 1; freeCoefficient < module; ++freeCoefficient)
					{
						trinomial[0] = freeCoefficient;

						FindIrreducibleTrinomialsByDegree(trinomial, 1, module);
					}
				}
			}

			return _irreducibleTrinomials;
		}

		private static void FindCheckingPolynomials(int degree, int module)
		{
			_checkingPolynomials.Clear();

			var newPolynomial = new Polynomial((int)Math.Pow(module, degree) - 1);
			newPolynomial.LeadingCoefficient = 1;
			newPolynomial[0] = -1;
			_checkingPolynomials.Add(newPolynomial);

			var _degreePrimeDividers = FindPrimeDividers(degree);

			_checkingPolynomials = new List<Polynomial>();
			foreach (int divider in _degreePrimeDividers)
			{
				newPolynomial = new Polynomial((int)Math.Pow(module, degree / divider) - 1);
				newPolynomial.LeadingCoefficient = 1;
				newPolynomial[0] = -1;

				_checkingPolynomials.Add(newPolynomial);
			}
		}

		private static void FindIrreducibleTrinomialsByDegree(Polynomial trinomial, int coefficientIndex, int module)
		{
			if (coefficientIndex == trinomial.Degree)
			{
				if (IsIrreducibleTrinomial(trinomial, module))
					_irreducibleTrinomials.Add(new Polynomial(trinomial.Coefficients));

				return;
			}

			for (int i = 0; i < module; ++i)
			{
				trinomial[coefficientIndex] = i;
				FindIrreducibleTrinomialsByDegree(trinomial, coefficientIndex + 1, module);
			}
		}

		private static bool IsIrreducibleTrinomial(Polynomial polynomial, int module)
		{
			int notZeroCount = 2;
			for (int i = 1; i < polynomial.Degree; ++i)
				if (polynomial.Coefficients[i] != 0)
					++notZeroCount;

			if (notZeroCount != 3)
				return false;

			foreach (var checkingPolynomial in _checkingPolynomials)
				if (Algorithm.GCDInZp(checkingPolynomial, polynomial, module).Degree > 0)
					return false;

			return true;
		}

		private static List<int> FindPrimeDividers(int number)
		{
			var result = new List<int>();

			var primeNumbers = FindPrimeNumbers(number);
			foreach (int i in primeNumbers)
				if (number % i == 0)
					result.Add(i);

			return result;
		}

		private static List<int> FindPrimeNumbers(int border)
		{
			var result = new List<int>();

			if (border < 2)
				return result;

			result.Add(2);

			if (border == 2)
				return result;

			var mark = new bool[border + 1];
			int i = 3, sqrtBorder = (int)Math.Sqrt(border);
			while (i <= sqrtBorder)
			{
				if (!mark[i])
					result.Add(i);

				for (int j = i * i; j <= border; j += i)
					mark[j] = true;

				i += 2;
			}

			while (i <= border)
			{
				if (!mark[i])
					result.Add(i);
				i += 2;
			}

			return result;
		}
	}
}
