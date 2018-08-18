using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Release")]
	[Trait("Area", "Services")]
	public partial class ReleaseServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var records = new List<Release>();
			records.Add(new Release());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			List<ApiReleaseResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var record = new Release();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			ApiReleaseResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Release>(null));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			ApiReleaseResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var model = new ApiReleaseRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Release>())).Returns(Task.FromResult(new Release()));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			CreateResponse<ApiReleaseResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiReleaseRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Release>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var model = new ApiReleaseRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Release>())).Returns(Task.FromResult(new Release()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Release()));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			UpdateResponse<ApiReleaseResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiReleaseRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Release>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var model = new ApiReleaseRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByVersionProjectId_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var record = new Release();
			mock.RepositoryMock.Setup(x => x.ByVersionProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			ApiReleaseResponseModel response = await service.ByVersionProjectId(default(string), default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByVersionProjectId(It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByVersionProjectId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			mock.RepositoryMock.Setup(x => x.ByVersionProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Release>(null));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			ApiReleaseResponseModel response = await service.ByVersionProjectId(default(string), default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByVersionProjectId(It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByIdAssembled_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var records = new List<Release>();
			records.Add(new Release());
			mock.RepositoryMock.Setup(x => x.ByIdAssembled(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			List<ApiReleaseResponseModel> response = await service.ByIdAssembled(default(string), default(DateTimeOffset));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByIdAssembled(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByIdAssembled_Not_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			mock.RepositoryMock.Setup(x => x.ByIdAssembled(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Release>>(new List<Release>()));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			List<ApiReleaseResponseModel> response = await service.ByIdAssembled(default(string), default(DateTimeOffset));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByIdAssembled(It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProjectDeploymentProcessSnapshotId_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var records = new List<Release>();
			records.Add(new Release());
			mock.RepositoryMock.Setup(x => x.ByProjectDeploymentProcessSnapshotId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			List<ApiReleaseResponseModel> response = await service.ByProjectDeploymentProcessSnapshotId(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProjectDeploymentProcessSnapshotId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProjectDeploymentProcessSnapshotId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			mock.RepositoryMock.Setup(x => x.ByProjectDeploymentProcessSnapshotId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Release>>(new List<Release>()));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			List<ApiReleaseResponseModel> response = await service.ByProjectDeploymentProcessSnapshotId(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProjectDeploymentProcessSnapshotId(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var records = new List<Release>();
			records.Add(new Release());
			mock.RepositoryMock.Setup(x => x.ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			List<ApiReleaseResponseModel> response = await service.ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(default(string), default(string), default(string), default(string), default(string), default(string), default(string), default(DateTimeOffset));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled_Not_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			mock.RepositoryMock.Setup(x => x.ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Release>>(new List<Release>()));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			List<ApiReleaseResponseModel> response = await service.ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(default(string), default(string), default(string), default(string), default(string), default(string), default(string), default(DateTimeOffset));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			var records = new List<Release>();
			records.Add(new Release());
			mock.RepositoryMock.Setup(x => x.ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			List<ApiReleaseResponseModel> response = await service.ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(default(string), default(string), default(string), default(string), default(string), default(string), default(string), default(DateTimeOffset));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled_Not_Exists()
		{
			var mock = new ServiceMockFacade<IReleaseRepository>();
			mock.RepositoryMock.Setup(x => x.ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Release>>(new List<Release>()));
			var service = new ReleaseService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLReleaseMapperMock,
			                                 mock.DALMapperMockFactory.DALReleaseMapperMock);

			List<ApiReleaseResponseModel> response = await service.ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(default(string), default(string), default(string), default(string), default(string), default(string), default(string), default(DateTimeOffset));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>0c0c6d3693f3dcbc97fe513e16a60a74</Hash>
</Codenesium>*/