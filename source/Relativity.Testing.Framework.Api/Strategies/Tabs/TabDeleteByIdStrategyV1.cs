﻿using Relativity.Testing.Framework.Api.Services;
using Relativity.Testing.Framework.Models;
using Relativity.Testing.Framework.Strategies;
using Relativity.Testing.Framework.Versioning;

namespace Relativity.Testing.Framework.Api.Strategies
{
	[VersionRange(">=12.1")]
	internal class TabDeleteByIdStrategyV1 : DeleteWorkspaceEntityByIdStrategy<Tab>
	{
		private readonly IRestService _restService;

		public TabDeleteByIdStrategyV1(IRestService restService)
		{
			_restService = restService;
		}

		protected override void DoDelete(int workspaceId, int entityId)
		{
			_restService.Delete($"/Relativity.Rest/API/relativity-data-visualization/v1/workspaces/{workspaceId}/tabs/{entityId}");
		}
	}
}
