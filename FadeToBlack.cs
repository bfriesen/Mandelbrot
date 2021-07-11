using System;
using System.Drawing;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for FadeToBlack.
	/// </summary>
	public class FadeToBlack : DefaultColorScheme
	{
		public FadeToBlack()
		{
			colorsBetween = 10;

			definedColorArray = new Color[8];
			
			definedColorArray[0] = Color.Black;
			definedColorArray[1] = Color.DarkRed;
			definedColorArray[2] = Color.DarkGreen;
			definedColorArray[3] = Color.DarkMagenta;
			definedColorArray[4] = Color.DarkBlue;
			definedColorArray[5] = Color.DarkOrange;
			definedColorArray[6] = Color.DarkTurquoise;
			definedColorArray[7] = Color.DarkOrchid;

			int calculatedLength = (definedColorArray.Length - 1) * colorsBetween;
			calculatedColorArray = new Color[calculatedLength];
			
			double redFraction; double greenFraction; double blueFraction;
			double r; double g; double b;
			int index = 0;
			
			for (int c1 = 1; c1 < (definedColorArray.Length - 1); c1++) 
			{
				r = definedColorArray[c1].R;
				g = definedColorArray[c1].G;
				b = definedColorArray[c1].B;
				redFraction = (Color.White.R - definedColorArray[c1].R) / colorsBetween;
				greenFraction = (Color.White.G - definedColorArray[c1].G) / colorsBetween;
				blueFraction = (Color.White.B - definedColorArray[c1].B) / colorsBetween;

				for (int c2 = 0; c2 < colorsBetween; c2++) 
				{
					r = r + redFraction;
					g = g + greenFraction;
					b = b + blueFraction;

					if (r < 0) r = 0;
					if (r > 255) r = 255;
					if (g < 0) g = 0;
					if (g > 255) g = 255;
					if (b < 0) b = 0;
					if (b > 255) b = 255;

					calculatedColorArray[index] = Color.FromArgb((int)r, (int)g, (int)b);
					index++;
				}
			}
		}
	}
}
