﻿using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Relativity.Testing.Framework.Api.Services;
using Relativity.Testing.Framework.Api.Strategies;
using Relativity.Testing.Framework.Api.Validators;
using Relativity.Testing.Framework.Models;

namespace Relativity.Testing.Framework.Api.Tests.Strategies
{
	[TestFixture]
	[TestOf(typeof(MatterGetByIdStrategyV1))]
	public class MatterGetByIdStrategyV1Fixture
	{
		private const int _MATTER_ID = 1;
		private readonly string _getUrl = $"relativity-environment/v1/workspaces/-1/matters/{_MATTER_ID}";
		private readonly string _getWithExtendedMetadata = $"relativity-environment/v1/workspaces/-1/matters/{_MATTER_ID}/true/true";
		private readonly Meta _meta = new Meta
		{
			ReadOnly = new List<string> { "Test", "Readonly" },
			Unsupported = new List<string> { "Test", "Unsupported", "Items" }
		};

		private Mock<IRestService> _mockRestService;
		private Mock<IMatterGetEligibleStatusesStrategy> _mockGetMatterEligibleStatusesStrategy;
		private Mock<IMatterGetEligibleClientsStrategy> _mockGetMatterEligibleClientsStrategy;
		private Mock<IArtifactIdValidator> _mockArtifactIdValidator;
		private MatterGetByIdStrategyV1 _sut;

		[SetUp]
		public void SetUp()
		{
			_mockRestService = new Mock<IRestService>();
			int clientID = 3;
			int statusID = 2;
			SetupRestServiceMock(clientID, statusID);
			SetupGetMatterEligibleStatusesStrategyMock(statusID);
			SetupGetMatterEligibleClientsStrategyMock(clientID);
			_mockArtifactIdValidator = new Mock<IArtifactIdValidator>();

			_sut = new MatterGetByIdStrategyV1(
				_mockRestService.Object, _mockGetMatterEligibleStatusesStrategy.Object, _mockGetMatterEligibleClientsStrategy.Object, _mockArtifactIdValidator.Object);
		}

		[Test]
		public void Get_WithValidIdWithoutExtendedMetadata_ShouldCallRestServiceWithExpectedUrl()
		{
			_sut.Get(_MATTER_ID);
			_mockRestService.Verify(restService => restService.Get<MatterDTOV1>(_getUrl, null), Times.Once);
		}

		[Test]
		public void Get_WithValidIdWithExtendedMetadata_ShouldCallRestServiceWithExpectedUrl()
		{
			_sut.Get(_MATTER_ID, true);
			_mockRestService.Verify(restService => restService.Get<MatterDTOV1>(_getWithExtendedMetadata, null), Times.Once);
		}

		[Test]
		public void Get_WithValidIdWithExtendedMetadata_ShouldReturnEntityWithMetaFilled()
		{
			Matter result = _sut.Get(_MATTER_ID, true);

			Assert.NotNull(result.Meta);
			Assert.NotNull(result.Meta.ReadOnly);
			Assert.IsNotEmpty(result.Meta.ReadOnly);
			result.Meta.ReadOnly.Should().BeEquivalentTo(_meta.ReadOnly);
			Assert.NotNull(result.Meta.Unsupported);
			Assert.IsNotEmpty(result.Meta.Unsupported);
			result.Meta.Unsupported.Should().BeEquivalentTo(_meta.Unsupported);
		}

		[Test]
		public void Get_WithAnyId_ShouldCallArtifactIdValidator()
		{
			_sut.Get(_MATTER_ID);
			_mockArtifactIdValidator.Verify(validator => validator.Validate(_MATTER_ID, "Matter"), Times.Once);
		}

		[Test]
		public void Get_WithValidId_ShouldCallGetEligibleStatusesStrategy()
		{
			_sut.Get(_MATTER_ID);
			_mockGetMatterEligibleStatusesStrategy.Verify(statusesStrategy => statusesStrategy.GetAll(), Times.Once);
		}

		[Test]
		public void Get_WithValidId_ShouldCallGetEligibleClientsStrategy()
		{
			_sut.Get(_MATTER_ID);
			_mockGetMatterEligibleClientsStrategy.Verify(clientsStrategy => clientsStrategy.GetAll(), Times.Once);
		}

		private void SetupGetMatterEligibleClientsStrategyMock(int clientID)
		{
			_mockGetMatterEligibleClientsStrategy = new Mock<IMatterGetEligibleClientsStrategy>();
			var client = new ArtifactIdNamePair
			{
				ArtifactID = clientID,
				Name = "Test Client"
			};
			_mockGetMatterEligibleClientsStrategy.Setup(getClientsStrategy => getClientsStrategy.GetAll()).Returns(new[] { client });
		}

		private void SetupGetMatterEligibleStatusesStrategyMock(int statusID)
		{
			_mockGetMatterEligibleStatusesStrategy = new Mock<IMatterGetEligibleStatusesStrategy>();
			var status = new ArtifactIdNamePair
			{
				ArtifactID = statusID,
				Name = "Test Status"
			};
			_mockGetMatterEligibleStatusesStrategy.Setup(getStatusesStrategy => getStatusesStrategy.GetAll()).Returns(new[] { status });
		}

		private void SetupRestServiceMock(int clientID, int statusID)
		{
			var matterDTO = new MatterDTOV1
			{
				Client = new Securable<Artifact>(new Artifact(clientID)),
				Status = new Securable<Artifact>(new Artifact(statusID))
			};
			_mockRestService.Setup(restService => restService.Get<MatterDTOV1>(_getUrl, null)).Returns(matterDTO);
			matterDTO.Meta = _meta;
			_mockRestService.Setup(restService => restService.Get<MatterDTOV1>(_getWithExtendedMetadata, null)).Returns(matterDTO);
		}
	}
}
