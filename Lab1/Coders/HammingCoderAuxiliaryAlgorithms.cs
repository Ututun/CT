using System;
using System.Collections.Generic;
using LinearAlgebra;

namespace Coders
{
	public static class HammingCoderAuxiliaryAlgorithms
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

		public static Matrix FindCheckingMatrix(int rowNumber, int columnNumber, int module)
		{
			var result = new Matrix(rowNumber, columnNumber);

			var mark = new bool[(int)Math.Pow(module, rowNumber) - 1];

			for (int i = 0, vectorCounter = 1; i < columnNumber; ++vectorCounter)
				if (!mark[vectorCounter - 1])
				{
					var newColumn = GetColumnVectorByNumber(vectorCounter, rowNumber, module);
					result[i] = newColumn;

					for (int j = 2; j < module; ++j)
					{
						var temporalColumn = (newColumn * j) % module;
						mark[GetNumberByColumnVector(temporalColumn, module) - 1] = true;
					}

					++i;
				}

			return result;
		}

		public static int GetNumberByColumnVector(ColumnVector vector, int baseNumber)
		{
			int result = 0, digit = 1;

			for (int i = vector.Count - 1; i >= 0; --i)
			{
				result += vector[i] * digit;
				digit *= baseNumber;
			}

			return result;
		}

		public static ColumnVector GetColumnVectorByNumber(int number, int length, int baseNumber)
		{
			var result = new ColumnVector(length);

			for (int j = length - 1; j >= 0; --j)
			{
				result[j] = number % baseNumber;
				number /= baseNumber;
			}

			return result;
		}

		public static int FindCheckingCharactersNumber(int informationCharactersNumber, int module)
		{
			int result = 1, powers = module;

			while ((powers - 1) / (module - 1) < result + informationCharactersNumber)
			{
				++result;
				powers *= module;
			}

			return result;
		}

		public static bool IsUnitVector(ColumnVector vector)
		{
			int counter = 0;
			for (int i = 0; i < vector.Count; ++i)
				counter += vector[i];

			return counter == 1;
		}

		public static bool IsZeroRowVector(RowVector vector)
		{
			for (int i = 0; i < vector.Count; ++i)
				if (vector[i] > 0)
					return false;

			return true;
		}

		public static int FindErrorPosition(Matrix checkingMatrix, RowVector errorSyndrome, int module)
		{
			if (IsZeroRowVector(errorSyndrome))
				return -1;

			var errorVectors = new RowVector[module - 1];
			for (int i = 1; i < module; ++i)
				errorVectors[i - 1] = (errorSyndrome * i) % module;

			for (int i = 0; i < checkingMatrix.ColumnNumber; ++i)
				for (int j = 0; j < module - 1; ++j)
					if (checkingMatrix[i].GetTransposed() == errorVectors[j])
						return i;

			return -1;
		}
	}
}
