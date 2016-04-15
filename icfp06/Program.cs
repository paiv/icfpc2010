using System;

namespace icfp06
{
	class Program
	{
		private static readonly string INKEY = "012021012102";

		static void Main(string[] args)
		{
			if(args.Length < 2)
			{
				Console.WriteLine("usage: facir <out> [start [limit]]");

				RunTests();
				return;
			}

			var output = args[0];
			var start = 7;
			var limit = 20;
			if(args.Length > 1)
				start = int.Parse(args[1]); 
			if(args.Length > 2)
				limit = int.Parse(args[2]);
			var input = DuplicateInput(INKEY, output.Length);

			var gen = new FactoryGen(start, limit);
			gen.Generate(input, output);
		}

		private static string DuplicateInput(string input, int min)
		{
			if(string.IsNullOrEmpty(input))
				return input;
			while(input.Length < min)
				input += input;
			return input;
		}

		private static void RunTests()
		{
		}
	}
}
