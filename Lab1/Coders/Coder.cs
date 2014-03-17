using LinearAlgebra;

namespace Coders
{
    public abstract class Coder
    {
		internal int _informationCharactersNumber, _blockLength;

		public int InformationCharactersNumber { get { return _informationCharactersNumber; } }
		public int BlockLength { get { return _blockLength; } }

		abstract public RowVector Encode(RowVector information);
		abstract public RowVector Decode(RowVector cipher);
    }
}
