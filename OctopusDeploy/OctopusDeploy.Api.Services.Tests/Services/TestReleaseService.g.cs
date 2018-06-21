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
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

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
                public async void GetVersionProjectId_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        var record = new Release();
                        mock.RepositoryMock.Setup(x => x.GetVersionProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        ApiReleaseResponseModel response = await service.GetVersionProjectId(default(string), default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetVersionProjectId(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetVersionProjectId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        mock.RepositoryMock.Setup(x => x.GetVersionProjectId(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<Release>(null));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        ApiReleaseResponseModel response = await service.GetVersionProjectId(default(string), default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetVersionProjectId(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void GetIdAssembled_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        var records = new List<Release>();
                        records.Add(new Release());
                        mock.RepositoryMock.Setup(x => x.GetIdAssembled(It.IsAny<string>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(records));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        List<ApiReleaseResponseModel> response = await service.GetIdAssembled(default(string), default(DateTimeOffset));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdAssembled(It.IsAny<string>(), It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetIdAssembled_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        mock.RepositoryMock.Setup(x => x.GetIdAssembled(It.IsAny<string>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult<List<Release>>(new List<Release>()));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        List<ApiReleaseResponseModel> response = await service.GetIdAssembled(default(string), default(DateTimeOffset));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdAssembled(It.IsAny<string>(), It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetProjectDeploymentProcessSnapshotId_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        var records = new List<Release>();
                        records.Add(new Release());
                        mock.RepositoryMock.Setup(x => x.GetProjectDeploymentProcessSnapshotId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        List<ApiReleaseResponseModel> response = await service.GetProjectDeploymentProcessSnapshotId(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetProjectDeploymentProcessSnapshotId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetProjectDeploymentProcessSnapshotId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        mock.RepositoryMock.Setup(x => x.GetProjectDeploymentProcessSnapshotId(It.IsAny<string>())).Returns(Task.FromResult<List<Release>>(new List<Release>()));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        List<ApiReleaseResponseModel> response = await service.GetProjectDeploymentProcessSnapshotId(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetProjectDeploymentProcessSnapshotId(It.IsAny<string>()));
                }

                [Fact]
                public async void GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        var records = new List<Release>();
                        records.Add(new Release());
                        mock.RepositoryMock.Setup(x => x.GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(records));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        List<ApiReleaseResponseModel> response = await service.GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(default(string), default(string), default(string), default(string), default(string), default(string), default(string), default(DateTimeOffset));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        mock.RepositoryMock.Setup(x => x.GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult<List<Release>>(new List<Release>()));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        List<ApiReleaseResponseModel> response = await service.GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(default(string), default(string), default(string), default(string), default(string), default(string), default(string), default(DateTimeOffset));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        var records = new List<Release>();
                        records.Add(new Release());
                        mock.RepositoryMock.Setup(x => x.GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult(records));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        List<ApiReleaseResponseModel> response = await service.GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(default(string), default(string), default(string), default(string), default(string), default(string), default(string), default(DateTimeOffset));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>()));
                }

                [Fact]
                public async void GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IReleaseRepository>();
                        mock.RepositoryMock.Setup(x => x.GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>())).Returns(Task.FromResult<List<Release>>(new List<Release>()));
                        var service = new ReleaseService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.ReleaseModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLReleaseMapperMock,
                                                         mock.DALMapperMockFactory.DALReleaseMapperMock);

                        List<ApiReleaseResponseModel> response = await service.GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(default(string), default(string), default(string), default(string), default(string), default(string), default(string), default(DateTimeOffset));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.GetIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>()));
                }
        }
}

/*<Codenesium>
    <Hash>04dd330dc73fc094b53f30669599ca95</Hash>
</Codenesium>*/