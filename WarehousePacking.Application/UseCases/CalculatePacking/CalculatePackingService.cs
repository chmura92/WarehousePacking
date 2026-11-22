using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePacking.Application.UseCases.CalculatePacking.DataTransfer;
using WarehousePacking.Domain.Contracts;

namespace WarehousePacking.Application.UseCases.CalculatePacking
{
	public class CalculatePackingService : ICalculatePackingService
	{
		private readonly IBoxCapacityCalculator _boxCapacityCalculator;
		private readonly ILpnGenerator _lpnGenerator;

		public CalculatePackingService(IBoxCapacityCalculator boxCapacityCalculator, ILpnGenerator lpnGenerator)
		{
			_boxCapacityCalculator = boxCapacityCalculator;
			_lpnGenerator = lpnGenerator;
		}

		// todo: add UnitTests
		public CalculatePackingResponse CalculatePacking(CalculatePackingRequest request)
		{
			if(request?.Quantity == 0)
				return CalculatePackingResponse.Empty;

			ValidateRequest(request);

			var boxCapacity = _boxCapacityCalculator.CalculateBoxCapacity(request!.BoxType.BoxDimmensions, request.Article.ArticleDimmensions);

			if(boxCapacity == 0)
				return CalculatePackingResponse.Empty;

			var boxesToUseCount = (int)Math.Floor((decimal)request.Quantity / boxCapacity);
			var remeainingQuantity = request.Quantity % boxCapacity;

			var boxesToUse = Enumerable.Range(0, boxesToUseCount)
				.Select(box => new BoxToUseDto(_lpnGenerator.Generate(), boxCapacity))
				.ToList();

			if(remeainingQuantity > 0)
				boxesToUse.Add(new BoxToUseDto(_lpnGenerator.Generate(), remeainingQuantity));

			return new CalculatePackingResponse(boxesToUse.ToArray());
		}

		// todo: add more validations, alternativelly add fluent validations
		private void ValidateRequest(CalculatePackingRequest? request)
		{
			if(request is null)
				throw new ArgumentNullException(nameof(request));

			if (request?.Article is null || request.BoxType is null)
				throw new ArgumentException("Request can not be empty");

			if (request.Quantity < 0)
				throw new ArgumentException("Quantity can not be negative");
		}
	}
}
