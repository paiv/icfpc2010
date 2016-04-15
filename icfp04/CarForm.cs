using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace icfp04
{
	public partial class CarForm : Form
	{
		public CarForm()
		{
			InitializeComponent();
		}

		private void btnGen_Click(object sender, EventArgs e)
		{
			var draft = new StringBuilder();
			foreach(ChamberUC uc in pnlChambers.Controls)
			{
				if(!uc.Visible)
					continue;
				draft.AppendFormat("{0};{1};{2}", uc.IsMain ? 0 : 1, uc.UpperPipe, uc.LowerPipe);
				draft.AppendLine();
			}
			var car = CarFactory.Make(draft.ToString());
			txtCar.Text = car.ToString();
			txtCar.Focus();
			Clipboard.Clear();
			Clipboard.SetText(txtCar.Text);
		}

		private void btnGetFuel_Click(object sender, EventArgs e)
		{
			int dup = 17;
			var input = txtFabInput.Text;
			if(int.TryParse(txtDuplicate.Text, out dup))
				input = DuplicateInput(input, dup);
			var fab = Factory.Parse(txtFuelFactory.Text);
			var res = fab.Run(input);
			if(res.Length > 17)
				res = res.Insert(17, " ");
			txtFuel.Text = res;
		}

		private string DuplicateInput(string input, int min)
		{
			if(string.IsNullOrEmpty(input))
				return input;
			while(input.Length < min)
				input += input;
			return input;
		}

		private void btnParseCar_Click(object sender, EventArgs e)
		{
			var car = Car.Parse(txtCar.Text);
			txtParsedCar.Text = car.ToJson();
		}

		private void btnDrive_Click(object sender, EventArgs e)
		{
			var car = Car.Parse(txtCar.Text);
			var res = car.StartEngine(txtFuel.Text);
			lblEngine.Text = res ? "Started" : "Failed";
		}

		private void ShowNChambers(int n)
		{
			if(pnlChambers.Controls.Count > n)
			{
				for(int i = pnlChambers.Controls.Count - 1; i >= 0; i--)
				{
					pnlChambers.Controls[i].Visible = i < n;
				}
			}
			else
			{
				foreach(Control i in pnlChambers.Controls)
					i.Visible = true;

				var x = n - pnlChambers.Controls.Count;
				for(int i = 0; i < x; i++)
				{
					var uc = new ChamberUC();
					pnlChambers.Controls.Add(uc);
					//uc.Dock = DockStyle.Top;
				}
			}
		}

		private void numChambers_ValueChanged(object sender, EventArgs e)
		{
			ShowNChambers((int)numChambers.Value);
		}

	}
}
