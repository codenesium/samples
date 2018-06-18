using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Configuration")]
        [Trait("Area", "Services")]
        public partial class ConfigurationServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IConfigurationRepository>();
                        var records = new List<Configuration>();
                        records.Add(new Configuration());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ConfigurationService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ConfigurationModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLConfigurationMapperMock,
                                                               mock.DALMapperMockFactory.DALConfigurationMapperMock);

                        List<ApiConfigurationResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IConfigurationRepository>();
                        var record = new Configuration();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ConfigurationService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ConfigurationModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLConfigurationMapperMock,
                                                               mock.DALMapperMockFactory.DALConfigurationMapperMock);

                        ApiConfigurationResponseModel response = await service.Get(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IConfigurationRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Configuration>(null));
                        var service = new ConfigurationService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ConfigurationModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLConfigurationMapperMock,
                                                               mock.DALMapperMockFactory.DALConfigurationMapperMock);

                        ApiConfigurationResponseModel response = await service.Get(default (string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IConfigurationRepository>();
                        var model = new ApiConfigurationRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Configuration>())).Returns(Task.FromResult(new Configuration()));
                        var service = new ConfigurationService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ConfigurationModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLConfigurationMapperMock,
                                                               mock.DALMapperMockFactory.DALConfigurationMapperMock);

                        CreateResponse<ApiConfigurationResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ConfigurationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiConfigurationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Configuration>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IConfigurationRepository>();
                        var model = new ApiConfigurationRequestModel();

                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Configuration>())).Returns(Task.FromResult(new Configuration()));
                        var service = new ConfigurationService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ConfigurationModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLConfigurationMapperMock,
                                                               mock.DALMapperMockFactory.DALConfigurationMapperMock);

                        ActionResponse response = await service.Update(default (string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ConfigurationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiConfigurationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Configuration>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IConfigurationRepository>();
                        var model = new ApiConfigurationRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new ConfigurationService(mock.LoggerMock.Object,
                                                               mock.RepositoryMock.Object,
                                                               mock.ModelValidatorMockFactory.ConfigurationModelValidatorMock.Object,
                                                               mock.BOLMapperMockFactory.BOLConfigurationMapperMock,
                                                               mock.DALMapperMockFactory.DALConfigurationMapperMock);

                        ActionResponse response = await service.Delete(default (string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.ConfigurationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>62a9a7a08e2bbef2b89fbd7f5f11ce28</Hash>
</Codenesium>*/