using Coders;
using LinearAlgebra;

namespace Lab4
{
	public class InterleavingCoder
	{
		int _interleavingNumber;
		HammingCyclicCoder coder;

		public InterleavingCoder(int informationCharactersNumber, int interleavingNumber)
		{
			_interleavingNumber = interleavingNumber;
			coder = new HammingCyclicCoder(informationCharactersNumber, 2);
		}

		public RowVector Encode(RowVector information)
		{
			var result = new RowVector(coder.BlockLength * _interleavingNumber);

			for (int i = 0; i < _interleavingNumber; ++i)
			{
				var informationPart = information.GetPart(i * coder.InformationCharactersNumber, coder.InformationCharactersNumber);

				var encodeInformationPart = coder.Encode(informationPart);

				for (int j = 0; j < coder.BlockLength; ++j)
					result[i + j * _interleavingNumber] = encodeInformationPart[j];
			}

			return result;
		}

		public RowVector Decode(RowVector cipher)
		{
			var result = new RowVector(coder.InformationCharactersNumber * _interleavingNumber);

			for (int i = 0; i < _interleavingNumber; ++i)
			{
				var cipherPart = new RowVector();

				for (int j = 0; j < coder.BlockLength; ++j)
					cipherPart.Add(cipher[i + j * _interleavingNumber]);

				var decodeCipherPart = coder.Decode(cipherPart);

				for (int j = 0; j < coder.InformationCharactersNumber; ++j)
					result[i * coder.InformationCharactersNumber + j] = decodeCipherPart[j];
			}

			return result;
		}
	}
}
