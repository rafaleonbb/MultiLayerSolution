using System.Collections.Generic;
using MultiLayerSolution.Bll.Customers;
using MultiLayerSolution.Dal;
using MultiLayerSolution.Model;

namespace MultiLayerSolution.Bll
{
	/// <summary>
	/// Lógica de la aplicación
	/// </summary>
	class AppLogic : IAppLogic
	{
		/// <summary>
		/// Acceso a la AppLogic actual
		/// </summary>
		public static AppLogic Current { get; private set; }

		/// <summary>
		/// Inicializa una nueva instancia de <see cref="AppLogic"/>
		/// </summary>
		public AppLogic ()
		{
			Current = this;
			CheckDatabase ();
		}

		/// <summary>
		/// Crea la base de datos si no existe
		/// </summary>
		void CheckDatabase ()
		{
			using var db = OpenContext ();
			db.Database.EnsureCreated ();
		}

		/// <summary>
		/// Abre el contexto de la base de datos
		/// </summary>
		/// <returns></returns>
		internal Context OpenContext () => new Context ();

		#region Customers

		/// <summary>
		/// Obtiene la lista de clientes
		/// </summary>
		/// <returns></returns>
		public List<Customer> GetCustomers () => new CustomersLogic ().Get ();

		/// <summary>
		/// Obtiene un cliente
		/// </summary>
		/// <param name="id">Id del cliente</param>
		/// <returns></returns>
		public Customer GetCustomer (int id) => new CustomersLogic ().Get (id);

		/// <summary>
		/// Crea un cliente nuevo
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		public int CreateCustomer (Customer customer) => new CustomersLogic ().Create (customer);

		/// <summary>
		/// Actualiza un cliente
		/// </summary>
		/// <param name="customer">Cliente a actualizar</param>
		/// <returns>True si lo ha actualizado correctamente</returns>
		public bool UpdateCustomer (Customer customer) => new CustomersLogic ().Update (customer);

		/// <summary>
		/// Eliminar un cliente
		/// </summary>
		/// <param name="customer">Cliente a eliminar</param>
		/// <returns>True si lo eliminar correctamente</returns>
		public bool DeleteCustomer (Customer customer) => new CustomersLogic ().Delete (customer);

		#endregion
	}
}
