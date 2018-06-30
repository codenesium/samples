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
        [Trait("Table", "DashboardConfiguration")]
        [Trait("Area", "Services")]
        public partial class DashboardConfigurationServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IDashboardConfigurationRepository>();
                        var records = new List<DashboardConfiguration>();
                        records.Add(new DashboardConfiguration());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new DashboardConfigurationService(mock.LoggerMock.Object,
                                                                        mock.RepositoryMock.Object,
                                                                        mock.ModelValidatorMockFactory.DashboardConfigurationModelValidatorMock.Object,
                                                                        mock.BOLMapperMockFactory.BOLDashboardConfigurationMapperMock,
                                                                        mock.DALMapperMockFactory.DALDashboardConfigurationMapperMock);

                        List<ApiDashboardConfigurationResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IDashboardConfigurationRepository>();
                        var record = new DashboardConfiguration();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new DashboardConfigurationService(mock.LoggerMock.Object,
                                                                        mock.RepositoryMock.Object,
                                                                        mock.ModelValidatorMockFactory.DashboardConfigurationModelValidatorMock.Object,
                                                                        mock.BOLMapperMockFactory.BOLDashboardConfigurationMapperMock,
                                                                        mock.DALMapperMockFactory.DALDashboardConfigurationMapperMock);

                        ApiDashboardConfigurationResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IDashboardConfigurationRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<DashboardConfiguration>(null));
                        var service = new DashboardConfigurationService(mock.LoggerMock.Object,
                                                                        mock.RepositoryMock.Object,
                                                                        mock.ModelValidatorMockFactory.DashboardConfigurationModelValidatorMock.Object,
                                                                        mock.BOLMapperMockFactory.BOLDashboardConfigurationMapperMock,
                                                                        mock.DALMapperMockFactory.DALDashboardConfigurationMapperMock);

                        ApiDashboardConfigurationResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IDashboardConfigurationRepository>();
                        var model = new ApiDashboardConfigurationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DashboardConfiguration>())).Returns(Task.FromResult(new DashboardConfiguration()));
                        var service = new DashboardConfigurationService(mock.LoggerMock.Object,
                                                                        mock.RepositoryMock.Object,
                                                                        mock.ModelValidatorMockFactory.DashboardConfigurationModelValidatorMock.Object,
                                                                        mock.BOLMapperMockFactory.BOLDashboardConfigurationMapperMock,
                                                                        mock.DALMapperMockFactory.DALDashboardConfigurationMapperMock);

                        CreateResponse<ApiDashboardConfigurationResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DashboardConfigurationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDashboardConfigurationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DashboardConfiguration>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IDashboardConfigurationRepository>();
                        var model = new ApiDashboardConfigurationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DashboardConfiguration>())).Returns(Task.FromResult(new DashboardConfiguration()));
                        var service = new DashboardConfigurationService(mock.LoggerMock.Object,
                                                                        mock.RepositoryMock.Object,
                                                                        mock.ModelValidatorMockFactory.DashboardConfigurationModelValidatorMock.Object,
                                                                        mock.BOLMapperMockFactory.BOLDashboardConfigurationMapperMock,
                                                                        mock.DALMapperMockFactory.DALDashboardConfigurationMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DashboardConfigurationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDashboardConfigurationRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DashboardConfiguration>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IDashboardConfigurationRepository>();
                        var model = new ApiDashboardConfigurationRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new DashboardConfigurationService(mock.LoggerMock.Object,
                                                                        mock.RepositoryMock.Object,
                                                                        mock.ModelValidatorMockFactory.DashboardConfigurationModelValidatorMock.Object,
                                                                        mock.BOLMapperMockFactory.BOLDashboardConfigurationMapperMock,
                                                                        mock.DALMapperMockFactory.DALDashboardConfigurationMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.DashboardConfigurationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>2e99cac1485f08b7a9c73af64afafd2b</Hash>
</Codenesium>*/