using LinearAlgebra;

namespace Coders
{
    public abstract class Coder
    {
		internal int _informationCharactersNumber, _blockLength;

		abstract public RowVector Encode(RowVector information);
		abstract public RowVector Decode(RowVector cipher);
    }
}
