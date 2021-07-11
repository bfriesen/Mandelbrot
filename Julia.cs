using System;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for Julia.
	/// </summary>
	public class Julia
	{
		public const int IS_JULIA = -2;
		public const int DEFAULT_ITERATIONS = 1000;
		
		private static int maxIterations = DEFAULT_ITERATIONS;
		private static ImaginaryNumber juliaSetConstant;
		
		private Julia() {}

		static Julia()
		{
			juliaSetConstant = new ImaginaryNumber(1.0, 1.0);
		}

		public static void setIterations(int iterations) 
		{
			maxIterations  = iterations;
		}

		public static int getIterations()
		{
			return maxIterations;
		}

		public static void setJuliaSetConstant(ImaginaryNumber JuliaSetConstant)
		{
			juliaSetConstant = JuliaSetConstant;
		}

		public ImaginaryNumber getJuliaSetConstant()
		{
			return juliaSetConstant;
		}

		public static FractalPoint testNumber(ImaginaryNumber Z)
		{
		  /*1. Choose any complex number and make c equal to it. This will be our Julia Set constant.
			2. Choose another complex number and make z equal to it.
			3. Make z equal to z2 + c and repeat this change a lot of times.
			4. If the number went rapidly to infinity, do not mark the corresponding point on the complex plane. Otherwise, it belongs to the set and you can mark it.
			5. Repeat steps 2-5 for different numbers until all points on the plane are checked.*/

			ImaginaryNumber C = juliaSetConstant;

			/*
			for (int i = 0; i < maxIterations; i++) 
			{
				//Z = Z.squared().plus(C);
				Z = Z * Z + C;
				double mag = Z.magnitude();
				if (mag > 2.0)
				{
					return new FractalPoint(Z, i, mag);
				}
			}
			*/
			
			return new FractalPoint(C, IS_JULIA, 0.0);
		}
	}
}
