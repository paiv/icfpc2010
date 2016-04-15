
namespace icfp01
{
	class Gate
	{
		private static int _globalid;

		public Gate()
		{
			Id = _globalid++;
		}

		public int Id;
		public Link InL;
		public Link InR;
		public Link OutL;
		public Link OutR;

		public override string ToString()
		{
			/*if(IsExternal)
				return string.Format("X{0}0#X{1}", InR, OutR);

			else*/
				return string.Format("{0}{1}0#{2}{3}", InL, InR, OutL, OutR);
		}

		/*public bool IsExternal
		{
			get
			{
				return (InL == Link.Empty) || (InR == Link.Empty);
			}
		}*/
	}
}
