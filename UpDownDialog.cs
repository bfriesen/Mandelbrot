using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for UpDownDialog.
	/// </summary>
	public class UpDownDialog : System.Windows.Forms.Form
	{
		protected int intData;

		private System.Windows.Forms.NumericUpDown upDown;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UpDownDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			intData = 10;
			upDown.Value = intData;
			label.Text = "Insert Messege Here.";
		}

		public UpDownDialog(string labelText, int intData)
		{
			InitializeComponent();

			this.intData = intData;
			upDown.Minimum = 0;
			upDown.Maximum = intData * 10;
			upDown.Value = intData;
			label.Text = labelText;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.upDown = new System.Windows.Forms.NumericUpDown();
			this.label = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.upDown)).BeginInit();
			this.SuspendLayout();
			// 
			// upDown
			// 
			this.upDown.Location = new System.Drawing.Point(163, 40);
			this.upDown.Minimum = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
			this.upDown.Name = "upDown";
			this.upDown.Size = new System.Drawing.Size(48, 20);
			this.upDown.TabIndex = 8;
			this.upDown.Value = new System.Decimal(new int[] {
																 1,
																 0,
																 0,
																 0});
			// 
			// label
			// 
			this.label.Location = new System.Drawing.Point(43, 24);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(112, 56);
			this.label.TabIndex = 7;
			this.label.Text = "Set the zoom factor:";
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(139, 88);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(43, 88);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// UpDownDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(256, 150);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.upDown,
																		  this.label,
																		  this.btnCancel,
																		  this.btnOK});
			this.Name = "UpDownDialog";
			this.Text = "UpDownDialog";
			((System.ComponentModel.ISupportInitialize)(this.upDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public int Minimum
		{
			set
			{
				this.upDown.Minimum = value;
			}
		}

		public int IntData
		{
			get
			{
				return intData;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			intData = (int) upDown.Value;
			this.Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
