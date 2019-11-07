using System.Collections.Generic;
using System.Linq;
using MultiLayerSolution.Dal;
using MultiLayerSolution.Model;

namespace MultiLayerSolution.Bll.Insfrastructure
{
	/// <summary>
	/// Abstracción de la lógica para las operaciones CRUD
	/// </summary>
	/// <typeparam name="T"></typeparam>
	abstract class LogicInfrastructure<T> where T : class, IEntity		 
	{
		/// <summary>
		/// Obtiene la lista de registros de <see cref="T"/>
		/// </summary>
		/// <returns></returns>
		public virtual List<T> Get ()
		{
			using var db = OpenContext ();
			return db.Set<T> ().OrderBy (c => c.Id).ToList ();
		}

		/// <summary>
		/// Obtiene un registro
		/// </summary>
		/// <param name="id">Id del registro</param>
		/// <returns></returns>
		public virtual T Get (int id)
		{
			using var db = OpenContext ();
			return db.Set<T> ().FirstOrDefault (c => c.Id.Equals (id));
		}

		/// <summary>
		/// Crea un cliente nuevo
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public int Create (T model)
		{
			using var db = OpenContext ();
			db.Set<T> ().Add (model);
			db.SaveChanges ();
			return model.Id;
		}

		/// <summary>
		/// Elimina un registro
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public bool Delete (T model)
		{
			using var db = OpenContext ();
			db.Set<T> ().Remove (model);
			db.SaveChanges ();
			return true;
		}

		/// <summary>
		/// Modifica un registro
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public bool Update (T model)
		{
			using var db = OpenContext ();
			Delete (model);
			db.Set<T> ().Add (model);
			db.SaveChanges ();
			return true;
		}

		/// <summary>
		/// Obtiene el contexto de la base de datos
		/// </summary>
		/// <returns></returns>
		protected virtual Context OpenContext () => AppLogic.Current.OpenContext ();

	}
}
