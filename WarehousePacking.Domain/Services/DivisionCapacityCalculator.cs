using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePacking.Domain.ValueObjects;

namespace WarehousePacking.Domain.Contracts
{
	/// <summary>
	/// Known limitations: logic assumes that article is always a cube
	/// </summary>
	public class DivisionCapacityCalculator : IBoxCapacityCalculator
	{
		public int CalculateBoxCapacity(Dimmensions boxDimmensions, Dimmensions articleDimmensions)
		{
			if (articleDimmensions.IsNotCube)
				throw new ArgumentException("Article dimensions must form a cube.");

			var cubicArticleSide = articleDimmensions.Length;

			var columns = boxDimmensions.Length / cubicArticleSide;
			var rows = boxDimmensions.Width / cubicArticleSide;
			var layers = boxDimmensions.Height / cubicArticleSide;

			return columns * rows * layers;
		}
	}
}
