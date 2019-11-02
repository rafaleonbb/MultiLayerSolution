using System;
using System.Collections.Generic;
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
			var id = Logic.GetCustomers ().Count + 1;
			var customer = new Customer {
				Id = id,
				Name = $"Soy el cliente {id}",
				Address = $"Dirección del cliente {id}",
				Phone = $"555 {id}"
			};
			Logic.CreateCustomer (customer);
			Console.Clear ();
			Console.WriteLine ($"Se ha creado el cliente {id}");
			Console.ReadKey ();
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
