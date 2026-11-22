using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePacking.Domain.ValueObjects;

namespace WarehousePacking.Domain.Contracts
{
	public class LoopCapacityCalculator : IBoxCapacityCalculator
	{
		public int CalculateBoxCapacity(Dimmensions boxDimmensions, Dimmensions articleDimmensions)
		{
			var boxesCount = 0;

			for (var x = boxDimmensions.Length; x >= articleDimmensions.Length; x -= articleDimmensions.Length)
			{
				for (var z = boxDimmensions.Width; z >= articleDimmensions.Width; z -= articleDimmensions.Width)
				{
					for (var y = boxDimmensions.Height; y >= articleDimmensions.Height; y -= articleDimmensions.Height)
					{
						boxesCount++;
					}
				}
			}

			return boxesCount;
		}
	}
}
