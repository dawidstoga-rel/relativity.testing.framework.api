﻿using Relativity.Testing.Framework.Models;

namespace Relativity.Testing.Framework.Api.Services
{
	/// <summary>
	/// Represents the Application Field Code API service.
	/// </summary>
	/// <example>
	/// <code>
	/// _applicationFieldCodeService = relativityFacade.Resolve&lt;IApplicationFieldCodeService&gt;();
	/// </code>
	/// </example>
	public interface IApplicationFieldCodeService
	{
		/// <summary>
		/// Creates a new Application Field Code instance.
		/// </summary>
		/// <param name="workspaceId">The workspace ID.</param>
		/// <param name="applicationFieldCode">A [ApplicationFieldCode](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.ApplicationFieldCode.html) object to be created.</param>
		/// <returns>Returns an [ApplicationFieldCode](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.ApplicationFieldCode.html) instance.</returns>
		/// <example>
		/// <code>
		/// var workspaceId = 1015427;
		/// var applicationFieldCode = new ApplicationFieldCode()
		/// {
		/// 	Application = ApplicationType.MicrosoftExcel,
		/// 	FieldCode = "Author",
		/// 	Option = ApplicationFieldCodeOption.DocumentDefault
		/// };
		/// var createdApplicationFieldCode = _applicationFieldCodeService.Create(workspaceId, applicationFieldCode);
		/// </code>
		/// </example>
		ApplicationFieldCode Create(int workspaceId, ApplicationFieldCode applicationFieldCode);

		/// <summary>
		/// Updates an existing Application Field Code instance.
		/// </summary>
		/// <param name="workspaceId">The workspace ID.</param>
		/// <param name="applicationFieldCode">An [ApplicationFieldCode](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.ApplicationFieldCode.html) object with updated fields, reflecting the desired final state of the Application Field Code.</param>
		/// <returns>Returns an [ApplicationFieldCode](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.ApplicationFieldCode.html) instance.</returns>
		/// <example>
		/// <code>
		/// var workspaceId = 1015427;
		/// var applicationFieldCodeId = 1018877;
		/// var applicationFieldCode = _applicationFieldCodeService.Get(workspaceId, applicationFieldCodeId);
		/// applicationFieldCode.Option = ApplicationFieldCodeOption.DocumentDefault;
		/// var updatedApplicationFieldCode = _applicationFieldCodeService.Update(workspaceId, applicationFieldCode);
		/// </code>
		/// </example>
		ApplicationFieldCode Update(int workspaceId, ApplicationFieldCode applicationFieldCode);

		/// <summary>
		/// Retrieves the [ApplicationFieldCode](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.ApplicationFieldCode.html) with the specified Artifact ID.
		/// </summary>
		/// <param name="workspaceId">The workspace ID.</param>
		/// <param name="applicationFieldCodeId">The Artifact ID of the [ApplicationFieldCode](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.ApplicationFieldCode.html) instance to read.</param>
		/// <returns>Returns an [ApplicationFieldCode](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.ApplicationFieldCode.html) instance.</returns>
		/// <example>
		/// <code>
		/// var workspaceId = 1015427;
		/// var applicationFieldCodeId = 1018877;
		/// var applicationFieldCode = _applicationFieldCodeService.Get(workspaceId, applicationFieldCodeId);
		/// </code>
		/// </example>
		ApplicationFieldCode Get(int workspaceId, int applicationFieldCodeId);

		/// <summary>
		/// Deletes an Application Field Code instance.
		/// </summary>
		/// <param name="workspaceId">The workspace ID.</param>
		/// <param name="applicationFieldCodeId">The Artifact ID of the [ApplicationFieldCode](https://relativitydev.github.io/relativity.testing.framework/api/Relativity.Testing.Framework.Models.ApplicationFieldCode.html) instance to delete.</param>
		/// <example>
		/// <code>
		/// var workspaceId = 1015427;
		/// var applicationFieldCodeId = 1018877;
		/// _applicationFieldCodeService.Delete(workspaceId, applicationFieldCodeId);
		/// </code>
		/// </example>
		void Delete(int workspaceId, int applicationFieldCodeId);
	}
}
