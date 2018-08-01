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
	[Trait("Table", "Project")]
	[Trait("Area", "Services")]
	public partial class ProjectServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			var records = new List<Project>();
			records.Add(new Project());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			List<ApiProjectResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			var record = new Project();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			ApiProjectResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Project>(null));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			ApiProjectResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			var model = new ApiProjectRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Project>())).Returns(Task.FromResult(new Project()));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			CreateResponse<ApiProjectResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProjectRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Project>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			var model = new ApiProjectRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Project>())).Returns(Task.FromResult(new Project()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Project()));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			UpdateResponse<ApiProjectResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiProjectRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Project>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			var model = new ApiProjectRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			var record = new Project();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			ApiProjectResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Project>(null));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			ApiProjectResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void BySlug_Exists()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			var record = new Project();
			mock.RepositoryMock.Setup(x => x.BySlug(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			ApiProjectResponseModel response = await service.BySlug(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.BySlug(It.IsAny<string>()));
		}

		[Fact]
		public async void BySlug_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			mock.RepositoryMock.Setup(x => x.BySlug(It.IsAny<string>())).Returns(Task.FromResult<Project>(null));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			ApiProjectResponseModel response = await service.BySlug(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.BySlug(It.IsAny<string>()));
		}

		[Fact]
		public async void ByDataVersion_Exists()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			var records = new List<Project>();
			records.Add(new Project());
			mock.RepositoryMock.Setup(x => x.ByDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult(records));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			List<ApiProjectResponseModel> response = await service.ByDataVersion(default(byte[]));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDataVersion(It.IsAny<byte[]>()));
		}

		[Fact]
		public async void ByDataVersion_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			mock.RepositoryMock.Setup(x => x.ByDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult<List<Project>>(new List<Project>()));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			List<ApiProjectResponseModel> response = await service.ByDataVersion(default(byte[]));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDataVersion(It.IsAny<byte[]>()));
		}

		[Fact]
		public async void ByDiscreteChannelReleaseId_Exists()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			var records = new List<Project>();
			records.Add(new Project());
			mock.RepositoryMock.Setup(x => x.ByDiscreteChannelReleaseId(It.IsAny<bool>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			List<ApiProjectResponseModel> response = await service.ByDiscreteChannelReleaseId(default(bool), default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDiscreteChannelReleaseId(It.IsAny<bool>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ByDiscreteChannelReleaseId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IProjectRepository>();
			mock.RepositoryMock.Setup(x => x.ByDiscreteChannelReleaseId(It.IsAny<bool>(), It.IsAny<string>())).Returns(Task.FromResult<List<Project>>(new List<Project>()));
			var service = new ProjectService(mock.LoggerMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.ProjectModelValidatorMock.Object,
			                                 mock.BOLMapperMockFactory.BOLProjectMapperMock,
			                                 mock.DALMapperMockFactory.DALProjectMapperMock);

			List<ApiProjectResponseModel> response = await service.ByDiscreteChannelReleaseId(default(bool), default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDiscreteChannelReleaseId(It.IsAny<bool>(), It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>375f3e8f76b91c7b27b42f768717a893</Hash>
</Codenesium>*/