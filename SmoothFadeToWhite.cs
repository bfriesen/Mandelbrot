using System;
using System.Drawing;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for SmoothFadeToWhite.
	/// </summary>
	public class SmoothFadeToWhite : ColorScheme
	{
		protected Color mandelbrotColor;
		protected Color[] definedColors;
		protected Color[] calculatedColors;
		protected int iterationsBetweenDefinedColors;
		protected int colorsPerIteration;

		/*private struct colorIterator
		{
			double r;
			double g;
			double b;
		}*/

		public SmoothFadeToWhite()
		{
			iterationsBetweenDefinedColors = 15;
			colorsPerIteration = 1000;
			
			mandelbrotColor = Color.Black;

			definedColors = new Color[8];
			definedColors[0] = Color.DarkRed;
			definedColors[1] = Color.DarkGreen;
			definedColors[2] = Color.DarkMagenta;
			definedColors[3] = Color.DarkBlue;
			definedColors[4] = Color.DarkOrange;
			definedColors[5] = Color.DarkTurquoise;
			definedColors[6] = Color.DarkOrchid;
			definedColors[7] = Color.DarkSlateGray;

			int length = definedColors.Length * iterationsBetweenDefinedColors * colorsPerIteration;
			calculatedColors = new Color[length];
			
			int index = 0;

			for (int i = 0; i < definedColors.Length; i++)
			{
				double r = (double) definedColors[i].R;
				double g = (double) definedColors[i].G;
				double b = (double) definedColors[i].B;

				double redFraction = ((double)Color.White.R - (double)definedColors[i].R) / ((double)iterationsBetweenDefinedColors * (double)colorsPerIteration);
				double greenFraction = ((double)Color.White.G - (double)definedColors[i].G) / ((double)iterationsBetweenDefinedColors * (double)colorsPerIteration);
				double blueFraction = ((double)Color.White.B - (double)definedColors[i].B) / ((double)iterationsBetweenDefinedColors * (double)colorsPerIteration);
/*
				double highestR = 0.0;
				double highestG = 0.0;
				double highestB = 0.0;
*/
//				System.Console.Out.WriteLine("redFraction: " + redFraction);
//				System.Console.Out.WriteLine("greenFraction: " + greenFraction);
//				System.Console.Out.WriteLine("blueFraction: " + blueFraction);

				for (int j = 0; j < iterationsBetweenDefinedColors * colorsPerIteration; j++)
				{
					r += redFraction;
					g += greenFraction;
					b += blueFraction;

					if (r < 0) r = 0;
					if (r > 255) r = 255;
					if (g < 0) g = 0;
					if (g > 255) g = 255;
					if (b < 0) b = 0;
					if (b > 255) b = 255;

					/*if (r > highestR)
					{
						highestR = r;
						System.Console.Out.WriteLine("highestR = " + highestR);
					}
					if (g > highestG)
					{
						highestG = g;
						System.Console.Out.WriteLine("highestG = " + highestG);
					}
					if (b > highestB)
					{
						highestB = b;
						System.Console.Out.WriteLine("highestB = " + highestB);
					}*/

					calculatedColors[index++] = Color.FromArgb((int)r, (int)g, (int)b);
				}
			}
		}

		public Color calculateColor(int intData)
		{
			return Color.Black;
		}

		//int highestMagIterations = 0;
		public Color calculateColor(FractalPoint p)
		{
			if (p.getIntData() == Mandelbrot.IS_MANDELBROT
					|| p.getIntData() == Julia.IS_JULIA)
				return mandelbrotColor;

			double mag = 4.0 - (p.getMagnitude() - 2.0);
			if (mag < 0.0) mag = 0.0;
			if (mag > 4.0) mag = 4.0;

			int magIterations = (int)(((double)colorsPerIteration / 4.0) * mag);
			//if (magIterations < (colorsPerIteration - 1)) magIterations++;

			/*double x = mag;
			double c = ((double)colorsPerIteration) / 2.0;
			double n = (c*c*c)/2.0;
			magIterations = (int) (Math.Pow((n * (x - 2)), (1.0/3.0)) + c);*/

			/*double x = mag;
			double c = ((double)colorsPerIteration) / 2.0;
			double n = Math.Pow(c, (1.0/3.0))/2.0;
			magIterations = (int) (Math.Pow((n * (x - 2)), 3.0) + c);*/

			int i = p.getIntData() % (definedColors.Length * iterationsBetweenDefinedColors);
			//if (index > 2)
			//{
			//	System.Console.Out.WriteLine(/*"p.getIntData(): " + p.getIntData() + */"mag: " + mag + " magIterations: " + magIterations /*+ " index:" + index*/);
			//}
			int index = (i * colorsPerIteration) + magIterations;
			//int index = p.getIntData() % (definedColors.Length * colorsPerIteration);
			//index = (index * iterationsBetweenDefinedColors) + magIterations;

			

			//System.Console.Out.WriteLine("p.getIntData(): " + p.getIntData() + " magIterations: " + magIterations + " index:" + index);

			return calculatedColors[index];
		}
	}
}
