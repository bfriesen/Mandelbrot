using System;
using System.Drawing;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for DefaultColorScheme.
	/// </summary>
	public class DefaultColorScheme : ColorScheme
	{
		protected Color[] definedColorArray;
		protected Color[] calculatedColorArray;
		protected int colorsBetween;

		public DefaultColorScheme()
		{
			colorsBetween = 20;

			definedColorArray = new Color[8];
			
			definedColorArray[0] = Color.Black;
			definedColorArray[1] = Color.DarkSlateGray;
			definedColorArray[2] = Color.LightBlue;
			definedColorArray[3] = Color.DarkMagenta;
			definedColorArray[4] = Color.LightYellow;
			definedColorArray[5] = Color.Aqua;
			definedColorArray[6] = Color.Pink;
			definedColorArray[7] = Color.Khaki;

			int calculatedLength = (definedColorArray.Length - 1) * colorsBetween;
			calculatedColorArray = new Color[calculatedLength];
			
			double redFraction; double greenFraction; double blueFraction;
			double r; double g; double b;
			int index = 0;

			r = definedColorArray[1].R;
			g = definedColorArray[1].G;
			b = definedColorArray[1].B;

			for (int c1 = 1; c1 < (definedColorArray.Length - 1); c1++) 
			{
				redFraction = (definedColorArray[c1+1].R - definedColorArray[c1].R) / colorsBetween;
				greenFraction = (definedColorArray[c1+1].G - definedColorArray[c1].G) / colorsBetween;
				blueFraction = (definedColorArray[c1+1].B - definedColorArray[c1].B) / colorsBetween;

				for (int c2 = 0; c2 < colorsBetween; c2++) 
				{
					r = r + redFraction;
					g = g + greenFraction;
					b = b + blueFraction;

					if (r < 0.0) r = 0;
					if (r > 255.0) r = 255.0;
					if (g < 0.0) g = 0.0;
					if (g > 255.0) g = 255.0;
					if (b < 0.0) b = 0.0;
					if (b > 255.0) b = 255.0;

					calculatedColorArray[index] = Color.FromArgb((int)r, (int)g, (int)b);
					index++;
				}
			}

			redFraction = (definedColorArray[1].R - definedColorArray[definedColorArray.Length-1].R) / colorsBetween;
			greenFraction = (definedColorArray[1].G - definedColorArray[definedColorArray.Length-1].G) / colorsBetween;
			blueFraction = (definedColorArray[1].B - definedColorArray[definedColorArray.Length-1].B) / colorsBetween;

			for (int c3 = 0; c3 < colorsBetween; c3++)
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

		public System.Drawing.Color calculateColor(int intData) 
		{
			if (intData == Mandelbrot.IS_MANDELBROT) 
				return definedColorArray[0];

			int calculatedLength = (definedColorArray.Length - 1) * colorsBetween;
			int index = intData % calculatedLength;

			return calculatedColorArray[index];
		}

		public System.Drawing.Color calculateColor(FractalPoint p)
		{
			return calculateColor(p.getIntData());
		}
	}
}
