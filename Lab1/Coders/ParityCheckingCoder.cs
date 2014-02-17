using System;
using LinearAlgebra;

namespace Coders
{
	public class ParityBitException : Exception { }

	public class ParityCheckingCoder : Coder
	{
		public ParityCheckingCoder(int informationCharacterNumber)
		{
			_informationCharactersNumber = informationCharacterNumber;
			_blockLength = informationCharacterNumber + 1;
		}

		int CalculateParityBit(RowVector information)
		{
			int result = 0;

			for (int i = 0; i < _informationCharactersNumber; ++i)
				result += information[i];
			
			return result % 2;
		}

		public override RowVector Encode(RowVector information)
		{
			var result = new RowVector(_blockLength);
			int parityNumber = CalculateParityBit(information);

			for (int i = 0; i < _informationCharactersNumber; ++i)
				result[i] = information[i];

			result[_informationCharactersNumber] = parityNumber;

			return result;			
		}

		public override RowVector Decode(RowVector cipher)
		{
			var result = new RowVector(_informationCharactersNumber);
			int parityNumber = CalculateParityBit(cipher);

			if (parityNumber == cipher[_informationCharactersNumber])
				for (int i = 0; i < _informationCharactersNumber; ++i)
					result[i] = cipher[i];
			else
				throw new ParityBitException();

			return result;
		}
	}
}
