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
        [Trait("Table", "Team")]
        [Trait("Area", "Services")]
        public partial class TeamServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var records = new List<Team>();
                        records.Add(new Team());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock);

                        List<ApiTeamResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var record = new Team();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock);

                        ApiTeamResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Team>(null));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock);

                        ApiTeamResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var model = new ApiTeamRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Team>())).Returns(Task.FromResult(new Team()));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock);

                        CreateResponse<ApiTeamResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTeamRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Team>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var model = new ApiTeamRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Team>())).Returns(Task.FromResult(new Team()));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiTeamRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Team>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var model = new ApiTeamRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Exists()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var record = new Team();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock);

                        ApiTeamResponseModel response = await service.GetName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }

                [Fact]
                public async void GetName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        mock.RepositoryMock.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Team>(null));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock);

                        ApiTeamResponseModel response = await service.GetName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.GetName(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>3d3b87ab62a5eb8d86b3050e3b404216</Hash>
</Codenesium>*/