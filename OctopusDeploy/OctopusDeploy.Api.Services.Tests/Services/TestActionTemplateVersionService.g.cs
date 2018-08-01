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
	[Trait("Table", "ActionTemplateVersion")]
	[Trait("Area", "Services")]
	public partial class ActionTemplateVersionServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			var records = new List<ActionTemplateVersion>();
			records.Add(new ActionTemplateVersion());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			List<ApiActionTemplateVersionResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			var record = new ActionTemplateVersion();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			ApiActionTemplateVersionResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ActionTemplateVersion>(null));
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			ApiActionTemplateVersionResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			var model = new ApiActionTemplateVersionRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ActionTemplateVersion>())).Returns(Task.FromResult(new ActionTemplateVersion()));
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			CreateResponse<ApiActionTemplateVersionResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiActionTemplateVersionRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ActionTemplateVersion>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			var model = new ApiActionTemplateVersionRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ActionTemplateVersion>())).Returns(Task.FromResult(new ActionTemplateVersion()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ActionTemplateVersion()));
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			UpdateResponse<ApiActionTemplateVersionResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiActionTemplateVersionRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ActionTemplateVersion>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			var model = new ApiActionTemplateVersionRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByNameVersion_Exists()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			var record = new ActionTemplateVersion();
			mock.RepositoryMock.Setup(x => x.ByNameVersion(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			ApiActionTemplateVersionResponseModel response = await service.ByNameVersion(default(string), default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByNameVersion(It.IsAny<string>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByNameVersion_Not_Exists()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			mock.RepositoryMock.Setup(x => x.ByNameVersion(It.IsAny<string>(), It.IsAny<int>())).Returns(Task.FromResult<ActionTemplateVersion>(null));
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			ApiActionTemplateVersionResponseModel response = await service.ByNameVersion(default(string), default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByNameVersion(It.IsAny<string>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByLatestActionTemplateId_Exists()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			var records = new List<ActionTemplateVersion>();
			records.Add(new ActionTemplateVersion());
			mock.RepositoryMock.Setup(x => x.ByLatestActionTemplateId(It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			List<ApiActionTemplateVersionResponseModel> response = await service.ByLatestActionTemplateId(default(string));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLatestActionTemplateId(It.IsAny<string>()));
		}

		[Fact]
		public async void ByLatestActionTemplateId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IActionTemplateVersionRepository>();
			mock.RepositoryMock.Setup(x => x.ByLatestActionTemplateId(It.IsAny<string>())).Returns(Task.FromResult<List<ActionTemplateVersion>>(new List<ActionTemplateVersion>()));
			var service = new ActionTemplateVersionService(mock.LoggerMock.Object,
			                                               mock.RepositoryMock.Object,
			                                               mock.ModelValidatorMockFactory.ActionTemplateVersionModelValidatorMock.Object,
			                                               mock.BOLMapperMockFactory.BOLActionTemplateVersionMapperMock,
			                                               mock.DALMapperMockFactory.DALActionTemplateVersionMapperMock);

			List<ApiActionTemplateVersionResponseModel> response = await service.ByLatestActionTemplateId(default(string));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByLatestActionTemplateId(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>fe8721c8912afbb2b403633917bfde38</Hash>
</Codenesium>*/