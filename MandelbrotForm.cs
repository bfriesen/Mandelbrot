using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MandelbrotForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.PictureBox picBox;
		private System.Windows.Forms.ProgressBar progressBar;
		private ImaginaryPlane plane;

		private System.Windows.Forms.ContextMenu mnuContext;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		
		// These two variables and the timer are used in the crappy work around for ResizeEnd
		private System.Drawing.Size size;
		private bool resized;
		private System.Windows.Forms.Timer timer;

		public MandelbrotForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			plane = new ImaginaryPlane(this);

			// These two are used in the crappy work around method for ResizeEnd.
			size = this.size;
			resized = false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			this.picBox = new System.Windows.Forms.PictureBox();
			this.mnuContext = new System.Windows.Forms.ContextMenu();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// picBox
			// 
			this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBox.ContextMenu = this.mnuContext;
			this.picBox.Location = new System.Drawing.Point(8, 8);
			this.picBox.Name = "picBox";
			this.picBox.Size = new System.Drawing.Size(312, 312);
			this.picBox.TabIndex = 0;
			this.picBox.TabStop = false;
			this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PicBox_Paint);
			this.picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBoxMouseDown);
			// 
			// mnuContext
			// 
			this.mnuContext.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem9,
																					   this.menuItem6,
																					   this.menuItem4});
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem5});
			this.menuItem9.Text = "When Left-Clicking...";
			// 
			// menuItem10
			// 
			this.menuItem10.Checked = true;
			this.menuItem10.Index = 0;
			this.menuItem10.RadioCheck = true;
			this.menuItem10.Text = "Zoom In";
			this.menuItem10.Click += new System.EventHandler(this.ZoomOptionClicked);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 1;
			this.menuItem11.RadioCheck = true;
			this.menuItem11.Text = "Zoom Out";
			this.menuItem11.Click += new System.EventHandler(this.ZoomOptionClicked);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.RadioCheck = true;
			this.menuItem12.Text = "Move";
			this.menuItem12.Click += new System.EventHandler(this.ZoomOptionClicked);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.RadioCheck = true;
			this.menuItem5.Text = "Do Nothing";
			this.menuItem5.Click += new System.EventHandler(this.ZoomOptionClicked);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "Set Zoom Factor";
			this.menuItem6.Click += new System.EventHandler(this.SetZoomFactor);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Set Max Iterations";
			this.menuItem4.Click += new System.EventHandler(this.SetMaxIterationsClicked);
			// 
			// timer
			// 
			this.timer.Interval = 500;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(8, 328);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(312, 16);
			this.progressBar.TabIndex = 1;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Save Picture As...";
			this.menuItem2.Click += new System.EventHandler(this.SaveMenuClicked);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Exit";
			this.menuItem3.Click += new System.EventHandler(this.ExitMenuClicked);
			// 
			// MandelbrotForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 353);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.progressBar,
																		  this.picBox});
			this.Menu = this.mainMenu1;
			this.Name = "MandelbrotForm";
			this.Text = "Mandelbrot Fractal Generator";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MandelbrotForm());
		}

		protected override void OnResize(System.EventArgs e)
		{
			int height = this.Height - 92;
			int width = this.Width - 24;
			picBox.SetBounds(8, 8, width, height);
			progressBar.SetBounds(8, picBox.Height + 16, picBox.Width, progressBar.Height);

			// Used in conjunction with the crappy ResizeEnd work around method.
			timer.Enabled = true;
		}

		/// <summary>
		/// Crappy work around method.  If VS 2003 had a ResizeEnd method, this wouldn't
		/// be necessary.  Basically, the timer emulates the ResizeEnd method.  Bleh.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_Tick(object sender, System.EventArgs e)
		{
			if (resized)
			{
				if (size.Equals(this.Size))
				{
					plane.Resized(picBox);
				}
				resized = false;
				timer.Enabled = false;
			}
			else if (!size.Equals(this.Size)) 
			{
				size = this.Size;
				resized = true;
			}
		}

		private void PicBoxMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left) 
			{
				plane.Transform(e.X, e.Y);
			}
		}

		private void SaveMenuClicked(object sender, System.EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.AddExtension = true;
			dlg.DefaultExt = "bmp";
			dlg.Filter = "Bitmap Files (*.bmp)|*.bmp";
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				lock (plane)
				{
					plane.SaveBitmapAs(dlg.FileName);
				}
			}
		}

		private void ExitMenuClicked(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void ZoomOptionClicked(object sender, System.EventArgs e)
		{
			MenuItem item = sender as MenuItem;
			Menu parent = item.Parent;
			if (item != null)
			{
				foreach (MenuItem mi in parent.MenuItems)
					mi.Checked = false;
				item.Checked = true;

				if (item.Text == "Zoom In")
					plane.ClickBehaviourMode = ClickBehaviourMode.ZoomIn;
				else if (item.Text == "Zoom Out")
					plane.ClickBehaviourMode = ClickBehaviourMode.ZoomOut;
				else if (item.Text == "Move")
					plane.ClickBehaviourMode = ClickBehaviourMode.Move;
				else
					plane.ClickBehaviourMode = ClickBehaviourMode.DoNothing;
			}
		}

		private void SetMaxIterationsClicked(object sender, System.EventArgs e)
		{
			UpDownDialog dlg = new UpDownDialog("Set the Maximum Number of Iterations:", Mandelbrot.GetIterations());
			dlg.ShowDialog(this);
			if (dlg.DialogResult == DialogResult.OK)
			{
				Mandelbrot.SetMaxIterations(dlg.IntData);
				plane.DrawMandelbrot();
			}
		}

		private void SetZoomFactor(object sender, System.EventArgs e)
		{
			UpDownDialog dlg = new UpDownDialog("Set the Zoom Factor:", plane.ZoomFactor);
			dlg.Minimum = 1;
			dlg.ShowDialog(this);
			if (dlg.DialogResult == DialogResult.OK)
			{
				plane.ZoomFactor = dlg.IntData;
			}
		}

		private void PicBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			plane.Paint();
		}

		public ProgressBar ProgressBar
		{
			get
			{
				return progressBar;
			}
		}

		public PictureBox PictureBox
		{
			get
			{
				return picBox;
			}
		}
	}
}
