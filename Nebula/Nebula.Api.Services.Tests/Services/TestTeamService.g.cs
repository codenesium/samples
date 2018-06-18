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
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services.Tests
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
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        List<ApiTeamResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var record = new Team();

                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        ApiTeamResponseModel response = await service.Get(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Team>(null));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        ApiTeamResponseModel response = await service.Get(default (int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
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
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

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
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        ActionResponse response = await service.Update(default (int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTeamRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Team>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var model = new ApiTeamRequestModel();

                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        ActionResponse response = await service.Delete(default (int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.TeamModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void Chains_Exists()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var records = new List<Chain>();
                        records.Add(new Chain());
                        mock.RepositoryMock.Setup(x => x.Chains(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        List<ApiChainResponseModel> response = await service.Chains(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.Chains(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Chains_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        mock.RepositoryMock.Setup(x => x.Chains(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Chain>>(new List<Chain>()));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        List<ApiChainResponseModel> response = await service.Chains(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.Chains(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void MachineRefTeams_Exists()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        var records = new List<MachineRefTeam>();
                        records.Add(new MachineRefTeam());
                        mock.RepositoryMock.Setup(x => x.MachineRefTeams(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        List<ApiMachineRefTeamResponseModel> response = await service.MachineRefTeams(default (int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.MachineRefTeams(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void MachineRefTeams_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITeamRepository>();
                        mock.RepositoryMock.Setup(x => x.MachineRefTeams(default (int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<MachineRefTeam>>(new List<MachineRefTeam>()));
                        var service = new TeamService(mock.LoggerMock.Object,
                                                      mock.RepositoryMock.Object,
                                                      mock.ModelValidatorMockFactory.TeamModelValidatorMock.Object,
                                                      mock.BOLMapperMockFactory.BOLTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALTeamMapperMock,
                                                      mock.BOLMapperMockFactory.BOLChainMapperMock,
                                                      mock.DALMapperMockFactory.DALChainMapperMock,
                                                      mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                      mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        List<ApiMachineRefTeamResponseModel> response = await service.MachineRefTeams(default (int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.MachineRefTeams(default (int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>7a2faeaffdb499bd70a64e341af891cb</Hash>
</Codenesium>*/