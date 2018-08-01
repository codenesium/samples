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
	[Trait("Table", "ExtensionConfiguration")]
	[Trait("Area", "Services")]
	public partial class ExtensionConfigurationServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IExtensionConfigurationRepository>();
			var records = new List<ExtensionConfiguration>();
			records.Add(new ExtensionConfiguration());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new ExtensionConfigurationService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.ExtensionConfigurationModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLExtensionConfigurationMapperMock,
			                                                mock.DALMapperMockFactory.DALExtensionConfigurationMapperMock);

			List<ApiExtensionConfigurationResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IExtensionConfigurationRepository>();
			var record = new ExtensionConfiguration();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new ExtensionConfigurationService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.ExtensionConfigurationModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLExtensionConfigurationMapperMock,
			                                                mock.DALMapperMockFactory.DALExtensionConfigurationMapperMock);

			ApiExtensionConfigurationResponseModel response = await service.Get(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IExtensionConfigurationRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ExtensionConfiguration>(null));
			var service = new ExtensionConfigurationService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.ExtensionConfigurationModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLExtensionConfigurationMapperMock,
			                                                mock.DALMapperMockFactory.DALExtensionConfigurationMapperMock);

			ApiExtensionConfigurationResponseModel response = await service.Get(default(string));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IExtensionConfigurationRepository>();
			var model = new ApiExtensionConfigurationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ExtensionConfiguration>())).Returns(Task.FromResult(new ExtensionConfiguration()));
			var service = new ExtensionConfigurationService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.ExtensionConfigurationModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLExtensionConfigurationMapperMock,
			                                                mock.DALMapperMockFactory.DALExtensionConfigurationMapperMock);

			CreateResponse<ApiExtensionConfigurationResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ExtensionConfigurationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiExtensionConfigurationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ExtensionConfiguration>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IExtensionConfigurationRepository>();
			var model = new ApiExtensionConfigurationRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ExtensionConfiguration>())).Returns(Task.FromResult(new ExtensionConfiguration()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ExtensionConfiguration()));
			var service = new ExtensionConfigurationService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.ExtensionConfigurationModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLExtensionConfigurationMapperMock,
			                                                mock.DALMapperMockFactory.DALExtensionConfigurationMapperMock);

			UpdateResponse<ApiExtensionConfigurationResponseModel> response = await service.Update(default(string), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.ExtensionConfigurationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiExtensionConfigurationRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ExtensionConfiguration>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IExtensionConfigurationRepository>();
			var model = new ApiExtensionConfigurationRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
			var service = new ExtensionConfigurationService(mock.LoggerMock.Object,
			                                                mock.RepositoryMock.Object,
			                                                mock.ModelValidatorMockFactory.ExtensionConfigurationModelValidatorMock.Object,
			                                                mock.BOLMapperMockFactory.BOLExtensionConfigurationMapperMock,
			                                                mock.DALMapperMockFactory.DALExtensionConfigurationMapperMock);

			ActionResponse response = await service.Delete(default(string));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
			mock.ModelValidatorMockFactory.ExtensionConfigurationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
		}
	}
}

/*<Codenesium>
    <Hash>84bb688130fce78e3fe78f29d599c3c4</Hash>
</Codenesium>*/