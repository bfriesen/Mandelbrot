using System;

namespace Mandelbrot
{
	/// <summary>
	/// This class represents a complex, or imaginary number.  It has the 4 algebraic functions (+-*/), 
	/// as well as a squared and a magnitude function.
	/// </summary>
	public class ImaginaryNumber
	{
		private double A;
		private double BI;

		public ImaginaryNumber(double a, double bi)
		{
			this.A = a;
			this.BI = bi;
		}

		public ImaginaryNumber clone() 
		{
			return new ImaginaryNumber(this.a(), this.bi());
		}

		public double a() 
		{
			return A;
		}

		public double bi() 
		{
			return BI;
		}

		public static ImaginaryNumber multiply(ImaginaryNumber num1, ImaginaryNumber num2) 
		{
			double a = (num1.a() * num2.a()) + (-1 * (num1.bi() * num2.bi()));
			double bi = (num1.a() * num2.bi()) + (num1.bi() * num2.a());
			return new ImaginaryNumber(a, bi);
		}

		public static ImaginaryNumber divide(ImaginaryNumber numerator, ImaginaryNumber denominator) 
		{
			if (denominator.a() == 0.0 && denominator.bi() == 0.0)
				throw new Exception("Divide by zero");
		//  2 + 3i    2 - 3i	
			ImaginaryNumber conjugate = denominator.conjugate();
			ImaginaryNumber numer = numerator.times(conjugate);
			ImaginaryNumber denom = denominator.times(conjugate);

			double a = numer.a() / denom.a();
			double bi = numer.bi() / denom.a();

			return new ImaginaryNumber(a, bi);
		}

//		public static ImaginaryNumber square(ImaginaryNumber num) 
//		{
//			return multiply(num, num);
//		}

		public static ImaginaryNumber add(ImaginaryNumber num1, ImaginaryNumber num2) 
		{
			double a = num1.a() + num2.a();
			double bi = num1.bi() + num2.bi();
			return new ImaginaryNumber(a, bi);
		}

		public static ImaginaryNumber subtract(ImaginaryNumber num1, ImaginaryNumber num2) 
		{
			double a = num1.a() - num2.a();
			double bi = num1.bi() - num2.bi();
			return new ImaginaryNumber(a, bi);
		}

		public ImaginaryNumber conjugate() 
		{
			double a = A;
			double bi = -BI;

			return new ImaginaryNumber(a, bi);
		}

		public ImaginaryNumber times(ImaginaryNumber num) 
		{
			return multiply(this, num);
		}

		public static ImaginaryNumber operator*(ImaginaryNumber lhs, ImaginaryNumber rhs)
		{
			return multiply(lhs, rhs);
		}

		public ImaginaryNumber dividedBy(ImaginaryNumber num) 
		{
			return divide(this, num);
		}

		public static ImaginaryNumber operator/(ImaginaryNumber lhs, ImaginaryNumber rhs)
		{
			return divide(lhs, rhs);
		}

		public static ImaginaryNumber operator+(ImaginaryNumber lhs, ImaginaryNumber rhs)
		{
			return add(lhs, rhs);
		}

		public ImaginaryNumber minus(ImaginaryNumber num) 
		{
			return subtract(this, num);
		}

		public static ImaginaryNumber operator-(ImaginaryNumber lhs, ImaginaryNumber rhs)
		{
			return subtract(lhs, rhs);
		}

		public ImaginaryNumber squared() 
		{
//			return this.times(this);
			double a = (A * A) - (BI * BI);
			double bi = (A * BI) + (BI * A);
			return new ImaginaryNumber(a, bi);
		}

		public ImaginaryNumber plus(ImaginaryNumber num) 
		{
			//return add(this, num);
			double a = this.A + num.A;
			double bi = this.BI + num.BI;
			return new ImaginaryNumber(a, bi);
		}

		public ImaginaryNumber MandelbrotFunction(ImaginaryNumber c)
		{
			double a = (A * A) - (BI * BI);
			double bi = (A * BI) + (BI * A);

			return new ImaginaryNumber(a + c.A, bi + c.BI);
		}

		public double magnitude() 
		{
			return Math.Sqrt( (A * A) + (BI * BI) );
		}

		public bool MagnitudeGreaterThanTwo()
		{
			return ( ((A * A) + (BI * BI)) > 4.0 );
		}
	}
}
