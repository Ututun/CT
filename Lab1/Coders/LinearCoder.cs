using LinearAlgebra;

namespace Coders
{
	class LinearCoder : Coder
	{
		Matrix _codingMatrix, _decodingMatrix;

		sealed public override RowVector Encode(RowVector information)
		{
			return information * _codingMatrix;
		}

		sealed public override RowVector Decode(RowVector cipher)
		{
			return cipher * _decodingMatrix;
		}
	}
}