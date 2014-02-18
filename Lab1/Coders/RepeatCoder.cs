using System;
using LinearAlgebra;
using System.Collections.Generic;

namespace Coders
{
	public class IncorrectInformationRowVectorLengthException : Exception { }

	public class RepeatCoder : Coder
	{
		int _fixableErrorsNumber, _repeatNumber;

		public RepeatCoder(int informationCharacterNumber, int fixableErrorsNumber)
		{
			_fixableErrorsNumber = fixableErrorsNumber;
			_repeatNumber = 2 * fixableErrorsNumber + 1;
			_informationCharactersNumber = informationCharacterNumber;
			_blockLength = _repeatNumber * _informationCharactersNumber;
		}

		public override RowVector Encode(RowVector information)
		{
			if (information.Count != _informationCharactersNumber)
				throw new IncorrectInformationRowVectorLengthException();

			var result = new RowVector(_blockLength);

			for (int i = 0; i < _informationCharactersNumber; ++i)
				for (int j = 0; j < _repeatNumber; ++j)
					result[i + j * _informationCharactersNumber] = information[i];

			return result;
		}

		public override RowVector Decode(RowVector cipher)
		{
			var result = new RowVector(_informationCharactersNumber);
			var countingDictionary = new Dictionary<int, int>();

			for (int i = 0; i < _informationCharactersNumber; ++i)
			{
				countingDictionary.Clear();
				for (int j = 0; j < _repeatNumber; ++j) 
				{
					int key = cipher[i + j * _informationCharactersNumber];
					if (countingDictionary.ContainsKey(key))
						++countingDictionary[key];
					else
						countingDictionary.Add(key, 1);
				}

				int decodedNumber = 0;
				foreach (int key in countingDictionary.Keys)
				{
					if (countingDictionary[key] > _repeatNumber / 2)
					{
						decodedNumber = key;
						break;
					}
				}

				result[i] = decodedNumber;
			}
			
			return result;
		}
	}
}
