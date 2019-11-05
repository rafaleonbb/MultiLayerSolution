using System.Collections.Generic;
using System.Linq;
using MultiLayerSolution.Dal;
using MultiLayerSolution.Model;

namespace MultiLayerSolution.Bll.Customers
{
	class CustomersLogic
	{
		/// <summary>
		/// Obtiene la lista de clientes
		/// </summary>
		/// <returns></returns>
		public List<Customer> Get ()
		{
			using var db = OpenContext ();	
			return db.Customers.OrderBy (c => c.Id).ToList ();
		}

		/// <summary>
		/// Obtiene un cliente
		/// </summary>
		/// <param name="id">Id del cliente</param>
		/// <returns></returns>
		public Customer Get (int id)
		{
			using var db = OpenContext ();
			return db.Customers.FirstOrDefault (c => c.Id.Equals (id));
		}

		/// <summary>
		/// Crea un cliente nuevo
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		public int Create (Customer customer)
		{
			using var db = OpenContext ();
			db.Customers.Add (customer);
			db.SaveChanges ();
			return customer.Id;
		}
		
		/// <summary>
		/// Modifica un cliente
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		public bool Update (Customer customer)
		{
			using var db = OpenContext ();
			Delete (customer);
			db.Customers.Add (customer);
			db.SaveChanges ();
			return true;
		}

		/// <summary>
		/// Elimina un cliente
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		public bool Delete (Customer customer)
		{
			using var db = OpenContext ();
			var model = Get (customer.Id);
			db.Customers.Remove (model);
			db.SaveChanges ();
			return true;
		}

		/// <summary>
		/// Obtiene el contexto de la base de datos
		/// </summary>
		/// <returns></returns>
		Context OpenContext () => AppLogic.Current.OpenContext ();
	}
}
