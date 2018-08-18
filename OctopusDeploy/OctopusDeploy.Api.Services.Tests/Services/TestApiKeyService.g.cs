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
	[Trait("Table", "ApiKey")]
	[Trait("Area", "Services")]
	public partial class ApiKeyServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IApiKeyRepository>();
			var records = new List<ApiKey>();
			records.Add(new ApiKey());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ApiKeyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLApiKeyMapperMock,
			                                mock.DALMapperMockFactory.DALApiKeyMapperMock);

			List<ApiApiKeyResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IApiKeyRepository>();
			var record = new ApiKey();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ApiKeyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLApiKeyMapperMock,
			                                mock.DALMapperMockFactory.DALApiKeyMapperMock);

			ApiApiKeyResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IApiKeyRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(null));
			var service = new ApiKeyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLApiKeyMapperMock,
			                                mock.DALMapperMockFactory.DALApiKeyMapperMock);

			ApiApiKeyResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IApiKeyRepository>();
			var model = new ApiApiKeyRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ApiKey>())).Returns(Task.FromResult(new ApiKey()));
			var service = new ApiKeyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLApiKeyMapperMock,
			                                mock.DALMapperMockFactory.DALApiKeyMapperMock);

			CreateResponse<ApiApiKeyResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiApiKeyRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ApiKey>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IApiKeyRepository>();
			var model = new ApiApiKeyRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ApiKey>())).Returns(Task.FromResult(new ApiKey()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ApiKey()));
			var service = new ApiKeyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLApiKeyMapperMock,
			                                mock.DALMapperMockFactory.DALApiKeyMapperMock);

			UpdateResponse<ApiApiKeyResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiApiKeyRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ApiKey>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IApiKeyRepository>();
			var model = new ApiApiKeyRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new ApiKeyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLApiKeyMapperMock,
			                                mock.DALMapperMockFactory.DALApiKeyMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}

		[Fact]
		public async void ByApiKeyHashed_Exists()
		{
			var mock = new ServiceMockFacade<IApiKeyRepository>();
			var record = new ApiKey();
			mock.RepositoryMock.Setup(x => x.ByApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ApiKeyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLApiKeyMapperMock,
			                                mock.DALMapperMockFactory.DALApiKeyMapperMock);

			ApiApiKeyResponseModel response = await service.ByApiKeyHashed(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByApiKeyHashed(It.IsAny<string>()));
		}

		[Fact]
		public async void ByApiKeyHashed_Not_Exists()
		{
			var mock = new ServiceMockFacade<IApiKeyRepository>();
			mock.RepositoryMock.Setup(x => x.ByApiKeyHashed(It.IsAny<string>())).Returns(Task.FromResult<ApiKey>(null));
			var service = new ApiKeyService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.ApiKeyModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLApiKeyMapperMock,
			                                mock.DALMapperMockFactory.DALApiKeyMapperMock);

			ApiApiKeyResponseModel response = await service.ByApiKeyHashed(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByApiKeyHashed(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>d45e14c8c1ceb28045ddb8967e9789bc</Hash>
</Codenesium>*/