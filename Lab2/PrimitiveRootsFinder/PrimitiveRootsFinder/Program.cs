using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimitiveRootsFinder
{
	class Program
	{
		static void Main()
		{
			var primitiveRoots = FindPrimitiveElements(19);
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

		public static Dictionary<int, int> FindFactorizationNumbers(int number)
		{
			var result = new Dictionary<int, int>();

			var primeNumbers = FindPrimeNumbers(number);
			foreach (int i in primeNumbers)
			{
				int numberOfDivisions = 0;
				while (number > 1 && number % i == 0)
				{
					++numberOfDivisions;
					number /= i;
				}

				if (numberOfDivisions > 0)
					result.Add(i, numberOfDivisions);
			}

			return result;
		}

		public static List<int> FindDivisorsOfNumber(int number)
		{
			var result = new List<int>();
			var factorizationNumber = FindFactorizationNumbers(number);

			foreach (int i in factorizationNumber.Keys)
			{
				int divisor = 1;
				for (int j = 1; j <= factorizationNumber[i]; ++j)
				{
					divisor *= i;

					if (!result.Contains(divisor))
						result.Add(divisor);
				}

				int resultCount = result.Count;
				int temporal = result.Count - factorizationNumber[i];
				for (int j = temporal; j < resultCount; ++j)
					for (int k = 0; k < temporal; ++k)
						result.Add(result[k] * result[j]);
			}

			result.RemoveAt(result.Count - 1);
			return result;
		}

		public static List<int> FindPrimitiveElements(int module)
		{
			int orderOfGroup = module - 1;
			var divisorsNumber = FindDivisorsOfNumber(orderOfGroup);
			var result = new List<int>();

			if (module == 2)
				result.Add(1);
			else
				for (int i = 2; i < module; ++i)
				{
					bool numberIsPrimitiveElement = true;

					foreach (int j in divisorsNumber)
					{
						if ((Math.Pow(i, j) % module) == 1)
						{
							numberIsPrimitiveElement = false;
							break;
						}
					}

					if (numberIsPrimitiveElement)
						result.Add(i);
				}

			return result;
		}
	}
}
