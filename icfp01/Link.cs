
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
			var s = string.Format("{0}{1}",
				Gate.Id, Place == icfp01.Place.Left ? "L" : "R");
			return s;
		}
	}
}
