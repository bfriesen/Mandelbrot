using System;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for ColorScheme.
	/// </summary>
	public interface ColorScheme
	{
		//System.Drawing.Color calculateColor(int intData);
		System.Drawing.Color calculateColor(FractalPoint p);
	}
}
