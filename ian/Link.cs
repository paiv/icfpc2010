
namespace icfp01
{
	class Link
	{
		private Link()
		{

		}
		public Link(Gate gate, Place place)
		{
			Gate = gate;
			Place = place;
		}

		public static Link Empty = new Link();

		public Gate Gate;
		public Place Place;

		public override string ToString()
		{
			if (Gate == null)
				return "X";
			else
				return string.Format("{0}{1}", Gate.Id, Place == Place.Left ? "L" : "R");
		}
	}
}
