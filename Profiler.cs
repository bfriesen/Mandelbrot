using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for Profiler.
	/// </summary>
	public class Profiler : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.TextBox txtTest;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Profiler()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Profiler());
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnTest = new System.Windows.Forms.Button();
			this.txtTest = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(104, 64);
			this.btnTest.Name = "btnTest";
			this.btnTest.TabIndex = 0;
			this.btnTest.Text = "Test";
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// txtTest
			// 
			this.txtTest.Location = new System.Drawing.Point(88, 120);
			this.txtTest.Name = "txtTest";
			this.txtTest.ReadOnly = true;
			this.txtTest.Size = new System.Drawing.Size(104, 20);
			this.txtTest.TabIndex = 1;
			this.txtTest.Text = "";
			// 
			// Profiler
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtTest,
																		  this.btnTest});
			this.Name = "Profiler";
			this.Text = "Profiler";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnTest_Click(object sender, System.EventArgs e)
		{
//			ImaginaryNumber imaginaryNumber = new ImaginaryNumber(-.1, .2);
//			FractalPoint[] fractalPoint = new FractalPoint[10000];
//			int startTickCount = System.Environment.TickCount;
//			for (int i = 0; i < 10000; i++)
//			{
//				fractalPoint[i] = Mandelbrot.TestNumber(imaginaryNumber);
//			}
//			int endTickCount = System.Environment.TickCount;
//			double time = (endTickCount - startTickCount);
//			txtTest.Text = time.ToString();
//			// baseline for 10000 iterations 8500-9200
//			// 7500-8300  yay, improvement!
//			// 5800-6900
//			// 4150-4550

//New test, -.1 to .1 zoom unrolling test.  Results go here (I don't think the test is working right!)
// Baseline:						35406	35828
// Use MandelbrotFunction:			23235	22984
// Use MagnitudeGreaterThanTwo()	15453	15110	15156
// UnrollOnce:						17187	17125	17390
// UnrollTwice:						13875!	13750	13688	13063	13578	13375	13156
//			13656	13047	13188	13531
// UnrollThreeTimes:				13718	13703	13719	13781	13797	13297	13781

// Unrolllling: 























		}
	}
}
