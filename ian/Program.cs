using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace icfp01
{
	class Program
	{


		static void Main(string[] args)
		{

		if(args.Length < 1)
		{
			Console.WriteLine("usage: xx <target>");
			return;
		}
		int[] target = ParseTarget(args[0]);

			ArrayList list = new ArrayList();
			//Gate root = new Gate();

			//list.Add(root);

			//MakeLink(root, Place.Left, worker, Place.Right);
			//MakeLink(root2, Place.Left, worker, Place.Left);

			//Gen0Tree(list, root, steps);

// 			Gate external = new Gate();
// 			external.InL = Link.Empty;
// 			external.OutL = Link.Empty;
// 			extIn.InL = Link.Empty;
			//extIn.OutL = Link.Empty;
// 			extOut.OutR = Link.Empty;
			//extOut.OutL = Link.Empty;
			//root.OutL = Link.Empty;
			////MakeLink(external, Place.Right, worker, Place.Left);
			//MakeLink(worker, Place.Left, external, Place.Right);
			//MakeLink(root, Place.Left, external, Place.Right);
// 			MakeLink(root3,    Place.Left, gen_of_1, Place.Left);
// 			MakeLink(gen_of_2_n2, Place.Right, gen_of_1_n2, Place.Right);
// 			MakeLink(root4,       Place.Left,  gen_of_1_n2, Place.Left);
// 			MakeLink(gen_of_1,    Place.Left, extOut, Place.Right);
// 			MakeLink(gen_of_1_n2, Place.Left, extOut, Place.Left);
			//list.Add(external);
// 			list.Add(gen_of_1_n2);
// 			list.Add(extIn);
// 			list.Add(extOut);

//			int[] target = {
//				1,1,0,2,1,2,1,0,1,1,2,1,0,1,2,2,1,/*end of prefix*/
				//2,2,1,0, 2,2,0, 2,2,0, 1,0, 0, 2,2,0, 0, 0, 2,2,0, 2,2,0, 1,0, 1,1, 2,2,0, 0, 1,0,  2,2,0, 2,2,0, 1,0, 0, 2,2,0, 1,1, 1,0};
//				2,2,0, 1, 1, 1,1, 1, 1, 1/*,0*/};
				//1, 1, 1, 1};

			int nsteps = target.Length;
			Gate lastElement = null, firstElement = null;
			foreach (int tval in target)
			{
				Gate genIn, genOut;
				switch (tval)
				{
					case 0:
						Gen0       (list, out genIn, out genOut, nsteps);
						break;
					case 1:
						Strobe2Gen0(list, out genIn, out genOut, nsteps);
						break;
					default:
						Strobe1Gen0(list, out genIn, out genOut, nsteps);
						break;
				}
				Gate lineElement = new Gate();
				list.Add(lineElement);
				if (firstElement == null)
					firstElement = lineElement;
				if (lastElement != null)
					MakeLink(lineElement, Place.Left, lastElement, Place.Left);
				MakeLink(genOut, Place.Left, lineElement, Place.Right);
				lastElement = lineElement;
				--nsteps;
			}
			firstElement.OutL = Link.Empty;

			Gate inGate = new Gate();
			list.Add(inGate);
			inGate.InL = Link.Empty;
			MakeLink(inGate, Place.Left, lastElement, Place.Left);
			/*Gate inGate, outGate;
			Strobe2Gen0(list, out inGate, out outGate, 5);*/
			//BackWiredRepeater(list, out inGate, out outGate);

 			/*outGate.OutL = Link.Empty;*/

			LinkRandomly(list);

			Print(list, inGate, firstElement);
		}

		private static void LinkRandomly(ArrayList list)
		{
			foreach(Gate gate in list)
			{
				if(gate.OutL == null)
					LinkToFirstAvailable(list, gate, Place.Left);
				if(gate.OutR == null)
					LinkToFirstAvailable(list, gate, Place.Right);
			}
		}

		private static void LinkToFirstAvailable(ArrayList list, Gate gate, Place place)
		{
			Gate gateTo;
			Place placeTo;
			if(FindFirstAvailable(list, gate, out gateTo, out placeTo))
				MakeLink(gate, place, gateTo, placeTo);
		}

		private static bool FindFirstAvailable(ArrayList list, Gate gate, out Gate gateTo, out Place placeTo)
		{
			foreach(Gate item in list)
			{
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
			Link linkTo = new Link(gateTo, placeTo);
			if(place == Place.Left)
			{
				if (gate.OutL!=null)
					throw new System.InvalidOperationException();
				gate.OutL = linkTo;
			}
			else
			{
				if (gate.OutR!=null)
					throw new System.InvalidOperationException();
				gate.OutR = linkTo;
			}

			Link linkBack = new Link(gate, place);
			if(placeTo == Place.Left)
			{
				if (gateTo.InL!=null)
					throw new System.InvalidOperationException();
				gateTo.InL = linkBack;
			}
			else
			{
				if (gateTo.InR!=null)
					throw new System.InvalidOperationException();
				gateTo.InR = linkBack;
			}
		}

		private static void Print(ArrayList list, Gate extIn, Gate extOut)
		{
			int total = list.Count;
			StringBuilder so = new StringBuilder();
			char inputConnector, outputConnector;
			if (extIn.InL == Link.Empty)
				inputConnector = 'L';
			else
				inputConnector = 'R';
			if (extOut.OutL == Link.Empty)
				outputConnector = 'L';
			else
				outputConnector = 'R';
			so.AppendFormat("{0}{1}:", extIn.Id, inputConnector);
			so.Append('\n');
			foreach(Gate gate in list)
			{
				so.AppendFormat("{0},", gate);
				so.Append('\n');
			}
			so.Remove(so.Length-2,2);
			so.Append(":\n");
			so.AppendFormat("{0}{1}", extOut.Id, outputConnector);
			so.Append('\n');
			Console.WriteLine(so.ToString());
		}

		static void Gen0Tree(ArrayList list, Gate source, int step)
		{
			if(step <= 0)
				return;

			Gate a = new Gate();
			Gate b = new Gate();

			list.Add(a);
			list.Add(b);

			a.OutL = new Link(source, Place.Left);
			b.OutL = new Link(source, Place.Right);

			source.InL = new Link(a, Place.Left);
			source.InR = new Link(b, Place.Left);

			Gen0Tree(list, a, step - 1);
			Gen0Tree(list, b, step - 1);
		}
		static void BackWiredRepeater(ArrayList list, out Gate inGate, out Gate outGate)
		{
			Gate rep1 = new Gate();
			list.Add(rep1);
			Gate rep2 = new Gate();
			list.Add(rep2);
			Gate loop = new Gate();
			list.Add(loop);
			MakeLink(loop, Place.Left,  rep1, Place.Right);
			MakeLink(loop, Place.Right, rep2, Place.Right);
			MakeLink(rep1, Place.Right, loop, Place.Left);
			MakeLink(rep2, Place.Right, loop, Place.Right);
			MakeLink(rep2, Place.Left, rep1, Place.Left);
			inGate = rep2;
			outGate = rep1;
		}
		static void Repeater(ArrayList list, out Gate inGate, out Gate outGate)
		{
			Gate loop = new Gate();
			list.Add(loop);
			Gate rep1 = new Gate();
			list.Add(rep1);
			Gate rep2 = new Gate();
			list.Add(rep2);
			MakeLink(loop, Place.Left,  rep1, Place.Right);
			MakeLink(loop, Place.Right, rep2, Place.Right);
			MakeLink(rep1, Place.Right, loop, Place.Left);
			MakeLink(rep2, Place.Right, loop, Place.Right);
			MakeLink(rep1, Place.Left, rep2, Place.Right);
			inGate = rep1;
			outGate = rep2;
		}
		static void Gen0(ArrayList list, out Gate inGate, out Gate outGate, int step)
		{
			Gate prevInGate = null;
			Gate firstOutGate = null;
			inGate = null;
			for(; step>0; step -=2)
			{
				BackWiredRepeater(list, out inGate, out outGate);
				if (prevInGate != null)
					MakeLink(outGate, Place.Left, prevInGate, Place.Left);
				if (firstOutGate == null)
					firstOutGate = outGate;
				prevInGate = inGate;
			}
			outGate = firstOutGate;
		}
		static void Gen2(ArrayList list, out Gate inGate, out Gate outGate, int step)
		{
			Gate converter = new Gate();
			list.Add(converter);
			MakeLink(converter, Place.Left, converter, Place.Right);
			Gate convInput;
			Gen0(list, out inGate, out convInput, step);
			MakeLink(convInput, Place.Left, converter, Place.Left);
			outGate = converter;
		}
		static void Strobe0Gen2(ArrayList list, out Gate inGate, out Gate outGate, int step)
		{
			if (step>1)
			{
				Gate gen2Out;
				Gate repIn;
				Gen2(list, out inGate, out gen2Out, step-1);
				BackWiredRepeater(list, out repIn, out outGate);
				MakeLink(gen2Out, Place.Right, repIn, Place.Left);
			}
			else
			{
				BackWiredRepeater(list, out inGate, out outGate);
			}
		}
		/*static void Strobe0Gen1(ArrayList list, out Gate inGate, out Gate outGate, int step)
		{
			Gate converter = new Gate();
			list.Add(converter);
			MakeLink(converter, Place.Right, converter, Place.Right);
			Gate convInput;
			Gen0(list, out inGate, out convInput, step);
			MakeLink(convInput, Place.Left, converter, Place.Left);
			outGate = converter;
		}*/
		static void Strobe1Gen0(ArrayList list, out Gate inGate, out Gate outGate, int step)
		{
			Gate s0g2Out;
			Strobe0Gen2(list, out inGate, out s0g2Out, step);
			Gate g2Out, g2In;
			Gen2(list, out g2In, out g2Out, step);
			Gate converter = new Gate();
			list.Add(converter);
			MakeLink(s0g2Out, Place.Left, converter, Place.Left);
			MakeLink(g2Out, Place.Right, converter, Place.Right);
			outGate = converter;
		}
		static void Strobe2Gen0(ArrayList list, out Gate inGate, out Gate outGate, int step)
		{
			Gate s0g2Out;
			Strobe0Gen2(list, out inGate, out s0g2Out, step);
			Gate g2Out, g2In;
			Gen2(list, out g2In, out g2Out, step);
			Gate converter = new Gate();
			list.Add(converter);
			MakeLink(s0g2Out, Place.Left, converter, Place.Right);
			MakeLink(g2Out, Place.Right, converter, Place.Left);
			outGate = converter;
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

		private static int[] ParseTarget(string value)
		{
			var res = new List<int>(value.Length);
			for(int pos = 0; pos < value.Length; pos++)
			{
				AdvanceToNextTrit(value, ref pos);
				char fx = value[pos];
				var x = fx - '0';
				res.Add(x);
			}
			return res.ToArray();
		}
	}
}
