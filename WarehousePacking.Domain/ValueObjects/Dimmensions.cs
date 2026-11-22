using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehousePacking.Domain.ValueObjects
{
	/// <summary>
	/// All values in same abstract UoM
	/// </summary>
	public record Dimmensions(int Length, int Width, int Height)
	{
		public bool IsCube => Length == Width && Width == Height;
		public bool IsNotCube => !IsCube;

		public static Dimmensions FromCube(int size) => new Dimmensions(size, size, size);
	}
}
