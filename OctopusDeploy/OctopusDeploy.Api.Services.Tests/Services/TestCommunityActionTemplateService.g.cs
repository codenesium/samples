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
	[Trait("Table", "CommunityActionTemplate")]
	[Trait("Area", "Services")]
	public partial class CommunityActionTemplateServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			var records = new List<CommunityActionTemplate>();
			records.Add(new CommunityActionTemplate());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			List<ApiCommunityActionTemplateResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			var record = new CommunityActionTemplate();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			ApiCommunityActionTemplateResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<CommunityActionTemplate>(null));
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			ApiCommunityActionTemplateResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			var model = new ApiCommunityActionTemplateRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CommunityActionTemplate>())).Returns(Task.FromResult(new CommunityActionTemplate()));
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			CreateResponse<ApiCommunityActionTemplateResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCommunityActionTemplateRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CommunityActionTemplate>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			var model = new ApiCommunityActionTemplateRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CommunityActionTemplate>())).Returns(Task.FromResult(new CommunityActionTemplate()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new CommunityActionTemplate()));
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			UpdateResponse<ApiCommunityActionTemplateResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiCommunityActionTemplateRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CommunityActionTemplate>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			var model = new ApiCommunityActionTemplateRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByExternalId_Exists()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			var record = new CommunityActionTemplate();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			ApiCommunityActionTemplateResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByExternalId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<CommunityActionTemplate>(null));
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			ApiCommunityActionTemplateResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			var record = new CommunityActionTemplate();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			ApiCommunityActionTemplateResponseModel response = await service.ByName(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICommunityActionTemplateRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<CommunityActionTemplate>(null));
			var service = new CommunityActionTemplateService(mock.LoggerMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.CommunityActionTemplateModelValidatorMock.Object,
			                                                 mock.BOLMapperMockFactory.BOLCommunityActionTemplateMapperMock,
			                                                 mock.DALMapperMockFactory.DALCommunityActionTemplateMapperMock);

			ApiCommunityActionTemplateResponseModel response = await service.ByName(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>1940113b4df7e2cfa3d761dfb1658e39</Hash>
</Codenesium>*/