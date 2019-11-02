using System.Collections.Generic;
using MultiLayerSolution.Model;

namespace MultiLayerSolution.Bll
{
	public interface IAppLogic
	{
		/// <summary>
		/// Obtiene la lista de clientes
		/// </summary>
		/// <returns></returns>
		List<Customer> GetCustomers ();

		/// <summary>
		/// Obtiene un cliente
		/// </summary>
		/// <param name="id">Id del cliente</param>
		/// <returns></returns>
		Customer GetCustomer (int id);

		/// <summary>
		/// Crea un cliente nuevo
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		bool CreateCustomer (Customer customer);

		/// <summary>
		/// Actualiza un cliente
		/// </summary>
		/// <param name="customer">Cliente a actualizar</param>
		/// <returns>True si lo ha actualizado correctamente</returns>
		bool UpdateCustomer (Customer customer);

		/// <summary>
		/// Eliminar un cliente
		/// </summary>
		/// <param name="customer">Cliente a eliminar</param>
		/// <returns>True si lo eliminar correctamente</returns>
		bool DeleteCustomer (Customer customer);
	}
}
