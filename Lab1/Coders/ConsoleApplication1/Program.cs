using Coders;
using LinearAlgebra;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			var coder = new HammingCyclicCoder(11, 2);
			var cipher = new RowVector { 1, 2, 2, 1, 1, 2, 2 };

			var result = coder.Decode(cipher);
		}
	}
}
