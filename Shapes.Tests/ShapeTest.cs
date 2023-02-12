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
			
	}

}