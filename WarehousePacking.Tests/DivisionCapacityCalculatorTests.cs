using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePacking.Domain.Contracts;
using WarehousePacking.Domain.ValueObjects;

namespace WarehousePacking.Tests
{
	public class DivisionCapacityCalculatorTests
	{
		[Theory]
		[InlineData(35, 35, 35, 10, 27)]
		[InlineData(16, 13, 44, 10, 4)]
		[InlineData(9, 20, 20, 10, 0)]
		[InlineData(20, 20, 20, 10, 8)]
		[InlineData(10, 10, 10, 10, 1)]
		public void CalculateBoxCapacity_ShouldReturnExpectedCapacity(
		   int length,
		   int width,
		   int height,
		   int articleSize,
		   int expected)
		{
			// Arrange
			var sut = new DivisionCapacityCalculator();

			var box = new Dimmensions(length, width, height);
			var article = Dimmensions.FromCube(articleSize);

			// Act
			var result = sut.CalculateBoxCapacity(box, article);

			// Assert
			Assert.Equal(expected, result);
		}
	}
}
