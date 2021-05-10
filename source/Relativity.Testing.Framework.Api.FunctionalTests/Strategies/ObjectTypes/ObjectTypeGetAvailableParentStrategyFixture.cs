﻿using FluentAssertions;
using NUnit.Framework;
using Relativity.Testing.Framework.Api.Strategies;
using Relativity.Testing.Framework.Models;

namespace Relativity.Testing.Framework.Api.FunctionalTests.Strategies
{
	[TestOf(typeof(IGetWorkspaceEntityByIdStrategy<ObjectType>))]
	internal class ObjectTypeGetAvailableParentStrategyFixture : ApiServiceTestFixture<IGetAvailableParentObjectTypesStrategy>
	{
		public ObjectTypeGetAvailableParentStrategyFixture()
		{
		}

		public ObjectTypeGetAvailableParentStrategyFixture(string relativityInstanceAlias)
			: base(relativityInstanceAlias)
		{
		}

		[Test]
		public void GetAvailableParentObjectTypes()
		{
			var result = Sut.GetAvailableParentObjectTypes(DefaultWorkspace.ArtifactID);

			result.Should().NotBeNullOrEmpty();
		}
	}
}
