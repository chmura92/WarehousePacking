using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePacking.Application.UseCases.CalculatePacking.DataTransfer;

namespace WarehousePacking.Application.UseCases.CalculatePacking
{
	public interface ICalculatePackingService
	{
		CalculatePackingResponse CalculatePacking(CalculatePackingRequest request);
	}
}
