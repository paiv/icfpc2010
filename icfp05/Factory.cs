using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace icfp05
{
	/// <summary>
	/// фабрика описывается матрицей соединений
	/// 
	/// </summary>
	class Factory
	{
		// [lin,rin,lout,rout]
		// external gate - last
		// link = gateid * 2 + place
		private readonly int[,] _gates;

		// id last - input
		// offset last - output
		public Factory(int[] gates)
		{
			if(gates == null)
				throw new ArgumentNullException("gates");
			_gates = Normalize(gates);
		}
		public Factory(int[,] gates)
		{
			if(gates == null)
				throw new ArgumentNullException("gates");
			_gates = gates;
		}

		public override string ToString()
		{
			if(_gates == null)
				return "(null)";

			var so = new StringBuilder();

			var xgate = _gates.GetLength(0) - 1;
			so.AppendFormat("{0}:", FormatLink(_gates[xgate, 2], xgate));
			//so.AppendLine();

			for(int i = 0; i < xgate; i++)
			{
				so.AppendFormat("{0}{1}0#{2}{3},",
					FormatLink(_gates[i, 0], xgate),
					FormatLink(_gates[i, 1], xgate),
					FormatLink(_gates[i, 2], xgate),
					FormatLink(_gates[i, 3], xgate));
				//so.AppendLine();
			}

			so.Length -= 1;
			so.Append(":");
			//so.AppendLine();
			so.AppendFormat("{0}", FormatLink(_gates[xgate, 0], xgate));
			//so.AppendLine();

			return so.ToString();
		}

		private string FormatLink(int id, int xgate)
		{
			if(id / 2 == xgate)
				return "X";
			return string.Format("{0}{1}", id / 2, id % 2 == 0 ? "L" : "R");
		}

		private int[,] Normalize(int[] gates)
		{
			if(gates == null)
				return null;

			// [lin,rin,lout,rout]
			// external gate - last
			// link = gateid * 2 + place
			int[,] list = new int[gates.Length / 2 + 1, 4];
			var xgate = gates.Length / 2;
			list[xgate, 0] = -1;
			list[xgate, 1] = -1;
			list[xgate, 2] = -1;
			list[xgate, 3] = -1;

			for(int i = 0; i < gates.Length / 2; i++)
			{
				var sourceGate = gates[i * 2 + 0];
				list[i, 0] = sourceGate;
				list[sourceGate / 2, (sourceGate % 2) + 2] = i * 2;

				sourceGate = gates[i * 2 + 1];
				list[i, 1] = sourceGate;
				list[sourceGate / 2, (sourceGate % 2) + 2] = i * 2 + 1;
			}

			var lastGate = gates[gates.Length - 1];
			list[xgate, 0] = lastGate;
			list[lastGate / 2, (lastGate % 2) + 2] = xgate * 2;

			return list;
		}

		public string Run(string input)
		{
			return Run(input, null);
		}

		public string Run(string input, string expect)
		{
			if(string.IsNullOrEmpty(input))
				throw new ArgumentException("", "input");

			// [lin,rin,lout,rout]
			// external gate - last
			// link = gateid * 2 + place
			var values = new int[_gates.GetLength(0), _gates.GetLength(1)];
			var so = new StringBuilder(input.Length);

			for(int i = 0; i < input.Length; i++)
			{
				var c = input[i];
				switch(c)
				{
				case '0':
				case '1':
				case '2':
					break;
				default:
					continue;
				}

				var x = c - '0';
				var y = ExecuteFactory(_gates, values, x);
				c = (char)('0' + y);
				so.Append(c);

				if(expect != null)
				{
					if(expect[i] != c)
						break;
				}
			}

			return so.ToString();
		}

		private int ExecuteFactory(int[,] gates, int[,] state, int input)
		{
			int link;
			var xgate = gates.GetLength(0) - 1;
			state[xgate, 2] = input;
			for(int i = 0; i < xgate; i++)
			{
				link = gates[i, 0];
				state[i, 0] = state[link / 2, link % 2 + 2];
				link = gates[i, 1];
				state[i, 1] = state[link / 2, link % 2 + 2];

				// compute gate
				state[i, 2] = opL(state[i, 0], state[i, 1]);
				state[i, 3] = opR(state[i, 0], state[i, 1]);
			}

			link = gates[xgate, 0];
			var res = state[link / 2, link % 2 + 2];
			state[xgate, 0] = res;
			return res;
		}

		private static readonly int[,] Ltable = new int[,]
		{
			{0, 2, 1},
			{1, 0, 2},
			{2, 1, 0},
		};
		private int opL(int inL, int inR)
		{
			return Ltable[inL, inR];
		}

		private static readonly int[,] Rtable = new int[,]
		{
			{2, 2, 2},
			{2, 0, 1},
			{2, 1, 0},
		};
		private int opR(int inL, int inR)
		{
			return Rtable[inL, inR];
		}

		public static Factory Parse(string value)
		{
			var list = new List<string>(ParseLinks(value));
			if(list.Count < 2)
				throw new ArgumentException("Invalid factory: " + value, "value");

			var gates = new int[list.Count / 4 + 1, 4];
			var xgate = gates.GetLength(0) - 1;

			var Xin = ParseLink(list[0], xgate);
			gates[gates.GetLength(0) - 1, 2] = Xin;

			for(int i = 1; i < list.Count - 1; i++)
			{
				var id = (i - 1) / 4;
				var place = (i - 1) % 4;

				var link = ParseLink(list[i], xgate);
				gates[id, place] = link;
			}

			var Xout = ParseLink(list[list.Count - 1], xgate);
			gates[gates.GetLength(0) - 1, 0] = Xout;

			var fab = new Factory(gates);
			return fab;
		}

		private static int ParseLink(string value, int xgate)
		{
			if(value == "X")
				return xgate * 2;
			var place = (value[value.Length - 1] == 'R') ? 1 : 0;
			value = value.TrimEnd('R', 'L');
			var id = int.Parse(value);
			var link = id * 2 + place;
			return link;
		}

		private static IEnumerable<string> ParseLinks(string value)
		{
			var rx = new Regex(@"(X|\d+(?:R|L))");
			var match = rx.Match(value);
			while(match.Success)
			{
				for(int i = 1; i < match.Groups.Count; i++)
				{
					var group = match.Groups[i];
					foreach(Capture c in group.Captures)
					{
						var s = c.Value;
						yield return s;
					}
				}
				match = match.NextMatch();
			}
		}
	}
}
