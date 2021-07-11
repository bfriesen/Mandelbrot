using System;
using System.Drawing;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for SmoothFadeToWhite.
	/// </summary>
	public class SmoothFadeToWhiteOld : ColorScheme
	{
		protected Color mandelbrotColor;
		protected Color[] definedColorArray;
		protected Color[] calculatedColorArray;
		protected Color[] smoothedColorArray;
		protected int colorsBetweenDefined;
		protected int colorsBetweenCalculated;

		public SmoothFadeToWhiteOld()
		{
			//colorsBetween = 10;
			colorsBetweenDefined = 10;
			colorsBetweenCalculated = 5;
			//int colorsBetween = colorsBetweenDefined * colorsBetweenCalculated;

			mandelbrotColor = Color.Black;

			definedColorArray = new Color[8];
			definedColorArray[0] = Color.DarkRed;
			definedColorArray[1] = Color.DarkGreen;
			definedColorArray[2] = Color.DarkMagenta;
			definedColorArray[3] = Color.DarkBlue;
			definedColorArray[4] = Color.DarkOrange;
			definedColorArray[5] = Color.DarkTurquoise;
			definedColorArray[6] = Color.DarkOrchid;
			definedColorArray[7] = Color.DarkSlateGray;

			int calculatedLength = definedColorArray.Length * colorsBetweenDefined;
			calculatedColorArray = new Color[calculatedLength];
			
			double redFraction=0.0; double greenFraction=0.0; double blueFraction=0.0;
			double r; double g; double b;
			int index = 0;
			
			for (int c1 = 0; c1 < (definedColorArray.Length); c1++) 
			{
				r = definedColorArray[c1].R;
				g = definedColorArray[c1].G;
				b = definedColorArray[c1].B;
				redFraction = (Color.White.R - definedColorArray[c1].R) / colorsBetweenDefined;
				greenFraction = (Color.White.G - definedColorArray[c1].G) / colorsBetweenDefined;
				blueFraction = (Color.White.B - definedColorArray[c1].B) / colorsBetweenDefined;

				for (int c2 = 0; c2 < colorsBetweenDefined; c2++) 
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

			calculatedLength = calculatedColorArray.Length * colorsBetweenCalculated;
			smoothedColorArray = new Color[calculatedLength];
			index = 0;

			for (int c3 = 0; c3 < (calculatedColorArray.Length); c3++)
			{
				r = calculatedColorArray[c3].R;
				g = calculatedColorArray[c3].G;
				b = calculatedColorArray[c3].B;
				if ( ( (c3 + 1) % (calculatedColorArray.Length / definedColorArray.Length) ) != 0.0)
				{
					redFraction = (calculatedColorArray[c3 + 1].R - calculatedColorArray[c3].R) / colorsBetweenCalculated;
					greenFraction = (calculatedColorArray[c3 + 1].G - calculatedColorArray[c3].G) / colorsBetweenCalculated;
					blueFraction = (calculatedColorArray[c3 + 1].B - calculatedColorArray[c3].B) / colorsBetweenCalculated;
				}/*
				else
				{
					redFraction = (Color.White.R - calculatedColorArray[c3].R) / colorsBetweenCalculated;
					greenFraction = (Color.White.G - calculatedColorArray[c3].G) / colorsBetweenCalculated;
					blueFraction = (Color.White.B - calculatedColorArray[c3].B) / colorsBetweenCalculated;
				}*/

				for (int c4 = 0; c4 < colorsBetweenCalculated; c4++)
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

					smoothedColorArray[index] = Color.FromArgb((int)r, (int)g, (int)b);
					index++;
				}
			}
		}

		public Color calculateColor(int intData)
		{
			//throw new Exception("This method isn't implemented, and I haven't bothered to make it work better.");
			if (intData == Mandelbrot.IS_MANDELBROT) 
				return mandelbrotColor;

			//int calculatedLength = (definedColorArray.Length - 1) * (colorsBetweenDefined * colorsBetweenCalculated);
			int calculatedLength = (definedColorArray.Length) * (colorsBetweenDefined * colorsBetweenCalculated);
			int index = (intData % calculatedLength);
			//index = index + 

			return calculatedColorArray[index];
		}

		public Color calculateColor(FractalPoint p)
		{
			if (p.getIntData() == Mandelbrot.IS_MANDELBROT
					|| p.getIntData() == Julia.IS_JULIA)
				return mandelbrotColor;

			double mag = 4.0 - (p.getMagnitude() - 2.0);
			//double mag = p.getMagnitude() - 2.0;
			double magFraction = 4.0 / colorsBetweenCalculated;
			int magIterations = (int) (mag * magFraction);

			/*for (int i = 0; i < colorsBetweenCalculated; i++)
			{
				if (mag < ((i + 1) * magFraction))
				{
					magIterations = i;
					break;
				}
			}*/

			int index = p.getIntData() % (definedColorArray.Length * colorsBetweenDefined);
			index = (index * colorsBetweenCalculated) + magIterations;

			//System.Console.Out.WriteLine("magIterations: " + magIterations);

			return smoothedColorArray[index];


			//return calculateColor(p.getIntData());

			/*if (p.getIntData() == Mandelbrot.IS_MANDELBROT)
				return mandelbrotColor;
			
			int calculatedLength = (definedColorArray.Length) * (colorsBetweenDefined * colorsBetweenCalculated);
			int index = p.getIntData() % (colorsBetweenCalculated * colorsBetweenDefined);//int index = intData % calculatedLength;

			double mag = 4.0 - (p.getMagnitude() - 2.0);
			double magFraction = 4.0 / colorsBetweenCalculated;
			int magIterations = 0;

			for (int i = 0; i < colorsBetweenCalculated; i++)
			{
				if (mag < ((i + 1) * magFraction))
				{
					magIterations = i;
					break;
				}
			}

			//index = (index * colorsBetweenCalculated) + magIterations;
			index = index + magIterations;
			//index = index % colorsBetweenDefined;

			return calculatedColorArray[index];*/

			/*if (p.getIntData() == Mandelbrot.IS_MANDELBROT)
				return mandelbrotColor;

			int intData = p.getIntData() % colorsBetweenDefined;
			double mag = 4.0 - (p.getMagnitude() - 2.0);
			double magFraction = 4.0 / colorsBetweenCalculated;
			int magIterations = 0;

			for (int i = 0; i < colorsBetweenCalculated; i++)
			{
				if (mag < ((i + 1) * magFraction))
				{
					magIterations = i;
					break;
				}
			}

			//find out where mag falls 0.0-4.0
			//int calculatedLength = (definedColorArray.Length - 1) * colorsBetween;
			//int index = intData % calculatedLength;
			int calculatedLength = (definedColorArray.Length) * colorsBetweenDefined;
			int smoothedLength = (calculatedLength) * colorsBetweenCalculated;
			//int calculatedIndex = (intData % colorsBetweenDefined);
			int calculatedIndex = intData;
			int smoothIndex = (calculatedIndex * colorsBetweenCalculated) + magIterations;

			return calculatedColorArray[smoothIndex];*/
		}
	}
}
