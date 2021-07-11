using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for ImaginaryPlane.
	/// </summary>
	public class ImaginaryPlane
	{
//		private static ImaginaryPlaneRange DefaultImaginaryPlaneRange = 
//			new ImaginaryPlaneRange(-.1, .1, -.1, .1); // TODO: change back to 2's after refactoring
		private static ImaginaryPlaneRange DefaultImaginaryPlaneRange = 
			new ImaginaryPlaneRange(-2, 2, -2, 2);
		private static ClickBehaviourMode DefaultClickBehaviourMode =
			ClickBehaviourMode.ZoomIn;
		private static int DefaultZoomFactor = 2; // TODO: change back to 10

		private Bitmap bmp;
		private Graphics g;
		private ColorScheme scheme;
		private ImaginaryPlaneRange range;
		private ProgressBar progressBar;
		private ClickBehaviourMode clickBehaviourMode = DefaultClickBehaviourMode;
		private int zoomFactor = DefaultZoomFactor;

		public ImaginaryPlane(MandelbrotForm mandelbrotForm)
		{
			g = System.Drawing.Graphics.FromHwnd(mandelbrotForm.PictureBox.Handle);
			bmp = new Bitmap(mandelbrotForm.PictureBox.Width, mandelbrotForm.PictureBox.Height);

			range = DefaultImaginaryPlaneRange;

			scheme = new SmoothFadeToWhite();

			progressBar = mandelbrotForm.ProgressBar;
			progressBar.Step = 1;
		}

		public ColorScheme ColorScheme
		{
			get
			{
				return scheme;
			}
			set
			{
				scheme = value;
			}
		}

		public ClickBehaviourMode ClickBehaviourMode
		{
			get
			{
				return clickBehaviourMode;
			}
			set
			{
				clickBehaviourMode = value;
			}
		}

		public int ZoomFactor
		{
			get
			{
				return zoomFactor;
			}
			set
			{
				if (value < 1)
				{
					throw new Exception("ZoomFactor must be >= 1");
				}
				zoomFactor = value;
			}
		}

		public void DrawMandelbrot()
		{
			ThreadStart threadStart = new ThreadStart(DrawMandel);
			Thread thread = new Thread(threadStart);
			thread.Start();
		}

		private void DrawMandel()
		{
			if (progressBar != null)
			{
				progressBar.Minimum = 0;
				progressBar.Maximum = bmp.Height;
				progressBar.Value = 0;
			}

			lock(this)
			{
				// TODO: remove below
				int startTickCount = System.Environment.TickCount;
				// TODO: remove above

				for (int y = 0; y < bmp.Height; y++) 
				{
					for (int x = 0; x < bmp.Width; x++) 
					{
						ImaginaryNumber C = ConvertToImaginaryNumber(x, y);
						//FractalPoint p = Mandelbrot.TestNumber(C);
						//FractalPoint p = Mandelbrot.TestNumberUnrollOnce(C);
						FractalPoint p = Mandelbrot.TestNumberUnrollTwice(C);
						//FractalPoint p = Mandelbrot.TestNumberUnrollThreeTimes(C);
						//FractalPoint p = Mandelbrot.TestNumberUnrollFourTimes(C);
						//FractalPoint p = Mandelbrot.TryThisOnForSize(C);
						//FractalPoint p = Mandelbrot.TryUnrollingOnce(C);
						//FractalPoint p = Mandelbrot.TryUnrollingTwice(C);
						//FractalPoint p = Mandelbrot.TryUnrolllllling(C);
						bmp.SetPixel(x, y, scheme.calculateColor(p));
					}
					if (progressBar != null)
					{
						progressBar.PerformStep();
					}
				}

				// TODO: remove below
				int endTickCount = System.Environment.TickCount;
				int time = endTickCount - startTickCount;
				Debug.WriteLine("Time to draw Mandelbrot: " + time.ToString());
				// TODO: remove above
			}
			Paint();
			if (progressBar != null)
			{
				progressBar.Value = 0;
			}		
		}

		public void SaveBitmapAs(string fileName)
		{
			bmp.Save(fileName);
		}

		public void Resized(Control drawingSurface)
		{
			lock(this)
			{
				range = CalculateNewRange(drawingSurface.Size);
				g = System.Drawing.Graphics.FromHwnd(drawingSurface.Handle);
				bmp = new Bitmap(drawingSurface.Width, drawingSurface.Height);
			}

			DrawMandelbrot();
		}

		private ImaginaryPlaneRange CalculateNewRange(Size newSize)
		{
			/* if newSize bigger
			* widthDiff is negative
			* heightDiff is negitave
			* 
			* if newSize smaller
			* widthDiff is positive
			* heightDiff is positive
			*/

			double centerRangeA = (range.aMin + range.aMax) / 2.0;
			double centerRangeBi = (range.biMin + range.biMax) / 2.0;
			
			double oldAMin = range.aMin;
			double oldAMax = range.aMax;
			double oldBiMin = range.biMin;
			double oldBiMax = range.biMax;
			double oldRangeWidth = oldAMax - oldAMin;
			double oldRangeHeight = oldBiMax - oldBiMin;
			int oldWidth = bmp.Width;
			int oldHeight = bmp.Height;

			double newAMin;
			double newAMax;
			double newBiMin;
			double newBiMax;
			double newRangeWidth;
			double newRangeHeight;
			int newWidth = newSize.Width;
			int newHeight = newSize.Height;

			newRangeWidth = (oldRangeWidth * newWidth) / oldWidth;
			newRangeHeight = (oldRangeHeight * newHeight) / oldHeight;
			newAMin = centerRangeA - (newRangeWidth / 2.0);
			newAMax = centerRangeA + (newRangeWidth / 2.0);
			newBiMin = centerRangeBi - (newRangeHeight / 2.0);
			newBiMax = centerRangeBi + (newRangeHeight / 2.0);

			ImaginaryPlaneRange newRange = new ImaginaryPlaneRange(
				newAMin, newAMax, newBiMin, newBiMax);

			return newRange;
		}

		public void Transform(int x, int y)
		{
			switch (ClickBehaviourMode)
			{
				case ClickBehaviourMode.ZoomIn:
					Shift(x, y, (1.0 / zoomFactor));
					break;
				case ClickBehaviourMode.ZoomOut:
					Shift(x, y, zoomFactor);
					break;
				case ClickBehaviourMode.Move:
					Shift(x, y, 1);
					break;
				case ClickBehaviourMode.DoNothing:
					break;
			}
		}

		private void Shift(int x, int y, double factor) 
		{
			//do the actual Shift here.
			double aDif = range.aMax - range.aMin;
			double biDif = range.biMax - range.biMin;

			ImaginaryNumber i = ConvertToImaginaryNumber(x, y);

			range.aMax = i.a() + (aDif / 2) * factor;
			range.aMin = i.a() - (aDif / 2) * factor;
			range.biMax = i.bi() + (biDif / 2) * factor;
			range.biMin = i.bi() - (biDif / 2) * factor;

			DrawMandelbrot();
		}

		private ImaginaryNumber ConvertToImaginaryNumber(double x, double y) 
		{
			double a = x * ((range.aMax - range.aMin) / bmp.Width) + range.aMin;
			double bi = (bmp.Height - y) * ((range.biMax - range.biMin) / bmp.Height) + range.biMin;
			return new ImaginaryNumber(a, bi);
		}

		public void Paint()
		{
			System.Threading.ThreadStart threadStart = new ThreadStart(this.PaintThread);
			Thread thread = new Thread(threadStart);
			thread.Start();
		}

		private void PaintThread()
		{
			lock(this)
			{
				g.DrawImage(bmp, new System.Drawing.Point(0, 0));
			}
		}

	}

	
	/*
		//public const int MANDELBROT = -99;
		//public const int JULIA = -98;

		//private int whichFractal = JULIA;
		
		public void DrawJulia(int threadNumber)
		{
			for (int x = 0; x < threadNumber; x++)
			{
				ThreadStart threadStart = new ThreadStart(drawJul);
				Thread thread = new Thread(threadStart);
				//thread.Priority = thread.Priority + 1;
				thread.Start();
			}
		}

		internal class JuliaThread : Thread
		{
			//
		}

		private void DrawJul()
		{
			if (progressBar != null)
			{
				progressBar.Minimum = 0;
				progressBar.Maximum = bmp.Height;
				progressBar.Value = 0;
			}

			lock (this)
			{
				;
			}
		}
*/
}


