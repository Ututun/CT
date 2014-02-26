using System;
using LinearAlgebra;

namespace Coders
{
	public class HammingCoder : Coder
	{
		Matrix _checkingMatrix;
		int _checkingCharactersNumber, _module;

		public HammingCoder(int informationCharactersNumber, int module)
		{
			_informationCharactersNumber = informationCharactersNumber;
			_module = module;

			_checkingCharactersNumber = HammingCoderAuxiliaryAlgorithms.FindCheckingCharactersNumber(_informationCharactersNumber, _module);
			_blockLength = _informationCharactersNumber + _checkingCharactersNumber;
			_checkingMatrix = HammingCoderAuxiliaryAlgorithms.FindCheckingMatrix(_checkingCharactersNumber, _blockLength, _module);
		}

		public override RowVector Encode(RowVector information)
		{
			var result = new RowVector(_blockLength);

			int counter = 0;
			for (int i = 0; i < _blockLength; ++i)
				if (!HammingCoderAuxiliaryAlgorithms.IsUnitVector(_checkingMatrix[i]))
					result[i] = information[counter++];

			counter = _checkingCharactersNumber - 1;
			for (int i = 0; i < _blockLength; ++i)
				if (HammingCoderAuxiliaryAlgorithms.IsUnitVector(_checkingMatrix[i]))
				{
					for (int j = i + 1; j < _blockLength; ++j)
						if (_checkingMatrix[counter, j] != 0)
							result[i] += result[j] * (_module - _checkingMatrix[counter, j]);

					result[i] %= _module;
					--counter;
				}

			return result;
		}

		public override RowVector Decode(RowVector cipher)
		{
			var errorSyndrome = (cipher * _checkingMatrix.GetTransposed()) % _module;

			int errorPosition = HammingCoderAuxiliaryAlgorithms.FindErrorPosition(_checkingMatrix, errorSyndrome, _module);

			if (errorPosition >= 0)
			{
				for (int i = 1; i < _module; ++i)
					if (HammingCoderAuxiliaryAlgorithms.IsZeroRowVector(((_checkingMatrix[errorPosition].GetTransposed() * i) + errorSyndrome) % _module))
					{
						cipher[errorPosition] = (cipher[errorPosition] + i) % _module;
						break;
					}
			}

			var result = new RowVector(_informationCharactersNumber);
			int counter = 0;
			for (int i = 0; i < _blockLength; ++i)
				if (!HammingCoderAuxiliaryAlgorithms.IsUnitVector(_checkingMatrix[i]))
					result[counter++] = cipher[i];

			return result;
		}
	}
}
