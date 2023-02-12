namespace Shapes
{
	public class Triangle : IShape
	{
		public double Square => GetSquare();

		private readonly double[] _sides = new double[3];

		public Triangle(double side1, double side2, double side3)
		{
			_sides[0] = side1;
			_sides[1] = side2;
			_sides[2] = side3;
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