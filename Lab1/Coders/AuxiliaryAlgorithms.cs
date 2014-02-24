using System;
using System.Collections.Generic;

namespace Coders
{
	public static class AuxiliaryAlgorithms
	{
		public static List<int> FindPrimeDividers(int number)
		{
			var result = new List<int>();

			var primeNumbers = FindPrimeNumbers(number);
			foreach (int i in primeNumbers)
				if (number % i == 0)
					result.Add(i);

			return result;
		}

		public static List<int> FindPrimeNumbers(int border)
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
