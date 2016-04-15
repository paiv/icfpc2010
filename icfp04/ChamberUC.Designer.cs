namespace icfp04
{
	partial class ChamberUC
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkMainChamber = new System.Windows.Forms.CheckBox();
			this.txtLowerPipe = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUpperPipe = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkMainChamber);
			this.groupBox1.Controls.Add(this.txtLowerPipe);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtUpperPipe);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(0, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(369, 114);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "chamber";
			// 
			// chkMainChamber
			// 
			this.chkMainChamber.AutoSize = true;
			this.chkMainChamber.Checked = true;
			this.chkMainChamber.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMainChamber.Location = new System.Drawing.Point(14, 77);
			this.chkMainChamber.Name = "chkMainChamber";
			this.chkMainChamber.Size = new System.Drawing.Size(60, 21);
			this.chkMainChamber.TabIndex = 5;
			this.chkMainChamber.Text = "&main";
			this.chkMainChamber.UseVisualStyleBackColor = true;
			// 
			// txtLowerPipe
			// 
			this.txtLowerPipe.Location = new System.Drawing.Point(76, 49);
			this.txtLowerPipe.Name = "txtLowerPipe";
			this.txtLowerPipe.Size = new System.Drawing.Size(287, 22);
			this.txtLowerPipe.TabIndex = 4;
			this.txtLowerPipe.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "&up pipe:";
			// 
			// txtUpperPipe
			// 
			this.txtUpperPipe.Location = new System.Drawing.Point(76, 21);
			this.txtUpperPipe.Name = "txtUpperPipe";
			this.txtUpperPipe.Size = new System.Drawing.Size(287, 22);
			this.txtUpperPipe.TabIndex = 2;
			this.txtUpperPipe.Text = "0, 0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "l&o pipe:";
			// 
			// ChamberUC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "ChamberUC";
			this.Size = new System.Drawing.Size(371, 120);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkMainChamber;
		private System.Windows.Forms.TextBox txtLowerPipe;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtUpperPipe;
		private System.Windows.Forms.Label label1;

	}
}
