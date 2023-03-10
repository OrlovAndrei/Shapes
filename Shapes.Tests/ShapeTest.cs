using Xunit;

namespace Shapes.Tests
{
	public class ShapeTest
	{
		[Theory]
		[MemberData(nameof(SquareTestData))]
		public void SquareTest(IShape shape, double square)
		{
			Assert.Equal(square, shape.Square, 4);
		}

		public static IEnumerable<object[]> SquareTestData =>
			new List<object[]>
			{
				new object[] {new Triangle(1.0, 1.0, 1.0), 0.4330 },
				new object[] {new Triangle(1.2, 3.0, 2.0), 0.8049 },
				new object[] {new Triangle(3.0, 4.0, 5.0), 6.0 },
				new object[] {new Circle(1.0), 3.1416 },
				new object[] {new Circle(12.5), 490.8739 },
			};

		[Theory]
		[MemberData(nameof(IsRectangularTestData))]
		public void IsRectangularTest(Triangle shape, bool isRectangular)
		{
			Assert.Equal(isRectangular, shape.IsRectangular());
		}

		public static IEnumerable<object[]> IsRectangularTestData =>
			new List<object[]>
			{
				new object[] {new Triangle(1, 1, 1), false },
				new object[] {new Triangle(3, 4, 5), true },
				new object[] {new Triangle(5, 4, 3), true },
				new object[] {new Triangle(6, 8, 10), true },
				new object[] {new Triangle(5, 12, 13.0001), false },
			};

		[Theory]
		[MemberData(nameof(TrianleValidationTestData))]
		public void TrianleValidationTest(Func<Triangle> func, string message)
		{
			Exception exception = Assert.Throws<Exception>(func);
			Assert.Equal(message, exception.Message);
		}

		public static IEnumerable<object[]> TrianleValidationTestData =>
			new List<object[]>
			{
				new object[] {() => new Triangle(new[] {1.0, 1.0, 1.0, 1.0}), "An array of the incorrect size was passed" },
				new object[] {() => new Triangle(new[] {1.0, 1.0}), "An array of the incorrect size was passed" },
				new object[] {() => new Triangle(10, 4, 3), "A triangle with such sides is impossible" },
				new object[] {() => new Triangle(6, 8, 15), "A triangle with such sides is impossible" },
				new object[] {() => new Triangle(10, -4, 3), "The side is assigned a negative value" },
				new object[] {() => new Triangle(6, 8, -15), "The side is assigned a negative value" },
			};
	}

}