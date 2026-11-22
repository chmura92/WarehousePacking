using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePacking.Domain.ValueObjects;

namespace WarehousePacking.Domain.Contracts
{
	public interface IBoxCapacityCalculator
	{
		int CalculateBoxCapacity(Dimmensions boxDimmensions, Dimmensions articleDimmensions);
	}
}
