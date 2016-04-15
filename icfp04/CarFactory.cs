using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace icfp04
{
	class CarFactory
	{
		public static Car Make(bool ismain, string upperPipe, string lowerPipe)
		{
			var car = new Car();
			var chamber = new Chamber();
			chamber.IsMain = ismain;
			chamber.UpperPipe = ParsePipe(upperPipe);
			chamber.LowerPipe = ParsePipe(lowerPipe);
			car.Add(chamber);
			return car;
		}

		public static Car Make(string draft)
		{
			var car = new Car();
			using(var reader = new StringReader(draft))
			{
				while(true)
				{
					var line = reader.ReadLine();
					if(line == null)
						break;
					var parts = line.Split(new char[] { ';' }, 3);
					if(parts == null || parts.Length != 3)
						continue;

					var chamber = new Chamber();
					chamber.IsMain = int.Parse(parts[0]) == 0;
					chamber.UpperPipe = ParsePipe(parts[1]);
					chamber.LowerPipe = ParsePipe(parts[2]);
					car.Add(chamber);
				}
			}
			return car;
		}

		private static int[] ParsePipe(string pipe)
		{
			if(pipe != null)
				pipe = pipe.Trim();
			if(string.IsNullOrEmpty(pipe))
				return new int[0];
			return Array.ConvertAll(pipe.Split(','),
				s => int.Parse(s.Trim())).ToArray();
		}
	}
}
