using LinearAlgebra;

namespace Coders
{
	class LinearCoder : Coder
	{
		Matrix _codingMatrix, _decodingMatrix;

		sealed public override Vector Encode(Vector information)
		{
			return information * _codingMatrix;
		}

		sealed public override Vector Decode(Vector cipher)
		{
			return cipher * _decodingMatrix;
		}
	}
}
