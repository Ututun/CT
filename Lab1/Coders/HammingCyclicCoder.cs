using System;
using System.Collections.Generic;
using LinearAlgebra;

namespace Coders
{
	public class HammingCyclicCoder : Coder
	{
		int _checkingCharactersNumber, _module;
		Polynomial _codingPolynomial, _checkingPolynomial;
		List<Polynomial> _checkingPolynomials;
		Matrix _checkingMatrix;

		public HammingCyclicCoder(int informationCharactersNumber, int module)
		{
			_informationCharactersNumber = informationCharactersNumber;
			_module = module;

			_checkingCharactersNumber = HammingCoderAuxiliaryAlgorithms.FindCheckingCharactersNumber(_informationCharactersNumber, _module);

			_blockLength = _informationCharactersNumber + _checkingCharactersNumber;

			FindCheckingPolynomials();
			FindCodingPolynomial();
			FindCheckingMatrix();
		}

		private void FindCheckingMatrix()
		{
			var alpha = new Polynomial { 1 };
			var factor = new Polynomial { 0, 1 };

			_checkingMatrix = new Matrix(_checkingCharactersNumber, _blockLength);
			for (int i = 0; i < _blockLength; ++i)
			{
				for (int j = 0; j < alpha.Count; ++j)
					_checkingMatrix[_checkingCharactersNumber - 1 - j, i] = alpha[j];

				alpha = alpha * factor;
				if (alpha.Degree == _checkingCharactersNumber)
					alpha = (alpha - _codingPolynomial * alpha.LeadingCoefficient) % _module;
			}
		}

		private void FindCheckingPolynomials()
		{
			_checkingPolynomial = new Polynomial((int)Math.Pow(_module, _checkingCharactersNumber) - 1);
			_checkingPolynomial.LeadingCoefficient = 1;
			_checkingPolynomial[0] = -1;

			var _checkingCharactersNumberPrimeDividers = HammingCoderAuxiliaryAlgorithms.FindPrimeDividers(_checkingCharactersNumber);

			_checkingPolynomials = new List<Polynomial>();
			foreach (int divider in _checkingCharactersNumberPrimeDividers)
			{
				var newPolynomial = new Polynomial((int)Math.Pow(_module, _checkingCharactersNumber / divider) - 1);
				newPolynomial.LeadingCoefficient = 1;
				newPolynomial[0] = -1;

				_checkingPolynomials.Add(newPolynomial);
			}
		}

		private void FindCodingPolynomial()
		{
			_codingPolynomial = new Polynomial(_checkingCharactersNumber);

			for (int leadingCoefficient = 1; leadingCoefficient < _module; ++leadingCoefficient)
			{
				_codingPolynomial.LeadingCoefficient = leadingCoefficient;
				for (int freeCoefficient = 1; freeCoefficient < _module; ++freeCoefficient)
				{
					_codingPolynomial[0] = freeCoefficient;
					if (CodingPolynomialIsFinded(1))
						return;
				}
			}
		}

		private bool CodingPolynomialIsFinded(int coefficientIndex)
		{
			if (coefficientIndex == _codingPolynomial.Degree)
				if (IsIrreduciblePolynomial())
					return true;
				else
					return false;


			for (int i = 0; i < _module; ++i)
			{
				_codingPolynomial[coefficientIndex] = i;
				if (CodingPolynomialIsFinded(coefficientIndex + 1))
					return true;
			}

			return false;
		}

		private bool IsIrreduciblePolynomial()
		{
			var zeroPolynomial = new Polynomial { 0 };

			if (Algorithm.GetResidueInZp(_checkingPolynomial, _codingPolynomial, _module) != zeroPolynomial)
				return false;

			foreach (var polynomial in _checkingPolynomials)
				if (Algorithm.GCDInZp(polynomial, _codingPolynomial, _module).Degree > 0)
					return false;

			return true;
		}

		public override RowVector Encode(RowVector information)
		{
			var informationPolynomial = new Polynomial(information);

			var resultPolynomial = (informationPolynomial * _codingPolynomial) % _module;

			return resultPolynomial.GetRowVector(_blockLength);
		}

		public override RowVector Decode(RowVector cipher)
		{
			var cipherPolynomial = new Polynomial(cipher);
			var errorSyndromePolynomial = Algorithm.GetResidueInZp(cipherPolynomial, _codingPolynomial, _module);

			var errorSyndrome = errorSyndromePolynomial.GetRowVector(_checkingCharactersNumber);

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

			cipherPolynomial = new Polynomial(cipher);
			var resultPolynomial = Algorithm.GetQuotientInZp(cipherPolynomial, _codingPolynomial, _module);

			return resultPolynomial.GetRowVector(_informationCharactersNumber);
		}
	}
}
