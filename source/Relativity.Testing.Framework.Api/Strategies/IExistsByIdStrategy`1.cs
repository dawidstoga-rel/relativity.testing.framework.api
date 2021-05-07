﻿namespace Relativity.Testing.Framework.Api.Strategies
{
	/// <summary>
	/// Represents the strategy of getting the existance of the entity by ID.
	/// </summary>
	/// <typeparam name="T">The type of the entity.</typeparam>
	public interface IExistsByIdStrategy<T>
	{
		/// <summary>
		/// Determines whether the entity with the specified ID exists.
		/// </summary>
		/// <param name="id">The artifact ID of the entity.</param>
		/// <returns><see langword="true"/> if an entity exists; otherwise, <see langword="false"/>.</returns>
		bool Exists(int id);
	}
}
