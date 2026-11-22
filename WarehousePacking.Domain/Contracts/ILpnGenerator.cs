using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousePacking.Domain.Contracts
{
	public interface ILpnGenerator
	{
		string Generate();
	}
}
