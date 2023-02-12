using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	public class Circle : IShape
	{
		public double Square => Math.PI * Math.Pow(_radius, 2);

		private double _radius;

		public Circle(double radius)
		{
			_radius= radius;
		}
	}
}
