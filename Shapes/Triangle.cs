using System.Data;

namespace Shapes
{
	public class Triangle : IShape
	{
		public double Square => GetSquare();

		private readonly double[] _sides = new double[3];

		public Triangle(double side1, double side2, double side3) : this(new[] { side1, side2, side3 }) { }

		public Triangle(double[] sides)
		{
			if (sides.Length != 3) throw new Exception("An array of the incorrect size was passed");

			for (int i = 0; i < sides.Length; i++)
				if (sides[i] > sides[(i + 1) % 3] + sides[(i + 2) % 3])
					throw new Exception("A triangle with such sides is impossible");

			for (int i = 0; i < sides.Length; i++)
				_sides[i] = sides[i];
		}
		
		public bool IsRectangular()
		{
			for (int i = 0; i < _sides.Length; i++)
				if (Math.Pow(_sides[i], 2) == Math.Pow(_sides[(i + 1) % 3], 2) + Math.Pow(_sides[(i + 2) % 3], 2))
					return true;

			return false;
		}

		private double GetSquare()
		{
			var p = GetPerimeter() / 2;
			return Math.Sqrt(p * (p - _sides[0]) * (p - _sides[1]) * (p - _sides[2]));
		}

		private double GetPerimeter()
		{
			var sum = 0.0;
			for (int i = 0; i < _sides.Length; i++)
				sum+=_sides[i];
			return sum;
		}

	}
}