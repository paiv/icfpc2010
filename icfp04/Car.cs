using System;
using System.Collections.Generic;
using System.Text;

namespace icfp04
{
	public class Car
	{
		private readonly List<Chamber> _chambers = new List<Chamber>();

		public void Add(Chamber chamber)
		{
			_chambers.Add(chamber);
		}

		public override string ToString()
		{
			var so = new StringBuilder();
			so.AppendFormat("{0}", Number.Quirky(_chambers.Count));
			foreach(var chamber in _chambers)
			{
				FormatPipe(so, chamber.UpperPipe);
				so.Append(chamber.IsMain ? "0" : "10");
				FormatPipe(so, chamber.LowerPipe);
			}
			return so.ToString();
		}

		private void FormatPipe(StringBuilder so, int[] pipe)
		{
			so.AppendFormat("{0}", Number.Quirky(pipe.Length));
			foreach(var id in pipe)
				so.AppendFormat("{0}", Number.Simple(id));
		}

		public string ToJson()
		{
			var so = new StringBuilder();
			so.Append('{');
			foreach(var chamber in _chambers)
			{
				so.Append(chamber.IsMain ? "main" : "aux");
				so.Append(": {upper: ");
				FormatJsonArray(so, chamber.UpperPipe);
				so.Append(", lower: ");
				FormatJsonArray(so, chamber.LowerPipe);
				so.Append("},");
			}
			so.Length--;
			so.Append('}');
			return so.ToString();
		}

		private void FormatJsonArray(StringBuilder so, int[] list)
		{
			so.Append('[');
			foreach(var i in list)
				so.AppendFormat("{0},", i);
			if(list.Length > 0)
				so.Length--;
			so.Append(']');
		}

		public static Car Parse(string value)
		{
			var car = new Car();
			int pos = 0;
			var n = Number.ParseQuirky(value, ref pos);
			for(int i = 0; i < n; i++)
			{
				var chamber = new Chamber();
				chamber.UpperPipe = ParsePipe(value, ref pos);
				chamber.IsMain = Number.ParseSimple(value, ref pos) == 0;
				chamber.LowerPipe = ParsePipe(value, ref pos);
				car.Add(chamber);
			}
			if(Number.ParsePeek(value, ref pos))
				throw new ArgumentException(string.Format("(1,{0}): expecting eos", pos), "value");
			return car;
		}

		private static int[] ParsePipe(string value, ref int pos)
		{
			var s = Number.ParseQuirky(value, ref pos);
			var list = new int[s];
			for(int i = 0; i < s; i++)
				list[i] = Number.ParseSimple(value, ref pos);
			return list;
		}

		public bool StartEngine(string fuel)
		{
			var bin = Fuel.Parse(fuel);
			return false;
		}
	}
}
