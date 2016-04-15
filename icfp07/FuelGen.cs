using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace icfp07
{
	class FuelGen
	{
		private static readonly string PREFIX = "11021210112101221 ";

		public void Generate()
		{
			//int[,] mx1 = new int[,]
			//{
			//    {1,2,3},
			//    {3,2,1},
			//    {2,1,3},
			//};
			int[,] mx0 = new int[,]
			{
				{3, 1},
				{2, 1},
			};
			int[,] mx1 = new int[,]
			{
				{2, 1},
				{1, 2},
			};
			int[,] mx2 = new int[,]
			{
				{1, 1},
				{3, 3},
			};

			var s = FormatFuel(mx1, mx1, mx2);
			Console.WriteLine("{0}", s);
		}

		public string FormatFuel(int[,] chamber0)
		{
			var chambers = new List<int[,]>();
			chambers.Add(chamber0);
			return FormatFuel(chambers);
		}
		public string FormatFuel(int[,] chamber0, int[,] chamber1, int[,] chamber2)
		{
			var chambers = new List<int[,]>();
			chambers.Add(chamber0);
			chambers.Add(chamber1);
			chambers.Add(chamber2);
			return FormatFuel(chambers);
		}

		private string FormatFuel(List<int[,]> chambers)
		{
			var so = new StringBuilder();
			so.Append(PREFIX);
			so.AppendFormat("{0}", Number.Quirky(chambers.Count));
			foreach(var chamber in chambers)
			{
				so.AppendFormat("{0}", Number.Quirky(chamber.GetLength(0)));
				for(int i = 0; i < chamber.GetLength(0); i++)
				{
					so.AppendFormat("{0}", Number.Quirky(chamber.GetLength(0)));
					for(int k = 0; k < chamber.GetLength(1); k++)
						so.AppendFormat("{0}", Number.Simple(chamber[i, k]));
				}
			}
			return so.ToString();
		}
	}
}
