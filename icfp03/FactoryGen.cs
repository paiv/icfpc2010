using System;
using System.Collections.Generic;

namespace icfp03
{
	class FactoryGen
	{
		private int _start;
		private int _deep;

		public FactoryGen(int deep)
			: this(1, deep)
		{
		}

		public FactoryGen(int start, int limit)
		{
			if(start > limit)
				throw new ArgumentException("", "limit");
			_start = start;
			_deep = limit;
		}

		internal void Generate(string input, string output)
		{
			for(int i = _start; i <= _deep; i++)
			{
				Console.WriteLine(": trying {0:G2} gates ----", i);
				if(TryOn(i, input, output))
					break;
			}
		}

		private bool TryOn(int n, string input, string output)
		{
			foreach(var factory in EmitFactories(n))
			{
				//Console.Write("{{ {0} }}", factory);
				var res = factory.Run(input, output);
				var b = res == output;
				var s = b ? "match!" : "fail";
				//Console.Write(" {0} --", res);
				//Console.WriteLine(" {0}", s);
				if(b)
				{
					Console.Write("{{ {0} }}", factory);
					Console.Write(" {0} --", res);
					Console.WriteLine(" {0}", s);
					//return true;
				}
			}
			return false;
		}

		private IEnumerable<Factory> EmitFactories(int n)
		{
			// потоки - выходные коннекторы гейтов, плюс входной поток Xin
			for(var p = new Permutation(n * 2 + 1);
				p != null;
				p = p.Successor())
			{
				var config = p.Get();

				if(ValidFactory(config))
					yield return new Factory(config);
			}
		}

		private bool ValidFactory(int[] config)
		{
			// external gate self-linked
			if(config[config.Length - 1] == config.Length - 1)
				return false;
			// other self-linked gates
			for(int i = 0; i < config.Length - 1; i += 2)
			{
				var x = config[i];
				var y = config[i + 1];
				var diff = x - y;
				if(x % 2 == 0 && y - x == 1)
					return false;
				if(x % 2 != 0 && x - y == 1)
					return false;
			}

			return true;
		}
	}
}
