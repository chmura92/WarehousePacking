using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePacking.Domain.ValueObjects;

namespace WarehousePacking.Application.UseCases.CalculatePacking.DataTransfer
{
	public record CalculatePackingRequest(int Quantity, ArticleDto Article, BoxTypeDto BoxType);
	public record ArticleDto(string Name, Dimmensions ArticleDimmensions);
	public record BoxTypeDto(string Name, Dimmensions BoxDimmensions);
}
