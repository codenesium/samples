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
        [Trait("Table", "ProjectTrigger")]
        [Trait("Area", "Services")]
        public partial class ProjectTriggerServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        var records = new List<ProjectTrigger>();
                        records.Add(new ProjectTrigger());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        List<ApiProjectTriggerResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        var record = new ProjectTrigger();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        ApiProjectTriggerResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(null));
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        ApiProjectTriggerResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        var model = new ApiProjectTriggerRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProjectTrigger>())).Returns(Task.FromResult(new ProjectTrigger()));
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        CreateResponse<ApiProjectTriggerResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiProjectTriggerRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<ProjectTrigger>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        var model = new ApiProjectTriggerRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<ProjectTrigger>())).Returns(Task.FromResult(new ProjectTrigger()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectTrigger()));
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        UpdateResponse<ApiProjectTriggerResponseModel> response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiProjectTriggerRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<ProjectTrigger>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        var model = new ApiProjectTriggerRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByProjectIdName_Exists()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        var record = new ProjectTrigger();
                        mock.RepositoryMock.Setup(x => x.ByProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        ApiProjectTriggerResponseModel response = await service.ByProjectIdName(default(string), default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByProjectIdName(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void ByProjectIdName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProjectIdName(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<ProjectTrigger>(null));
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        ApiProjectTriggerResponseModel response = await service.ByProjectIdName(default(string), default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByProjectIdName(It.IsAny<string>(), It.IsAny<string>()));
                }

                [Fact]
                public async void ByProjectId_Exists()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        var records = new List<ProjectTrigger>();
                        records.Add(new ProjectTrigger());
                        mock.RepositoryMock.Setup(x => x.ByProjectId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        List<ApiProjectTriggerResponseModel> response = await service.ByProjectId(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProjectId(It.IsAny<string>()));
                }

                [Fact]
                public async void ByProjectId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IProjectTriggerRepository>();
                        mock.RepositoryMock.Setup(x => x.ByProjectId(It.IsAny<string>())).Returns(Task.FromResult<List<ProjectTrigger>>(new List<ProjectTrigger>()));
                        var service = new ProjectTriggerService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.ProjectTriggerModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLProjectTriggerMapperMock,
                                                                mock.DALMapperMockFactory.DALProjectTriggerMapperMock);

                        List<ApiProjectTriggerResponseModel> response = await service.ByProjectId(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByProjectId(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>2bc20462c79d8224c06d76ab99b4e82b</Hash>
</Codenesium>*/