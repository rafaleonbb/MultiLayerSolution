using System;
using System.Collections.Generic;
using System.Linq;
using MultiLayerSolution.Bll;
using MultiLayerSolution.Model;

namespace ConsoleClient
{
	class Program
	{
		/// <summary>
		/// Acceso a la lógica de la aplicación
		/// </summary>
		public static IAppLogic Logic { get; private set; } = LogicFactory.Build ();

		/// <summary>
		/// Punto de entrada
		/// </summary>
		/// <param name="args"></param>
		static void Main (string [] args) => MainMenu ();

		/// <summary>
		/// Menu principal
		/// </summary>
		static void MainMenu ()
		{
			var options = new List<string> {
				"1. Lista de clientes",
				"2. Crear un cliente nuevo",
				"3. Modificar un cliente",
				"4. Eliminar un cliente",
				"0. Salir"
			};
			while (true) {
				var quit = false;
				Console.Clear ();
				foreach (var option in options) {
					Console.WriteLine (option);
				}
				var selectedOption = Console.ReadKey ();
				switch (selectedOption.Key) {
				case ConsoleKey.D1:
					CustomersList ();
					break;

				case ConsoleKey.D2:
					CreateCustomer ();
					break;

				case ConsoleKey.D3:
					EditCustomer ();
					break;

				case ConsoleKey.D4:
					DeleteCustomer ();
					break;

				case ConsoleKey.D0:
					quit = true;
					break;
				}
				if (quit) {
					break;
				}
			}
		}

		/// <summary>
		/// Crea un cliente nuevo
		/// </summary>
		static void CreateCustomer ()
		{
			var customer = new Customer {
				Name = $"Cliente creado automáticamente",
				Address = $"Dirección del cliente",
				Phone = $"555"
			};
			var id = Logic.CreateCustomer (customer);
			Console.Clear ();
			Console.WriteLine ($"Se ha creado el cliente {id}");
			Console.ReadKey ();
		}

		/// <summary>
		/// Edita un cliente
		/// </summary>
		static void EditCustomer ()
		{
			var id = GetIdToEditOrDelete ();
			if (id == 0) {
				Console.WriteLine ("Id no válida");
				return;
			}
			var customer = Logic.GetCustomer (id);
			customer.Name = "Nombre modificado";
			Logic.UpdateCustomer (customer);
			Console.WriteLine ("Cliente modificado correctamente");
			Console.ReadKey ();
		}

		/// <summary>
		/// Eliminar un cliente
		/// </summary>
		static void DeleteCustomer ()
		{
			var id = GetIdToEditOrDelete ();
			if (id == 0) {
				Console.WriteLine ("Id no válida");
				return;
			}
			var customer = new Customer { Id = id };
			Logic.DeleteCustomer (customer);
			Console.WriteLine ("Cliente eliminado correctamente");
			Console.ReadKey ();
		}

		/// <summary>
		/// Pide una id para editar o modificar un cliente
		/// </summary>
		/// <returns></returns>
		static int GetIdToEditOrDelete ()
		{
			Console.Clear ();
			Console.WriteLine ("Introduzca el id de cliente: ");
			var input = Console.ReadLine ();
			if (!int.TryParse (input, out int id)) {
				id = 0;
			}
			return id;
		}
		/// <summary>
		/// Lista de clientes
		/// </summary>
		static void CustomersList ()
		{
			var customers = Logic.GetCustomers ();
			Console.Clear ();
			Console.WriteLine ($"{"Id".PadRight (2)} {"Nombre".PadRight (30)} {"Dirección".PadRight (30)} {"Teléfono".PadRight (10)}");
			foreach (var customer in customers) {
				Console.WriteLine ($"{customer.Id.ToString ().PadRight (2)} {customer.Name.PadRight (30)} {customer.Address.PadRight (30)} {customer.Phone.PadRight (10)}");
			}
			Console.WriteLine ($"{customers.Count} registros");
			Console.ReadKey ();
		}
	}
}
