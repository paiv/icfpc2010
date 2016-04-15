using System;
using System.Collections.Generic;
using System.Text;

namespace icfp01
{
	class Program
	{
		static void Main(string[] args)
		{
			var steps = 17;

			var list = new List<Gate>();
			var worker = new Gate();
			var root = new Gate();

			list.Add(worker);
			list.Add(root);

			MakeLink(root, Place.Left, worker, Place.Right);

			Gen(list, root, steps);

			var external = new Gate();
			external.InL = Link.Empty;
			external.OutL = Link.Empty;
			MakeLink(external, Place.Right, worker, Place.Left);
			MakeLink(worker, Place.Right, external, Place.Right);
			list.Add(external);

			LinkRandomly(list);

			Print(list);
		}

		private static void LinkRandomly(List<Gate> list)
		{
			foreach(var gate in list)
			{
				if(gate.OutL == null)
					LinkToFirstAvailable(list, gate, Place.Left);
				if(gate.OutR == null)
					LinkToFirstAvailable(list, gate, Place.Right);
			}
		}

		private static void LinkToFirstAvailable(List<Gate> list, Gate gate, Place place)
		{
			Gate gateTo;
			Place placeTo;
			if(FindFirstAvailable(list, gate, out gateTo, out placeTo))
				MakeLink(gate, place, gateTo, placeTo);
		}

		private static bool FindFirstAvailable(List<Gate> list, Gate gate, out Gate gateTo, out Place placeTo)
		{
			foreach(var item in list)
			{
				//if(item == gate)
				//    continue;
				if(item.InL == null)
				{
					gateTo = item;
					placeTo = Place.Left;
					return true;
				}
				if(item.InR == null)
				{
					gateTo = item;
					placeTo = Place.Right;
					return true;
				}
			}

			gateTo = null;
			placeTo = Place.Left;
			return false;
		}

		private static void MakeLink(Gate gate, Place place, Gate gateTo, Place placeTo)
		{
			var linkTo = new Link(gateTo, placeTo);
			if(place == Place.Left)
				gate.OutL = linkTo;
			else
				gate.OutR = linkTo;

			var linkBack = new Link(gate, place);
			if(placeTo == Place.Left)
				gateTo.InL = linkBack;
			else
				gateTo.InR = linkBack;
		}

		private static void Print(List<Gate> list)
		{
			var total = list.Count;
			var so = new StringBuilder();
			so.AppendFormat("{0}L:", total - 1);
			so.AppendLine();
			foreach(var gate in list)
			{
				if(gate.IsExternal)
					so.AppendFormat("{0}:", gate);
				else
					so.AppendFormat("{0},", gate);
				so.AppendLine();
			}
			so.AppendFormat("{0}L", total - 1);
			so.AppendLine();
			Console.WriteLine(so.ToString());
		}

		static void Gen(List<Gate> list, Gate source, int step)
		{
			if(step <= 0)
				return;

			var a = new Gate();
			var b = new Gate();

			list.Add(a);
			list.Add(b);

			a.OutL = new Link(source, Place.Left);
			b.OutL = new Link(source, Place.Right);

			source.InL = new Link(a, Place.Left);
			source.InR = new Link(b, Place.Left);

			Gen(list, a, step - 1);
			Gen(list, b, step - 1);
		}
	}
}
