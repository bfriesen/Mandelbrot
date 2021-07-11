using System;

namespace Mandelbrot
{
	/// <summary>
	/// Summary description for Mandelbrot.
	/// </summary>
	public class Mandelbrot
	{
		public const int IS_MANDELBROT = -1;
		public const int DEFAULT_ITERATIONS = 1000; // TODO: return to 1000

		private static int maxIterations = DEFAULT_ITERATIONS;

		private Mandelbrot(){}
		
		public static void SetMaxIterations(int iterations) 
		{
			maxIterations  = iterations;
		}

		public static int GetIterations()
		{
			return maxIterations;
		}

		public static FractalPoint TestNumber(ImaginaryNumber C)
		{
			ImaginaryNumber Z = new ImaginaryNumber(0.0, 0.0);
			
			for (int i = 0; i < maxIterations; i++) 
			{
				Z = Z.MandelbrotFunction(C);
				if (Z.MagnitudeGreaterThanTwo())
				{
					return new FractalPoint(C, i, Z.magnitude());
				}
			}
			return new FractalPoint(C, IS_MANDELBROT, 0.0);
		}

		public static FractalPoint TestNumberUnrollFourTimes(ImaginaryNumber C)
		{
			ImaginaryNumber Z0;
			ImaginaryNumber Z1 = new ImaginaryNumber(0.0, 0.0);
			ImaginaryNumber Z2 = new ImaginaryNumber(0.0, 0.0);
			ImaginaryNumber Z3 = new ImaginaryNumber(0.0, 0.0);
			ImaginaryNumber Z4 = new ImaginaryNumber(0.0, 0.0);

			int i = 0;
			while (i < (maxIterations - 4))
			{
				Z0 = Z4.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);
				Z2 = Z1.MandelbrotFunction(C);
				Z3 = Z2.MandelbrotFunction(C);
				Z4 = Z3.MandelbrotFunction(C);

				if (Z4.MagnitudeGreaterThanTwo())
				{
					if (Z3.MagnitudeGreaterThanTwo())
					{
						if (Z2.MagnitudeGreaterThanTwo())
						{
							if (Z1.MagnitudeGreaterThanTwo())
							{
								if (Z0.MagnitudeGreaterThanTwo())
								{
									return new FractalPoint(C, i, Z0.magnitude());
								}
								else
								{
									return new FractalPoint(C, i + 1, Z1.magnitude());
								}
							}
							else
							{
								return new FractalPoint(C, i + 2, Z2.magnitude());
							}
						}
						else
						{
							return new FractalPoint(C, i + 3, Z3.magnitude());
						}
					}
					else
					{
						return new FractalPoint(C, i + 4, Z4.magnitude());
					}
				}

				i = i + 4;
			}

			if (i == (maxIterations - 1))
			{
				Z0 = Z4.MandelbrotFunction(C);

				if (Z0.MagnitudeGreaterThanTwo())
				{
					return new FractalPoint(C, i, Z0.magnitude());
				}
			}
			else if (i == (maxIterations - 2))
			{
				Z0 = Z4.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);

				if (Z1.MagnitudeGreaterThanTwo())
				{
					if (Z0.MagnitudeGreaterThanTwo())
					{
						return new FractalPoint(C, i, Z0.magnitude());
					}
					else
					{
						return new FractalPoint(C, i + 1, Z1.magnitude());
					}
				}
			}
			else if (i == (maxIterations - 3))
			{
				Z0 = Z4.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);
				Z2 = Z1.MandelbrotFunction(C);

				if (Z2.MagnitudeGreaterThanTwo())
				{
					if (Z1.MagnitudeGreaterThanTwo())
					{
						if (Z0.MagnitudeGreaterThanTwo())
						{
							return new FractalPoint(C, i, Z0.magnitude());
						}
						else
						{
							return new FractalPoint(C, i + 1, Z1.magnitude());
						}
					}
					else
					{
						return new FractalPoint(C, i + 2, Z2.magnitude());
					}
				}
			}
			else if (i == (maxIterations - 4))
			{
				Z0 = Z4.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);
				Z2 = Z1.MandelbrotFunction(C);
				Z3 = Z2.MandelbrotFunction(C);

				if (Z3.MagnitudeGreaterThanTwo())
				{
					if (Z2.MagnitudeGreaterThanTwo())
					{
						if (Z1.MagnitudeGreaterThanTwo())
						{
							if (Z0.MagnitudeGreaterThanTwo())
							{
								return new FractalPoint(C, i, Z0.magnitude());
							}
							else
							{
								return new FractalPoint(C, i + 1, Z1.magnitude());
							}
						}
						else
						{
							return new FractalPoint(C, i + 2, Z2.magnitude());
						}
					}
					else
					{
						return new FractalPoint(C, i + 3, Z3.magnitude());
					}
				}
			}

			return new FractalPoint(C, IS_MANDELBROT, 0.0);
		}

		public static FractalPoint TestNumberUnrollThreeTimes(ImaginaryNumber C)
		{
			ImaginaryNumber Z0;
			ImaginaryNumber Z1 = new ImaginaryNumber(0.0, 0.0);
			ImaginaryNumber Z2 = new ImaginaryNumber(0.0, 0.0);
			ImaginaryNumber Z3 = new ImaginaryNumber(0.0, 0.0);

			int i = 0;
			while (i < (maxIterations - 3))
			{
				Z0 = Z3.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);
				Z2 = Z1.MandelbrotFunction(C);
				Z3 = Z2.MandelbrotFunction(C);

				if (Z3.MagnitudeGreaterThanTwo())
				{
					if (Z2.MagnitudeGreaterThanTwo())
					{
						if (Z1.MagnitudeGreaterThanTwo())
						{
							if (Z0.MagnitudeGreaterThanTwo())
							{
								return new FractalPoint(C, i, Z0.magnitude());
							}
							else
							{
								return new FractalPoint(C, i + 1, Z1.magnitude());
							}
						}
						else
						{
							return new FractalPoint(C, i + 2, Z2.magnitude());
						}
					}
					else
					{
						return new FractalPoint(C, i + 3, Z3.magnitude());
					}
				}

				i = i + 4;
			}

			if (i == (maxIterations - 1))
			{
				Z0 = Z3.MandelbrotFunction(C);

				if (Z0.MagnitudeGreaterThanTwo())
				{
					return new FractalPoint(C, i, Z0.magnitude());
				}
			}
			else if (i == (maxIterations - 2))
			{
				Z0 = Z3.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);

				if (Z1.MagnitudeGreaterThanTwo())
				{
					if (Z0.MagnitudeGreaterThanTwo())
					{
						return new FractalPoint(C, i, Z0.magnitude());
					}
					else
					{
						return new FractalPoint(C, i + 1, Z1.magnitude());
					}
				}
			}
			else if (i == (maxIterations - 3))
			{
				Z0 = Z3.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);
				Z2 = Z1.MandelbrotFunction(C);

				if (Z2.MagnitudeGreaterThanTwo())
				{
					if (Z1.MagnitudeGreaterThanTwo())
					{
						if (Z0.MagnitudeGreaterThanTwo())
						{
							return new FractalPoint(C, i, Z0.magnitude());
						}
						else
						{
							return new FractalPoint(C, i + 1, Z1.magnitude());
						}
					}
					else
					{
						return new FractalPoint(C, i + 2, Z2.magnitude());
					}
				}
			}

			return new FractalPoint(C, IS_MANDELBROT, 0.0);
		}

		public static FractalPoint TestNumberUnrollTwice(ImaginaryNumber C)
		{
			ImaginaryNumber Z0;
			ImaginaryNumber Z1 = new ImaginaryNumber(0.0, 0.0);
			ImaginaryNumber Z2 = new ImaginaryNumber(0.0, 0.0);

			int i = 0;
			while (i < (maxIterations - 2))
			{
				Z0 = Z2.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);
				Z2 = Z1.MandelbrotFunction(C);

				if (Z2.MagnitudeGreaterThanTwo())
				{
					if (Z1.MagnitudeGreaterThanTwo())
					{
						if (Z0.MagnitudeGreaterThanTwo())
						{
							return new FractalPoint(C, i, Z0.magnitude());
						}
						else
						{
							return new FractalPoint(C, i + 1, Z1.magnitude());
						}
					}
					else
					{
						return new FractalPoint(C, i + 2, Z2.magnitude());
					}
				}

				i = i + 3;
			}

			if (i == (maxIterations - 1))
			{
				Z0 = Z2.MandelbrotFunction(C);

				if (Z0.MagnitudeGreaterThanTwo())
				{
					return new FractalPoint(C, i, Z0.magnitude());
				}
			}
			else if (i == (maxIterations - 2))
			{
				Z0 = Z2.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);

				if (Z1.MagnitudeGreaterThanTwo())
				{
					if (Z0.MagnitudeGreaterThanTwo())
					{
						return new FractalPoint(C, i, Z0.magnitude());
					}
					else
					{
						return new FractalPoint(C, i + 1, Z1.magnitude());
					}
				}
			}

			return new FractalPoint(C, IS_MANDELBROT, 0.0);
		}

		public static FractalPoint TestNumberUnrollOnce(ImaginaryNumber C)
		{
			ImaginaryNumber Z0;
			ImaginaryNumber Z1 = new ImaginaryNumber(0.0, 0.0);

			int i = 0;
			while (i < (maxIterations - 1))
			{
				Z0 = Z1.MandelbrotFunction(C);
				Z1 = Z0.MandelbrotFunction(C);

				if (Z1.MagnitudeGreaterThanTwo())
				{
					if (Z0.MagnitudeGreaterThanTwo())
					{
						return new FractalPoint(C, i, Z0.magnitude());
					}
					else
					{
						return new FractalPoint(C, i + 1, Z1.magnitude());
					}
				}

				i = i + 2;
			}

			if (i == (maxIterations - 1))
			{
				Z0 = Z1.MandelbrotFunction(C);

				if (Z0.MagnitudeGreaterThanTwo())
				{
					return new FractalPoint(C, i, Z0.magnitude());
				}
			}

			return new FractalPoint(C, IS_MANDELBROT, 0.0);
		}

		/*
		private static ImaginaryNumber[] results = new ImaginaryNumber[maxIterations];
		public static FractalPoint TryThisOnForSize(ImaginaryNumber C)
		{
			ImaginaryNumber Z = new ImaginaryNumber(0.0, 0.0);
			
			int testCounter = 0;
			int testDoubler = 1;

			for (int i = 0; i < maxIterations; i++) 
			{
				Z = Z.squared().plus(C);
				results[i] = Z;

				if (testCounter == testDoubler)
				{
					// The whole point of all of this is to avoid performing
					// too many of the magnitude() operations (they're expensive!)
					if (Z.magnitude() > 2.0)
					{
						// roll back from front until found
						//return new FractalPoint(C, i, Z.magnitude());
						// start with results[i - testCounter] to results[testCounter]
						for (int resultsCounter = (i - testCounter);
							resultsCounter <= testCounter;
							resultsCounter++)
						{
							if (results[resultsCounter].magnitude() > 2.0)
							{
								return new FractalPoint(results[resultsCounter], resultsCounter, results[resultsCounter].magnitude());
							}
						}
					}
					
					testDoubler = testDoubler + testDoubler;
//					if (testDoubler > maxIterations) // might not be necessary
//					{
//						testDoubler = maxIterations;
//					}
					testCounter = -1;
				}

				testCounter++;
			}

			// before returning the "IS_MANDELBROT" FractalPoint, see if the magnitude was above
			// 2.0 in the array sometime before breaking out of the for loop
			for (int resultsCounter = (maxIterations - testCounter + 1);
				resultsCounter < maxIterations;
				resultsCounter++)
			{
				if (results[resultsCounter].magnitude() > 2.0)
				{
					return new FractalPoint(results[resultsCounter], resultsCounter, results[resultsCounter].magnitude());
				}
			}

			return new FractalPoint(C, IS_MANDELBROT, 0.0);
		}
		
		/// <summary>
		/// I'm guessing that unrolling will increase the default draw by a little,
		/// but dramatically decrease zoom draws.
		/// </summary>
		/// <param name="C"></param>
		/// <returns></returns>
		public static FractalPoint TryUnrollingOnce(ImaginaryNumber C)
		{
			ImaginaryNumber Z1 = new ImaginaryNumber(0.0, 0.0);
			ImaginaryNumber Z2 = new ImaginaryNumber(0.0, 0.0);

			double mag1;
			double mag2;

			int i = 0;
			while (i < (maxIterations - 2))
			{
				Z1 = Z2.squared().plus(C);
				Z2 = Z1.squared().plus(C);

				if ((mag2 = Z2.magnitude()) > 2.0)
				{
					if ((mag1 = Z1.magnitude()) > 2.0)
					{
						return new FractalPoint(C, i, mag1);
					}
					else
					{
						return new FractalPoint(C, i, mag2);
					}
				}

				i = i + 2;
			}

			if (i == (maxIterations - 1))
			{
				Z1 = Z2.squared().plus(C);

				if ((mag1 = Z1.magnitude()) > 2.0)
				{
					return new FractalPoint(C, i, mag1);
				}
			}

			return new FractalPoint(C, IS_MANDELBROT, 0.0);
		}

		public static FractalPoint TryUnrollingTwice(ImaginaryNumber C)
		{
			ImaginaryNumber Z1 = new ImaginaryNumber(0.0, 0.0);
			ImaginaryNumber Z2 = new ImaginaryNumber(0.0, 0.0);
			ImaginaryNumber Z3 = new ImaginaryNumber(0.0, 0.0);
			
			double mag1;
			double mag2;
			double mag3;

			int i = 0;
			while (i < maxIterations)
			{
				Z1 = Z3.squared().plus(C);
				Z2 = Z1.squared().plus(C);
				Z3 = Z2.squared().plus(C);

				if ((mag3 = Z3.magnitude()) > 2.0)
				{
					if ((mag2 = Z2.magnitude()) > 2.0)
					{
						if ((mag1 = Z1.magnitude()) > 2.0)
						{
							return new FractalPoint(C, i, mag1);
						}
						else
						{
							return new FractalPoint(C, i, mag2);
						}
					}
					else
					{
						return new FractalPoint(C, i, mag3);
					}
				}

				i = i + 3;
			}

			if (i == (maxIterations - 1))
			{
				Z1 = Z3.squared().plus(C);

				if ((mag1 = Z1.magnitude()) > 2.0)
				{
					return new FractalPoint(C, i, mag1);
				}
			}

			if (i == (maxIterations - 2))
			{
				Z1 = Z3.squared().plus(C);
				Z2 = Z1.squared().plus(C);

				if ((mag2 = Z2.magnitude()) > 2.0)
				{
					if ((mag1 = Z1.magnitude()) > 2.0)
					{
						return new FractalPoint(C, i, mag1);
					}
					else
					{
						return new FractalPoint(C, i, mag2);
					}
				}
			}

			return new FractalPoint(C, IS_MANDELBROT, 0.0);
		}

		public static FractalPoint TryUnrolllllling(ImaginaryNumber C)
		{
			ImaginaryNumber Z0;
			ImaginaryNumber Z1;
			ImaginaryNumber Z2;
			ImaginaryNumber Z3;
			ImaginaryNumber Z4;
			ImaginaryNumber Z5;
			ImaginaryNumber Z6;
			ImaginaryNumber Z7;
			ImaginaryNumber Z8;
			ImaginaryNumber Z9 = new ImaginaryNumber(0.0, 0.0);

			double mag0;
			double mag1;
			double mag2;
			double mag3;
			double mag4;
			double mag5;
			double mag6;
			double mag7;
			double mag8;
			double mag9;

			int i = 0;
			while (i < maxIterations)
			{
				Z0 = Z9.squared().plus(C);
				Z1 = Z0.squared().plus(C);
				Z2 = Z1.squared().plus(C);
				Z3 = Z2.squared().plus(C);
				Z4 = Z3.squared().plus(C);
				Z5 = Z4.squared().plus(C);
				Z6 = Z5.squared().plus(C);
				Z7 = Z6.squared().plus(C);
				Z8 = Z7.squared().plus(C);
				Z9 = Z8.squared().plus(C);

				if ((mag9 = Z9.magnitude()) > 2.0)
				{
					if ((mag8 = Z8.magnitude()) > 2.0)
					{
						if ((mag7 = Z7.magnitude()) > 2.0)
						{
							if ((mag6 = Z6.magnitude()) > 2.0)
							{
								if ((mag5 = Z5.magnitude()) > 2.0)
								{
									if ((mag4 = Z4.magnitude()) > 2.0)
									{
										if ((mag3 = Z3.magnitude()) > 2.0)
										{
											if ((mag2 = Z2.magnitude()) > 2.0)
											{
												if ((mag1 = Z1.magnitude()) > 2.0)
												{
													if ((mag0 = Z0.magnitude()) > 2.0)
													{
														return new FractalPoint(C, i, mag0);
													}
													else
													{
														return new FractalPoint(C, i, mag1);
													}
												}
												else
												{
													return new FractalPoint(C, i, mag2);
												}
											}
											else
											{
												return new FractalPoint(C, i, mag3);
											}
										}
										else
										{
											return new FractalPoint(C, i, mag4);
										}
									}
									else
									{
										return new FractalPoint(C, i, mag5);
									}
								}
								else
								{
									return new FractalPoint(C, i, mag6);
								}
							}
							else
							{
								return new FractalPoint(C, i, mag7);
							}
						}
						else
						{
							return new FractalPoint(C, i, mag8);
						}
					}
					else
					{
						return new FractalPoint(C, i, mag9);
					}
				}

				i = i + 10;
			}

			if (i == (maxIterations - 1))
			{
				Z0 = Z9.squared().plus(C);

				if ((mag0 = Z0.magnitude()) > 2.0)
				{
					return new FractalPoint(C, i, mag0);
				}
			}

			if (i == (maxIterations - 2))
			{
				Z0 = Z9.squared().plus(C);
				Z1 = Z0.squared().plus(C);

				if ((mag1 = Z1.magnitude()) > 2.0)
				{
					if ((mag0 = Z0.magnitude()) > 2.0)
					{
						return new FractalPoint(C, i, mag0);
					}
					else
					{
						return new FractalPoint(C, i, mag1);
					}
				}
			}

			if (i == (maxIterations - 3))
			{
				Z0 = Z9.squared().plus(C);
				Z1 = Z0.squared().plus(C);
				Z2 = Z1.squared().plus(C);

				if ((mag2 = Z2.magnitude()) > 2.0)
				{
					if ((mag1 = Z1.magnitude()) > 2.0)
					{
						if ((mag0 = Z0.magnitude()) > 2.0)
						{
							return new FractalPoint(C, i, mag0);
						}
						else
						{
							return new FractalPoint(C, i, mag1);
						}
					}
					else
					{
						return new FractalPoint(C, i, mag2);
					}
				}
			}

			if (i == (maxIterations - 4))
			{
				Z0 = Z9.squared().plus(C);
				Z1 = Z0.squared().plus(C);
				Z2 = Z1.squared().plus(C);
				Z3 = Z2.squared().plus(C);

				if ((mag3 = Z3.magnitude()) > 2.0)
				{
					if ((mag2 = Z2.magnitude()) > 2.0)
					{
						if ((mag1 = Z1.magnitude()) > 2.0)
						{
							if ((mag0 = Z0.magnitude()) > 2.0)
							{
								return new FractalPoint(C, i, mag0);
							}
							else
							{
								return new FractalPoint(C, i, mag1);
							}
						}
						else
						{
							return new FractalPoint(C, i, mag2);
						}
					}
					else
					{
						return new FractalPoint(C, i, mag3);
					}
				}
			}

			if (i == (maxIterations - 5))
			{
				Z0 = Z9.squared().plus(C);
				Z1 = Z0.squared().plus(C);
				Z2 = Z1.squared().plus(C);
				Z3 = Z2.squared().plus(C);
				Z4 = Z3.squared().plus(C);

				if ((mag4 = Z4.magnitude()) > 2.0)
				{
					if ((mag3 = Z3.magnitude()) > 2.0)
					{
						if ((mag2 = Z2.magnitude()) > 2.0)
						{
							if ((mag1 = Z1.magnitude()) > 2.0)
							{
								if ((mag0 = Z0.magnitude()) > 2.0)
								{
									return new FractalPoint(C, i, mag0);
								}
								else
								{
									return new FractalPoint(C, i, mag1);
								}
							}
							else
							{
								return new FractalPoint(C, i, mag2);
							}
						}
						else
						{
							return new FractalPoint(C, i, mag3);
						}
					}
					else
					{
						return new FractalPoint(C, i, mag4);
					}
				}
			}

			if (i == (maxIterations - 6))
			{
				Z0 = Z9.squared().plus(C);
				Z1 = Z0.squared().plus(C);
				Z2 = Z1.squared().plus(C);
				Z3 = Z2.squared().plus(C);
				Z4 = Z3.squared().plus(C);
				Z5 = Z4.squared().plus(C);

				if ((mag5 = Z5.magnitude()) > 2.0)
				{
					if ((mag4 = Z4.magnitude()) > 2.0)
					{
						if ((mag3 = Z3.magnitude()) > 2.0)
						{
							if ((mag2 = Z2.magnitude()) > 2.0)
							{
								if ((mag1 = Z1.magnitude()) > 2.0)
								{
									if ((mag0 = Z0.magnitude()) > 2.0)
									{
										return new FractalPoint(C, i, mag0);
									}
									else
									{
										return new FractalPoint(C, i, mag1);
									}
								}
								else
								{
									return new FractalPoint(C, i, mag2);
								}
							}
							else
							{
								return new FractalPoint(C, i, mag3);
							}
						}
						else
						{
							return new FractalPoint(C, i, mag4);
						}
					}
					else
					{
						return new FractalPoint(C, i, mag5);
					}
				}
			}

			if (i == (maxIterations - 7))
			{
				Z0 = Z9.squared().plus(C);
				Z1 = Z0.squared().plus(C);
				Z2 = Z1.squared().plus(C);
				Z3 = Z2.squared().plus(C);
				Z4 = Z3.squared().plus(C);
				Z5 = Z4.squared().plus(C);
				Z6 = Z5.squared().plus(C);

				if ((mag6 = Z6.magnitude()) > 2.0)
				{
					if ((mag5 = Z5.magnitude()) > 2.0)
					{
						if ((mag4 = Z4.magnitude()) > 2.0)
						{
							if ((mag3 = Z3.magnitude()) > 2.0)
							{
								if ((mag2 = Z2.magnitude()) > 2.0)
								{
									if ((mag1 = Z1.magnitude()) > 2.0)
									{
										if ((mag0 = Z0.magnitude()) > 2.0)
										{
											return new FractalPoint(C, i, mag0);
										}
										else
										{
											return new FractalPoint(C, i, mag1);
										}
									}
									else
									{
										return new FractalPoint(C, i, mag2);
									}
								}
								else
								{
									return new FractalPoint(C, i, mag3);
								}
							}
							else
							{
								return new FractalPoint(C, i, mag4);
							}
						}
						else
						{
							return new FractalPoint(C, i, mag5);
						}
					}
					else
					{
						return new FractalPoint(C, i, mag6);
					}
				}
			}

			if (i == (maxIterations - 8))
			{
				Z0 = Z9.squared().plus(C);
				Z1 = Z0.squared().plus(C);
				Z2 = Z1.squared().plus(C);
				Z3 = Z2.squared().plus(C);
				Z4 = Z3.squared().plus(C);
				Z5 = Z4.squared().plus(C);
				Z6 = Z5.squared().plus(C);
				Z7 = Z6.squared().plus(C);

				if ((mag7 = Z7.magnitude()) > 2.0)
				{
					if ((mag6 = Z6.magnitude()) > 2.0)
					{
						if ((mag5 = Z5.magnitude()) > 2.0)
						{
							if ((mag4 = Z4.magnitude()) > 2.0)
							{
								if ((mag3 = Z3.magnitude()) > 2.0)
								{
									if ((mag2 = Z2.magnitude()) > 2.0)
									{
										if ((mag1 = Z1.magnitude()) > 2.0)
										{
											if ((mag0 = Z0.magnitude()) > 2.0)
											{
												return new FractalPoint(C, i, mag0);
											}
											else
											{
												return new FractalPoint(C, i, mag1);
											}
										}
										else
										{
											return new FractalPoint(C, i, mag2);
										}
									}
									else
									{
										return new FractalPoint(C, i, mag3);
									}
								}
								else
								{
									return new FractalPoint(C, i, mag4);
								}
							}
							else
							{
								return new FractalPoint(C, i, mag5);
							}
						}
						else
						{
							return new FractalPoint(C, i, mag6);
						}
					}
					else
					{
						return new FractalPoint(C, i, mag7);
					}
				}
			}

			if (i == (maxIterations - 9))
			{
				Z0 = Z9.squared().plus(C);
				Z1 = Z0.squared().plus(C);
				Z2 = Z1.squared().plus(C);
				Z3 = Z2.squared().plus(C);
				Z4 = Z3.squared().plus(C);
				Z5 = Z4.squared().plus(C);
				Z6 = Z5.squared().plus(C);
				Z7 = Z6.squared().plus(C);
				Z8 = Z7.squared().plus(C);

				if ((mag8 = Z8.magnitude()) > 2.0)
				{
					if ((mag7 = Z7.magnitude()) > 2.0)
					{
						if ((mag6 = Z6.magnitude()) > 2.0)
						{
							if ((mag5 = Z5.magnitude()) > 2.0)
							{
								if ((mag4 = Z4.magnitude()) > 2.0)
								{
									if ((mag3 = Z3.magnitude()) > 2.0)
									{
										if ((mag2 = Z2.magnitude()) > 2.0)
										{
											if ((mag1 = Z1.magnitude()) > 2.0)
											{
												if ((mag0 = Z0.magnitude()) > 2.0)
												{
													return new FractalPoint(C, i, mag0);
												}
												else
												{
													return new FractalPoint(C, i, mag1);
												}
											}
											else
											{
												return new FractalPoint(C, i, mag2);
											}
										}
										else
										{
											return new FractalPoint(C, i, mag3);
										}
									}
									else
									{
										return new FractalPoint(C, i, mag4);
									}
								}
								else
								{
									return new FractalPoint(C, i, mag5);
								}
							}
							else
							{
								return new FractalPoint(C, i, mag6);
							}
						}
						else
						{
							return new FractalPoint(C, i, mag7);
						}
					}
					else
					{
						return new FractalPoint(C, i, mag8);
					}
				}
			}

			return new FractalPoint(C, IS_MANDELBROT, 0.0);
		}
		*/
	}
}
