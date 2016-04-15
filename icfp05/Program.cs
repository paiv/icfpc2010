using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace icfp05
{
	class Program
	{
		private static readonly string INKEY = "012021012102";
		private static int _insize = 50;

		static void Main(string[] args)
		{
			if(args.Length > 0)
			{
				Console.WriteLine("usage: fagup < <stream>");
				return;
			}

			var input = DuplicateInput(INKEY, _insize);
			var list = new Dictionary<Factory, string>();

			while(true)
			{
				var line = Console.ReadLine();
				if(line == null)
					break;
				if(line.Trim().Length <= 0)
					continue;
				var fab = Factory.Parse(line);
				var res = fab.Run(input);
				if(res != null && res.Length > 17)
					res = res.Insert(17, " ");
				list[fab] = res;
			}

			var unique = (from i in list
						 select i.Value).Distinct().ToArray();
			Console.WriteLine("-- unique output:");
			foreach(var s in unique)
				Console.WriteLine("  {0}", s);
			Console.WriteLine();

			Console.WriteLine("-- groups:");
			var grouped = list.GroupBy(pair => pair.Value);
			foreach(var g in grouped)
			{
				Console.WriteLine("  {0}", g.Key);
				foreach(var i in g)
					Console.WriteLine("    {0}", i.Key);
				Console.WriteLine();
			}
		}

		private static string DuplicateInput(string input, int min)
		{
			if(string.IsNullOrEmpty(input))
				return input;
			while(input.Length < min)
				input += input;
			return input;
		}
	}
}
