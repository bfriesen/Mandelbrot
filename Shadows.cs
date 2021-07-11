using System;
using System.Drawing;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for Shadows.
	/// </summary>
	public class Shadows : ColorScheme
	{
		public const int LINEAR = 1;
		public const int THIRD_POWER = 2;
		public const int ONE_THIRD_POWER = 3;
		
		protected int equation;
		protected Color mandelbrotColor;
		protected Color[] definedColors;
		protected Color[] calculatedColors;
		protected Color[][] shadowedColors;
		protected int iterationsBetweenDefinedColors;
		protected int colorsPerIteration;

		public Shadows()
		{
			equation = LINEAR;

			iterationsBetweenDefinedColors = 10;
			colorsPerIteration = 1000;
			
			mandelbrotColor = Color.Black;

			definedColors = new Color[8];
			definedColors[0] = Color.DarkGreen;
			definedColors[1] = Color.DarkSlateBlue;
			definedColors[2] = Color.DarkMagenta;
			definedColors[3] = Color.DarkBlue;
			definedColors[4] = Color.DarkOrange;
			definedColors[5] = Color.DarkTurquoise;
			definedColors[6] = Color.DarkOrchid;
			definedColors[7] = Color.DarkSlateGray;

			calculatedColors = new Color[definedColors.Length * iterationsBetweenDefinedColors];

			int index = 0;

			for (int i = 0; i < definedColors.Length; i++)
			{
				double r = (double) definedColors[i].R;
				double g = (double) definedColors[i].G;
				double b = (double) definedColors[i].B;

				double redFraction = ((double)Color.White.R - (double)definedColors[i].R) / ((double)iterationsBetweenDefinedColors * (double)colorsPerIteration);
				double greenFraction = ((double)Color.White.G - (double)definedColors[i].G) / ((double)iterationsBetweenDefinedColors * (double)colorsPerIteration);
				double blueFraction = ((double)Color.White.B - (double)definedColors[i].B) / ((double)iterationsBetweenDefinedColors * (double)colorsPerIteration);

				for (int j = 0; j < iterationsBetweenDefinedColors; j++)
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

					calculatedColors[index++] = Color.FromArgb((int)r, (int)g, (int)b);
				}
			}

			shadowedColors = new Color[6][];


		}

		public Color calculateColor(int intData)
		{
			return calculateColor(new FractalPoint(new ImaginaryNumber(0.0, 0.0), intData, 0.0));
		}

		public Color calculateColor(FractalPoint p)
		{
			if (p.getIntData() == Mandelbrot.IS_MANDELBROT
					|| p.getIntData() == Julia.IS_JULIA)
				return mandelbrotColor;

			double mag = 4.0 - (p.getMagnitude() - 2.0);
			if (mag < 0.0) mag = 0.0;
			if (mag > 4.0) mag = 4.0;
			
			int magIterations = 0;

			if (equation == LINEAR)
				magIterations = (int)(((double)colorsPerIteration / 4.0) * mag);
			else if (equation == THIRD_POWER)
			{
				double x = mag;
				double c = ((double)colorsPerIteration) / 2.0;
				double n = Math.Pow(c, 3)/2.0;
				magIterations = (int) (Math.Pow((n * (x - 2)), (1.0/3.0)) + c);
			}
			else if (equation == ONE_THIRD_POWER)
			{
				double x = mag;
				double c = ((double)colorsPerIteration) / 2.0;
				double n = Math.Pow(c, (1.0/3.0))/2.0;
				magIterations = (int) (Math.Pow((n * (x - 2)), 3.0) + c);
			}
			
			int i = p.getIntData() % (definedColors.Length * iterationsBetweenDefinedColors);
			int index = (i * colorsPerIteration) + magIterations;

			return calculatedColors[index];
		}

		private Color getFinalColor(Color baseColor, double magIterations)
		{
			return Color.Black;
		}
	}
}
