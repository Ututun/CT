using Coders;
using LinearAlgebra;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var coder = new HammingCyclicCoder(4, 3);

			var info = new RowVector { 2, 1, 0, 2 };

			var cipher = coder.Encode(info);

			cipher[0] = 0;

			var decodedInfo = coder.Decode(cipher);
		}
	}
}
