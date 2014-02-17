using System;
using LinearAlgebra;

namespace Coders
{
	public class SyndromeException : Exception { }

	public class HammingCoder : Coder
	{
		Matrix _checkingMatrix;
		int _checkingCharactersNumber, _module;

		public HammingCoder(int informationCharactersNumber, int module)
		{
			_informationCharactersNumber = informationCharactersNumber;
			_module = module;

			FindCheckingCharactersNumber();
			_blockLength = _informationCharactersNumber + _checkingCharactersNumber;
			FindCheckingMatrix();
		}

		private void FindCheckingMatrix()
		{
			_checkingMatrix = new Matrix(_checkingCharactersNumber, _blockLength);
			var mark = new bool[(int) Math.Pow(_module, _checkingCharactersNumber) - 1];

			for (int i = 0, vectorCounter = 1; i < _blockLength; ++vectorCounter)
				if (!mark[vectorCounter - 1])
				{
					var newColumn = GetColumnVectorByNumber(vectorCounter);
					_checkingMatrix[i] = newColumn;

					for (int j = 2; j < _module; ++j)
					{
						var temporalColumn = (newColumn * j) % _module;
						mark[GetNumberByColumnVector(temporalColumn) - 1] = true;
					}

					++i;
				}
		}

		private ColumnVector GetColumnVectorByNumber(int number)
		{
			var result = new ColumnVector(_checkingCharactersNumber);

			for (int j = _checkingCharactersNumber - 1; j >= 0; --j)
			{
				result[j] = number % _module;
				number /= _module;
			}

			return result;
		}

		private int GetNumberByColumnVector(ColumnVector vector)
		{
			int result = 0, digit = 1;

			for (int i = vector.Height - 1; i >= 0; --i)
			{
				result += vector[i] * digit;
				digit *= _module;
			}

			return result;
		}

		private void FindCheckingCharactersNumber()
		{
			int result = 1, powers = _module;

			while ((powers - 1) / (_module - 1) < result + _informationCharactersNumber)
			{
				++result;
				powers *= _module;
			}

			_checkingCharactersNumber = result;
		}

		public override RowVector Encode(RowVector information)
		{
			var result = new RowVector(_blockLength);

			int counter = 0;
			for (int i = 0; i < _blockLength; ++i)
				if (!IsCheckingCharacter(i))
					result[i] = information[counter++];

			counter = _checkingCharactersNumber - 1;
			for (int i = 0; i < _blockLength; ++i)
				if (IsCheckingCharacter(i))
				{
					for (int j = i + 1; j < _blockLength; ++j)
						if (_checkingMatrix[counter, j] != 0)
							result[i] += result[j] * (_module - _checkingMatrix[counter, j]);

					result[i] %= _module;
					--counter;
				}

			return result;
		}

		private bool IsCheckingCharacter(int index)
		{
			int counter = 0;
			for (int i = 0; i < _checkingCharactersNumber; ++i)
				counter += _checkingMatrix[i, index];

			return counter == 1;
		}

		private bool IsZeroRowVector(RowVector vector)
		{
			for (int i = 0; i < vector.Length; ++i)
				if (vector[i] > 0)
					return false;

			return true;
		}

		public override RowVector Decode(RowVector cipher)
		{
			var errorSyndrome = (cipher * _checkingMatrix.GetTransposed()) % _module;

			int errorPosition = FindErrorPosition(errorSyndrome);

			if (errorPosition >= 0)
			{
				for (int i = 1; i < _module; ++i)
					if (IsZeroRowVector(((_checkingMatrix[errorPosition].GetTransposed() * i) + errorSyndrome) % _module))
					{
						cipher[errorPosition] = (cipher[errorPosition] + i) % _module;
						break;
					}
			}

			var result = new RowVector(_informationCharactersNumber);
			int counter = 0;
			for (int i = 0; i < _blockLength; ++i)
				if (!IsCheckingCharacter(i))
					result[counter++] = cipher[i];

			return result;
		}

		private int FindErrorPosition(RowVector errorSyndrome)
		{
			var errorVectors = new RowVector[_module - 1];
			for (int i = 1; i < _module; ++i)
				errorVectors[i - 1] = (errorSyndrome * i) % _module;

			for (int i = 0; i < _blockLength; ++i)
				for (int j = 0; j < _module - 1; ++j)
					if (_checkingMatrix[i].GetTransposed() == errorVectors[j])
						return i;

			return -1;
		}
	}
}
