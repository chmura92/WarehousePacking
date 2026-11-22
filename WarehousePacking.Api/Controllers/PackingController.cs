using Microsoft.AspNetCore.Mvc;
using WarehousePacking.Application.UseCases.CalculatePacking;
using WarehousePacking.Application.UseCases.CalculatePacking.DataTransfer;

namespace WarehousePacking.Api.Controllers
{
    [ApiController]
    [Route("packing")]
    public class PackingController : ControllerBase
    {
        private readonly ICalculatePackingService _appService;

		public PackingController(ICalculatePackingService appService)
		{
			_appService = appService;
		}

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] CalculatePackingRequest request)
        {
            var response = _appService.CalculatePacking(request);
            return Ok(response);
		}
    }
}
