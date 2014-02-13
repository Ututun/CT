using LinearAlgebra;

namespace Coders
{
    abstract class Coder
    {
		int _informationCharacterNumber, _blockLength;

		abstract public Vector Encode(Vector information);
		abstract public Vector Decode(Vector cipher);
    }
}
