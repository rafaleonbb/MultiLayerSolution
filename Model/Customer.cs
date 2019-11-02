using System;

namespace MultiLayerSolution.Model
{
	public class Customer : Person, IEntity
	{
		public int Id { get; set; }
	}
}
