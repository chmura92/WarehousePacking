using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePacking.Domain.ValueObjects;

namespace WarehousePacking.Application.UseCases.CalculatePacking.DataTransfer
{
	public record CalculatePackingResponse(BoxToUseDto[] BoxesToUse)
	{
		public static CalculatePackingResponse Empty => new([]);
	}
	public record BoxToUseDto(string LicensePlateNumber, int NumberOfItems);
}
