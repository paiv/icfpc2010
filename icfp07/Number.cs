using System;
using System.Linq;
using System.Text;

namespace icfp07
{
	internal static class Number
	{
		public static string Simple(int value)
		{
			if(value < 0)
				throw new ArgumentException("", "value");
			switch(value)
			{
			case 0:
				return "0";
			case 1:
				return "10";
			case 2:
				return "11";
			case 3:
				return "12";
			}

			value -= 4;
			if(value < 9)
			{
				return string.Format("220{0}{1}", value / 3, value % 3);
			}
			value -= 9;
			if(value < 81)
			{
				var so = new StringBuilder("0000");
				for(var i = 0; i < 4; i++)
				{
					so[3 - i] = (char)((value % 3) + '0');
					value /= 3;
				}
				return "221" + so.ToString();
			}

			throw new NotImplementedException();
		}
		public static string Quirky(int value)
		{
			if(value < 0)
				throw new ArgumentException("", "value");
			if(value < 2)
				return value.ToString();
			return string.Format("22{0}", Simple(value - 2));
		}

		public static int ParseQuirky(string value, ref int pos)
		{
			AdvanceToNextTrit(value, ref pos);
			var fx = value[pos++];
			switch(fx)
			{
			case '0':
				return 0;
			case '1':
				return 1;
			}

			AdvanceToNextTrit(value, ref pos);
			fx = value[pos++];
			if(fx != '2')
				throw new ArgumentException(string.Format("(1,{0}): expecting 22", pos - 1), "value");

			return ParseSimple(value, ref pos) + 2;
		}

		public static int ParseSimple(string value, ref int pos)
		{
			AdvanceToNextTrit(value, ref pos);
			var fx = value[pos++];
			switch(fx)
			{
			case '0':
				return 0;
			case '1':
				AdvanceToNextTrit(value, ref pos);
				fx = value[pos++];
				return 1 + (fx - '0');
			}

			AdvanceToNextTrit(value, ref pos);
			fx = value[pos++];
			if(fx != '2')
				throw new ArgumentException(string.Format("(1,{0}): expecting 22", pos - 1), "value");

			// FIXME:
			AdvanceToNextTrit(value, ref pos);
			fx = value[pos++];
			var n = 0;
			switch(fx)
			{
			case '0':
				n = 2;
				break;
			case '1':
				n = 4;
				break;
			default:
				throw new ArgumentException(string.Format("(1,{0}): expecting 0 or 1", pos - 1), "value");
			}

			var x = 0;
			for(int i = 0; i < n; i++)
			{
				AdvanceToNextTrit(value, ref pos);
				fx = value[pos++];
				var lo = fx - '0';
				x = x * 3 + lo;
			}

			if(n == 4)
				x += 9;
			return x + 4;
		}

		private static void AdvanceToNextTrit(string value, ref int pos)
		{
			if(string.IsNullOrEmpty(value))
				throw new ArgumentException("", "value");
			SkipSpace(value, ref pos);
			if(pos >= value.Length)
				throw new ArgumentException("unexpected eos", "pos");
		}

		private static void SkipSpace(string value, ref int pos)
		{
			if(value == null)
				return;
			for(; pos < value.Length; pos++)
			{
				switch(value[pos])
				{
				case '0':
				case '1':
				case '2':
					return;
				}
			}
		}

		public static bool ParsePeek(string value, ref int pos)
		{
			if(string.IsNullOrEmpty(value))
				throw new ArgumentException("", "value");
			SkipSpace(value, ref pos);
			return pos < value.Length;
		}
	}
}
