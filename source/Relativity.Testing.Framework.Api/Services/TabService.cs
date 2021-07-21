﻿using Relativity.Testing.Framework.Api.Strategies;
using Relativity.Testing.Framework.Models;
using Relativity.Testing.Framework.Strategies;

namespace Relativity.Testing.Framework.Api.Services
{
	internal class TabService : ITabService
	{
		private readonly ICreateWorkspaceEntityStrategy<Tab> _createWorkspaceEntityStrategy;
		private readonly IRequireWorkspaceEntityStrategy<Tab> _requireWorkspaceEntityStrategy;
		private readonly IDeleteWorkspaceEntityByIdStrategy<Tab> _deleteWorkspaceEntityByIdStrategy;
		private readonly IGetWorkspaceEntityByIdStrategy<Tab> _getWorkspaceEntityByIdStrategy;
		private readonly IGetWorkspaceEntityByNameStrategy<Tab> _getWorkspaceEntityByNameStrategy;
		private readonly IUpdateWorkspaceEntityStrategy<Tab> _updateWorkspaceEntityStrategy;

		public TabService(
			ICreateWorkspaceEntityStrategy<Tab> createWorkspaceEntityStrategy,
			IRequireWorkspaceEntityStrategy<Tab> requireWorkspaceEntityStrategy,
			IDeleteWorkspaceEntityByIdStrategy<Tab> deleteWorkspaceEntityByIdStrategy,
			IGetWorkspaceEntityByIdStrategy<Tab> getWorkspaceEntityByIdStrategy,
			IGetWorkspaceEntityByNameStrategy<Tab> getWorkspaceEntityByName,
			IUpdateWorkspaceEntityStrategy<Tab> updateWorkspaceEntityStrategy)
		{
			_createWorkspaceEntityStrategy = createWorkspaceEntityStrategy;
			_requireWorkspaceEntityStrategy = requireWorkspaceEntityStrategy;
			_deleteWorkspaceEntityByIdStrategy = deleteWorkspaceEntityByIdStrategy;
			_getWorkspaceEntityByIdStrategy = getWorkspaceEntityByIdStrategy;
			_getWorkspaceEntityByNameStrategy = getWorkspaceEntityByName;
			_updateWorkspaceEntityStrategy = updateWorkspaceEntityStrategy;
		}

		public Tab Create(int workspaceId, Tab entity)
			=> _createWorkspaceEntityStrategy.Create(workspaceId, entity);

		public Tab Require(int workspaceId, Tab entity)
			=> _requireWorkspaceEntityStrategy.Require(workspaceId, entity);

		public void Delete(int workspaceId, int entityId)
			=> _deleteWorkspaceEntityByIdStrategy.Delete(workspaceId, entityId);

		public Tab Get(int workspaceId, int entityId)
			=> _getWorkspaceEntityByIdStrategy.Get(workspaceId, entityId);

		public Tab Get(int workspaceId, string entityName)
			=> _getWorkspaceEntityByNameStrategy.Get(workspaceId, entityName);

		public void Update(int workspaceId, Tab entity)
			=> _updateWorkspaceEntityStrategy.Update(workspaceId, entity);
	}
}
