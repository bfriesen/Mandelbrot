using System;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for ImaginaryPlaneRange.
	/// </summary>
	public struct ImaginaryPlaneRange
	{
		public ImaginaryPlaneRange(
			double aMin,
			double aMax,
			double biMin,
			double biMax)
		{
			this.aMin = aMin;
			this.aMax = aMax;
			this.biMin = biMin;
			this.biMax = biMax;
		}

		public double aMin;
		public double aMax;
		public double biMin;
		public double biMax;
	}
}
