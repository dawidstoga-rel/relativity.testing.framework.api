﻿using System;
using Relativity.Testing.Framework.Models;

namespace Relativity.Testing.Framework.Api.Strategies
{
	internal class FieldRequireStrategy<TFieldModel> : IRequireWorkspaceEntityStrategy<TFieldModel>
		where TFieldModel : Field
	{
		private readonly IUpdateWorkspaceEntityStrategy<TFieldModel> _updateWorkspaceEntityStrategy;
		private readonly ICreateWorkspaceEntityStrategy<TFieldModel> _createWorkspaceEntityStrategy;
		private readonly IGetWorkspaceEntityByNameStrategy<TFieldModel> _getWorkspaceEntityByNameStrategy;

		public FieldRequireStrategy(
			IUpdateWorkspaceEntityStrategy<TFieldModel> updateWorkspaceEntityStrategy,
			ICreateWorkspaceEntityStrategy<TFieldModel> createWorkspaceEntityStrategy,
			IGetWorkspaceEntityByNameStrategy<TFieldModel> getWorkspaceEntityByNameStrategy)
		{
			_updateWorkspaceEntityStrategy = updateWorkspaceEntityStrategy;
			_createWorkspaceEntityStrategy = createWorkspaceEntityStrategy;
			_getWorkspaceEntityByNameStrategy = getWorkspaceEntityByNameStrategy;
		}

		public TFieldModel Require(int workspaceId, TFieldModel entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			if (entity.ArtifactID != 0)
			{
				return _updateWorkspaceEntityStrategy.Update(workspaceId, entity);
			}

			if (entity.Name != null)
			{
				var existedEntity = _getWorkspaceEntityByNameStrategy.Get(workspaceId, entity.Name);

				if (existedEntity == null)
				{
					return _createWorkspaceEntityStrategy.Create(workspaceId, entity);
				}
				else
				{
					entity.ArtifactID = existedEntity.ArtifactID;
					return _updateWorkspaceEntityStrategy.Update(workspaceId, entity);
				}
			}

			return _createWorkspaceEntityStrategy.Create(workspaceId, entity);
		}
	}
}
