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

			//MakeMistake(ref cipher, 0);
			//MakeMistake(ref cipher, 1);

			//var decodeInformation = coder.Decode(cipher);

			#endregion

			#region Test2

			var coder = new InterleavingCoder(3, 3);

			var information = new RowVector { 1, 0, 1, 0, 1, 0, 1, 0, 1 };
			var cipher = coder.Encode(information);

			MakeMistake(ref cipher, 7);
			MakeMistake(ref cipher, 8);
			MakeMistake(ref cipher, 9);

			var decodeInformation = coder.Decode(cipher);

			#endregion
		}

		public static void MakeMistake(ref RowVector vector, int index)
		{
			vector[index] = 1 - vector[index];
		}
	}
}
