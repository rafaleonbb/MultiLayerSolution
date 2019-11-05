using System.ComponentModel.DataAnnotations;

namespace MultiLayerSolution.Model
{
	public class Customer : Person, IEntity
	{
		[Key]
		public int Id { get; set; }
	}
}
