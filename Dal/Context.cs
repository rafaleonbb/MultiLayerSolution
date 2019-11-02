using System;
using System.Collections.Generic;
using MultiLayerSolution.Model;

namespace MultiLayerSolution.Dal
{
	/// <summary>
	/// Esta clase implementará la capa de acceso a datos (Entity Framework u otro ORM)
	/// </summary>
	public class Context : IDisposable
	{
		static List<Customer> customers;

		/// <summary>
		/// Acceso a la tabla de clientes
		/// </summary>
		public List<Customer> Customers => customers;

		/// <summary>
		/// Inicializa una nueva clase de <see cref="Context"/>
		/// </summary>
		static Context () => Seed ();

		/// <summary>
		/// Crear algunos registros en las tablas
		/// </summary>
		static void Seed () => SeedCustomers ();

		/// <summary>
		/// Crear algunos registro en la tabla de clientes
		/// </summary>
		static void SeedCustomers ()
		{
			customers = new List<Customer> {
				new Customer { Id = 1, Name = "Come Jillón", Address = "Paula Montal", Phone = "555 555 555"},
				new Customer { Id = 2, Name = "Ines Table", Address = "Av Cervantes", Phone = "555 666 777"},
				new Customer { Id = 3, Name = "Ángela Tina", Address = "Noruega", Phone = "555 888 555"}
			};
		}

		public void Dispose ()
		{
			// Cerrar base de datos
		}
	}
}
