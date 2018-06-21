using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "MachineRefTeam")]
        [Trait("Area", "Services")]
        public partial class MachineRefTeamServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
                        var records = new List<MachineRefTeam>();
                        records.Add(new MachineRefTeam());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new MachineRefTeamService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                                mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        List<ApiMachineRefTeamResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
                        var record = new MachineRefTeam();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new MachineRefTeamService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                                mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        ApiMachineRefTeamResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<MachineRefTeam>(null));
                        var service = new MachineRefTeamService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                                mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        ApiMachineRefTeamResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
                        var model = new ApiMachineRefTeamRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<MachineRefTeam>())).Returns(Task.FromResult(new MachineRefTeam()));
                        var service = new MachineRefTeamService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                                mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        CreateResponse<ApiMachineRefTeamResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRefTeamRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<MachineRefTeam>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
                        var model = new ApiMachineRefTeamRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<MachineRefTeam>())).Returns(Task.FromResult(new MachineRefTeam()));
                        var service = new MachineRefTeamService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                                mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiMachineRefTeamRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<MachineRefTeam>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IMachineRefTeamRepository>();
                        var model = new ApiMachineRefTeamRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new MachineRefTeamService(mock.LoggerMock.Object,
                                                                mock.RepositoryMock.Object,
                                                                mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Object,
                                                                mock.BOLMapperMockFactory.BOLMachineRefTeamMapperMock,
                                                                mock.DALMapperMockFactory.DALMachineRefTeamMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.MachineRefTeamModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>bdf2c55b0883012177ca8862a99fc9eb</Hash>
</Codenesium>*/