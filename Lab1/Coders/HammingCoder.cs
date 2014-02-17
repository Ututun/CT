using System;
using LinearAlgebra;

namespace Coders
{
	public class HammingCoder : Coder
	{
		Matrix _checkingMatrix;
		int _checkingCharactersNumber;

		public HammingCoder(int informationCharacterNumber)
		{
			_informationCharactersNumber = informationCharacterNumber;
			_checkingCharactersNumber = FindCheckingCharactersNumber(informationCharacterNumber);
			_blockLength = _informationCharactersNumber + _checkingCharactersNumber;

			_checkingMatrix = new Matrix(_checkingCharactersNumber, _blockLength);
			for (int i = 0; i < _blockLength; ++i)
			{
				int temporal = i + 1;
				for (int j = _checkingCharactersNumber - 1; j >= 0; --j)
				{
					_checkingMatrix[j, i] = temporal % 2;
					temporal /= 2;
				}
			}
		}

		private int FindCheckingCharactersNumber(int informationCharacterNumber)
		{
			int result = 1, twoResultPower = 2;

			while (twoResultPower < result + informationCharacterNumber + 1)
			{
				++result;
				twoResultPower *= 2;
			}

			return result;
		}

		public override RowVector Encode(RowVector information)
		{
			var result = new RowVector(_blockLength);

			int counter = 0;
			for (int i = 1; i < _blockLength; i *= 2)
				for (int j = i; j < i * 2 - 1 && j < _blockLength; ++j)
					result[j] = information[counter++];

			counter = _checkingCharactersNumber - 1;
			for (int i = 1; i < _blockLength; i *= 2, --counter)
			{
				for (int j = i; j < _blockLength; ++j)
					if (_checkingMatrix[counter, j] == 1)
						result[i - 1] += result[j];

				result[i - 1] %= 2;
			}

			return result;
		}

		public override RowVector Decode(RowVector cipher)
		{
			throw new NotImplementedException();
		}
	}
}
