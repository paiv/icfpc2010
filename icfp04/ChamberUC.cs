using System.Windows.Forms;

namespace icfp04
{
	public partial class ChamberUC : UserControl
	{
		public ChamberUC()
		{
			InitializeComponent();
		}

		public bool IsMain
		{
			get { return chkMainChamber.Checked; }
			set { chkMainChamber.Checked = value; }
		}

		public string UpperPipe
		{
			get { return txtUpperPipe.Text; }
			set { txtUpperPipe.Text = value; }
		}

		public string LowerPipe
		{
			get { return txtLowerPipe.Text; }
			set { txtLowerPipe.Text = value; }
		}
	}
}
