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
        [Trait("Table", "DeploymentEnvironment")]
        [Trait("Area", "Services")]
        public partial class DeploymentEnvironmentServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        var records = new List<DeploymentEnvironment>();
                        records.Add(new DeploymentEnvironment());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        List<ApiDeploymentEnvironmentResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        var record = new DeploymentEnvironment();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        ApiDeploymentEnvironmentResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<DeploymentEnvironment>(null));
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        ApiDeploymentEnvironmentResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        var model = new ApiDeploymentEnvironmentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeploymentEnvironment>())).Returns(Task.FromResult(new DeploymentEnvironment()));
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        CreateResponse<ApiDeploymentEnvironmentResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeploymentEnvironmentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DeploymentEnvironment>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        var model = new ApiDeploymentEnvironmentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeploymentEnvironment>())).Returns(Task.FromResult(new DeploymentEnvironment()));
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiDeploymentEnvironmentRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DeploymentEnvironment>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        var model = new ApiDeploymentEnvironmentRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        var record = new DeploymentEnvironment();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        ApiDeploymentEnvironmentResponseModel response = await service.GetName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<DeploymentEnvironment>(null));
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        ApiDeploymentEnvironmentResponseModel response = await service.GetName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetDataVersion_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        var records = new List<DeploymentEnvironment>();
                        records.Add(new DeploymentEnvironment());
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult(records));
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        List<ApiDeploymentEnvironmentResponseModel> response = await service.GetDataVersion(default(byte[]));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }

                [Fact]
                public async void GetDataVersion_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IDeploymentEnvironmentRepository>();
                        mock.RepositoryMock.Setup(x => x.GetDataVersion(It.IsAny<byte[]>())).Returns(Task.FromResult<List<DeploymentEnvironment>>(new List<DeploymentEnvironment>()));
                        var service = new DeploymentEnvironmentService(mock.LoggerMock.Object,
                                                                       mock.RepositoryMock.Object,
                                                                       mock.ModelValidatorMockFactory.DeploymentEnvironmentModelValidatorMock.Object,
                                                                       mock.BOLMapperMockFactory.BOLDeploymentEnvironmentMapperMock,
                                                                       mock.DALMapperMockFactory.DALDeploymentEnvironmentMapperMock);

                        List<ApiDeploymentEnvironmentResponseModel> response = await service.GetDataVersion(default(byte[]));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetDataVersion(It.IsAny<byte[]>()));
                }
        }
}

/*<Codenesium>
    <Hash>7c58d5a12ddbab3ff9c777223b4fc391</Hash>
</Codenesium>*/