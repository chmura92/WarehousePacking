using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehousePacking.Domain.Contracts;

namespace WarehousePacking.Infrastructure.Services
{
	public class GuidLpnGenerator : ILpnGenerator
	{
		// todo update to Guid.CreateVersion7() for .Net9+
		public string Generate()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
