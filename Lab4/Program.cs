using LinearAlgebra;

namespace Lab4
{
	class Program
	{
		static void Main()
		{
			#region Test1

			//var coder = new InterleavingCoder(4, 2);

			//var information = new RowVector { 1, 0, 1, 1, 0, 0, 1, 1 };
			//var cipher = coder.Encode(information);

			//cipher[0] = 2 - cipher[0];
			//cipher[1] = 2 - cipher[1];

			//var decodeInformation = coder.Decode(cipher);

			#endregion

			#region Test2

			var coder = new InterleavingCoder(3, 3);

			var information = new RowVector { 1, 0, 1, 0, 1, 0, 1, 0, 1 };
			var cipher = coder.Encode(information);

			cipher[7] = 2 - cipher[7];
			cipher[8] = 2 - cipher[8];
			cipher[9] = 2 - cipher[9];

			var decodeInformation = coder.Decode(cipher);

			#endregion
		}
	}
}
