﻿using System;
using Relativity.Testing.Framework.Api.Services;
using Relativity.Testing.Framework.Models;

namespace Relativity.Testing.Framework.Api.Strategies
{
	internal class ObjectTypeUpdateStrategy : IUpdateWorkspaceEntityStrategy<ObjectType>
	{
		private readonly IRestService _restService;
		private readonly IGetWorkspaceEntityByIdStrategy<ObjectType> _getWorkspaceEntityByIdStrategy;

		public ObjectTypeUpdateStrategy(
			IRestService restService, IGetWorkspaceEntityByIdStrategy<ObjectType> getWorkspaceEntityByIdStrategy)
		{
			_restService = restService;
			_getWorkspaceEntityByIdStrategy = getWorkspaceEntityByIdStrategy;
		}

		public ObjectType Update(int workspaceId, ObjectType entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			var dto = new
			{
				ObjectTypeRequest = new
				{
					entity.ParentObjectType,
					RelativityApplications = entity.RelativityApplications.ViewableItems,
					entity.Name,
					entity.CopyInstancesOnParentCopy,
					entity.CopyInstancesOnCaseCreation,
					entity.EnableSnapshotAuditingOnDelete,
					entity.PersistentListsEnabled,
					entity.PivotEnabled,
					entity.SamplingEnabled
				}
			};

			_restService.Put($"relativity.objectTypes/workspace/{workspaceId}/objectTypes/{entity.ArtifactID}", dto);

			return _getWorkspaceEntityByIdStrategy.Get(workspaceId, entity.ArtifactID);
		}
	}
}
