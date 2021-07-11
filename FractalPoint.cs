using System;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for FractalPoint.
	/// </summary>
	public class FractalPoint
	{
		private ImaginaryNumber number;
		private int iterations;
		private double magnitudeOver2;

		public FractalPoint(ImaginaryNumber number, int iterations, double magnitudeOver2)
		{
			//System.Collections.ArrayList
			this.number = number;
			this.iterations = iterations;
			this.magnitudeOver2 = magnitudeOver2;
		}

		public int getIntData()
		{
			return iterations;
		}
		
		public double getMagnitude()
		{
			return magnitudeOver2;
		}

		public ImaginaryNumber getImaginaryNumber()
		{
			return number;
		}
		
	}
}
