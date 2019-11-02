using System;
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
		public bool Create (Customer customer)
		{
			try {
				using var db = OpenContext ();
				if (db.Customers.Exists (c => c.Id.Equals (customer.Id))) {
					throw new Exception ("Clave duplicada");
				}
				db.Customers.Add (customer);
				return true;
			} catch {
				return false;
			}
		}
		
		/// <summary>
		/// Modifica un cliente
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		public bool Update (Customer customer)
		{
			try {
				using var db = OpenContext ();
				Delete (customer);
				db.Customers.Add (customer);
				return true;

			} catch {
				return false;
			}
		}

		/// <summary>
		/// Elimina un cliente
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		public bool Delete (Customer customer)
		{
			try {
				using var db = OpenContext ();
				var model = Get (customer.Id);
				db.Customers.Remove (model);
				return true;
			} catch {
				return false;
			}
		}

		/// <summary>
		/// Obtiene el contexto de la base de datos
		/// </summary>
		/// <returns></returns>
		Context OpenContext () => AppLogic.Current.OpenContext ();
	}
}
