namespace icfp04
{
	partial class CarForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnGen = new System.Windows.Forms.Button();
			this.txtCar = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFuelFactory = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtDuplicate = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtFabInput = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtFuel = new System.Windows.Forms.TextBox();
			this.btnGetFuel = new System.Windows.Forms.Button();
			this.btnParseCar = new System.Windows.Forms.Button();
			this.txtParsedCar = new System.Windows.Forms.TextBox();
			this.btnDrive = new System.Windows.Forms.Button();
			this.lblEngine = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.pnlChambers = new System.Windows.Forms.FlowLayoutPanel();
			this.numChambers = new System.Windows.Forms.NumericUpDown();
			this.chamberUC1 = new icfp04.ChamberUC();
			this.groupBox2.SuspendLayout();
			this.pnlChambers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numChambers)).BeginInit();
			this.SuspendLayout();
			// 
			// btnGen
			// 
			this.btnGen.Location = new System.Drawing.Point(12, 12);
			this.btnGen.Name = "btnGen";
			this.btnGen.Size = new System.Drawing.Size(75, 25);
			this.btnGen.TabIndex = 1;
			this.btnGen.Text = "Mak&e";
			this.btnGen.UseVisualStyleBackColor = true;
			this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
			// 
			// txtCar
			// 
			this.txtCar.Location = new System.Drawing.Point(397, 386);
			this.txtCar.Name = "txtCar";
			this.txtCar.Size = new System.Drawing.Size(369, 22);
			this.txtCar.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(394, 366);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "c&ar:";
			// 
			// txtFuelFactory
			// 
			this.txtFuelFactory.Location = new System.Drawing.Point(6, 21);
			this.txtFuelFactory.Multiline = true;
			this.txtFuelFactory.Name = "txtFuelFactory";
			this.txtFuelFactory.Size = new System.Drawing.Size(431, 77);
			this.txtFuelFactory.TabIndex = 7;
			this.txtFuelFactory.Text = "4R:3L1L0#5L1L,0R2L0#0R3L,5R3R0#1R4L,1R4R0#0L2R,2RX0#5R3R,0L4L0#X2L:5L";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 172);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "&fuel:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtDuplicate);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.txtFabInput);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txtFuel);
			this.groupBox2.Controls.Add(this.btnGetFuel);
			this.groupBox2.Controls.Add(this.txtFuelFactory);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(397, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(443, 234);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "fuel factory";
			// 
			// txtDuplicate
			// 
			this.txtDuplicate.Location = new System.Drawing.Point(208, 133);
			this.txtDuplicate.Name = "txtDuplicate";
			this.txtDuplicate.Size = new System.Drawing.Size(40, 22);
			this.txtDuplicate.TabIndex = 15;
			this.txtDuplicate.Text = "50";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(272, 136);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 17);
			this.label7.TabIndex = 14;
			this.label7.Text = "chars";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(116, 136);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(86, 17);
			this.label6.TabIndex = 13;
			this.label6.Text = "&duplicate for";
			// 
			// txtFabInput
			// 
			this.txtFabInput.Location = new System.Drawing.Point(51, 104);
			this.txtFabInput.Name = "txtFabInput";
			this.txtFabInput.Size = new System.Drawing.Size(386, 22);
			this.txtFabInput.TabIndex = 12;
			this.txtFabInput.Text = "012021012102";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 17);
			this.label5.TabIndex = 11;
			this.label5.Text = "i&nput";
			// 
			// txtFuel
			// 
			this.txtFuel.Location = new System.Drawing.Point(51, 169);
			this.txtFuel.Multiline = true;
			this.txtFuel.Name = "txtFuel";
			this.txtFuel.Size = new System.Drawing.Size(386, 59);
			this.txtFuel.TabIndex = 10;
			// 
			// btnGetFuel
			// 
			this.btnGetFuel.Location = new System.Drawing.Point(19, 132);
			this.btnGetFuel.Name = "btnGetFuel";
			this.btnGetFuel.Size = new System.Drawing.Size(75, 25);
			this.btnGetFuel.TabIndex = 9;
			this.btnGetFuel.Text = "&Get";
			this.btnGetFuel.UseVisualStyleBackColor = true;
			this.btnGetFuel.Click += new System.EventHandler(this.btnGetFuel_Click);
			// 
			// btnParseCar
			// 
			this.btnParseCar.Location = new System.Drawing.Point(411, 414);
			this.btnParseCar.Name = "btnParseCar";
			this.btnParseCar.Size = new System.Drawing.Size(75, 25);
			this.btnParseCar.TabIndex = 9;
			this.btnParseCar.Text = "&Parse";
			this.btnParseCar.UseVisualStyleBackColor = true;
			this.btnParseCar.Click += new System.EventHandler(this.btnParseCar_Click);
			// 
			// txtParsedCar
			// 
			this.txtParsedCar.Location = new System.Drawing.Point(397, 445);
			this.txtParsedCar.Multiline = true;
			this.txtParsedCar.Name = "txtParsedCar";
			this.txtParsedCar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtParsedCar.Size = new System.Drawing.Size(369, 140);
			this.txtParsedCar.TabIndex = 11;
			// 
			// btnDrive
			// 
			this.btnDrive.BackColor = System.Drawing.SystemColors.Desktop;
			this.btnDrive.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btnDrive.Location = new System.Drawing.Point(397, 262);
			this.btnDrive.Name = "btnDrive";
			this.btnDrive.Size = new System.Drawing.Size(443, 25);
			this.btnDrive.TabIndex = 12;
			this.btnDrive.Text = "&Drive";
			this.btnDrive.UseVisualStyleBackColor = false;
			this.btnDrive.Click += new System.EventHandler(this.btnDrive_Click);
			// 
			// lblEngine
			// 
			this.lblEngine.BackColor = System.Drawing.SystemColors.Info;
			this.lblEngine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblEngine.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEngine.Location = new System.Drawing.Point(397, 290);
			this.lblEngine.Name = "lblEngine";
			this.lblEngine.Size = new System.Drawing.Size(443, 42);
			this.lblEngine.TabIndex = 13;
			this.lblEngine.Text = "engine:";
			this.lblEngine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(183, 18);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(70, 17);
			this.label8.TabIndex = 16;
			this.label8.Text = "chambers";
			// 
			// pnlChambers
			// 
			this.pnlChambers.Controls.Add(this.chamberUC1);
			this.pnlChambers.Location = new System.Drawing.Point(4, 46);
			this.pnlChambers.Name = "pnlChambers";
			this.pnlChambers.Size = new System.Drawing.Size(379, 547);
			this.pnlChambers.TabIndex = 18;
			// 
			// numChambers
			// 
			this.numChambers.Location = new System.Drawing.Point(124, 16);
			this.numChambers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numChambers.Name = "numChambers";
			this.numChambers.Size = new System.Drawing.Size(53, 22);
			this.numChambers.TabIndex = 19;
			this.numChambers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numChambers.ValueChanged += new System.EventHandler(this.numChambers_ValueChanged);
			// 
			// chamberUC1
			// 
			this.chamberUC1.IsMain = true;
			this.chamberUC1.Location = new System.Drawing.Point(3, 3);
			this.chamberUC1.LowerPipe = "0";
			this.chamberUC1.Name = "chamberUC1";
			this.chamberUC1.Size = new System.Drawing.Size(371, 120);
			this.chamberUC1.TabIndex = 0;
			this.chamberUC1.UpperPipe = "0, 0";
			// 
			// CarForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(870, 605);
			this.Controls.Add(this.numChambers);
			this.Controls.Add(this.pnlChambers);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.lblEngine);
			this.Controls.Add(this.btnDrive);
			this.Controls.Add(this.txtParsedCar);
			this.Controls.Add(this.btnParseCar);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtCar);
			this.Controls.Add(this.btnGen);
			this.Name = "CarForm";
			this.Text = "Car maker";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.pnlChambers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numChambers)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnGen;
		private System.Windows.Forms.TextBox txtCar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFuelFactory;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnGetFuel;
		private System.Windows.Forms.TextBox txtFabInput;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtFuel;
		private System.Windows.Forms.TextBox txtDuplicate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnParseCar;
		private System.Windows.Forms.TextBox txtParsedCar;
		private System.Windows.Forms.Button btnDrive;
		private System.Windows.Forms.Label lblEngine;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.FlowLayoutPanel pnlChambers;
		private System.Windows.Forms.NumericUpDown numChambers;
		private ChamberUC chamberUC1;
	}
}

