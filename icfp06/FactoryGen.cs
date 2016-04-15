using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace icfp06
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

		public void Generate(string input, string output)
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
				Console.Write("{0}", factory);
				//var res = factory.Run(input, output);
				//if(res == output)
				//{
				//    Console.Write("{0}", factory);
				//    //return true;
				//}
			}
			return false;
		}
	}
}
