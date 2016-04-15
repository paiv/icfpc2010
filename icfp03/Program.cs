using System;

namespace icfp03
{
	class Program
	{
		static void Main(string[] args)
		{
			if(args.Length < 2)
			{
				Console.WriteLine("usage: fagen <in> <out> [start [limit]]");

				RunTests();
				return;
			}

			var input = args[0];
			var output = args[1];
			var start = 1;
			var limit = 20;
			if(args.Length > 2)
				start = int.Parse(args[2]);
			if(args.Length > 3)
				limit = int.Parse(args[3]);

			var gen = new FactoryGen(start, limit);
			gen.Generate(input, output);
		}

		private static void RunTests()
		{
			string[,] data = new string[,]
			{
				// {factory, input, output}
				{"6L:6R1L0#6R3L,2L4L0#0R5L,3L3R0#1L3R,0R2R0#2L2R,5L5R0#1R5R,1R4R0#4L4R,X0L0#X0L:6L",
					"01202101210201202", "02120112100002120"},
				{"X:0R0L0#0R0L:X", "01202101210201202", "01202101210201202"},
				{"0L:X0L0#0RX:0R", "01202101210201202", "22120221022022120"},
				{"0R:0LX0#0LX:0R", "01202101210201202", "22022022022022022"},
				{"19L:12R13R0#1R12R,14R0L0#4R9L,9R10R0#3L8L,2L17R0#5L9R,15R1L0#10R13R,3L18R0#6L15L,5L11R0#13L12L,19R16R0#11R8R,2R7R0#11L10L,1R3R0#18L2L,8R4L0#16L2R,8L7L0#15R6R,6R0R0#14L0L,6L4R0#14R0R,12L13L0#17L1L,5R11L0#16R4L,10L15L0#17R7R,14L16L0#18R3R,9L17L0#19R5R,X18L0#X7L:19L",
					"02222220210110011", "11021210112101221"},
				{"19L:12R13R0#1R12R,14R0L0#4R9L,9R10R0#3L8L,2L17R0#5L9R,15R1L0#10R13R,3L18R0#6L15L,5L11R0#13L12L,19R16R0#11R8R,2R7R0#11L10L,1R3R0#18L2L,8R4L0#16L2R,8L7L0#15R6R,6R0R0#14L0L,6L4R0#14R0R,12L13L0#17L1L,5R11L0#16R4L,10L15L0#17R7R,14L16L0#18R3R,9L17L0#19R5R,X18L0#X7L:19L",
					"01202101210201202", "10221220002011011"},
				{"4L:1L3L0#5R1L,0R2L0#0L3L,5R3R0#1R4R,1R4R0#0R2R,X2R0#5L3R,4L0L0#X2L:5L", "01202101210201202", "11021210112101221"},
			};

			for(int i = 0; i < data.GetLength(0); i++)
			{
				var fab = Factory.Parse(data[i, 0]);
				var res = fab.Run(data[i, 1], data[i, 2]);
				if(res != data[i, 2])
				{
					throw new InvalidOperationException(string.Format("Expecting: {0}, got: {1}",
						data[i, 2], res));
				}
			}
		}
	}
}
