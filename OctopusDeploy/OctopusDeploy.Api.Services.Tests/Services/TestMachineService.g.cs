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
        [Trait("Table", "Machine")]
        [Trait("Area", "Services")]
        public partial class MachineServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        var records = new List<Machine>();
                        records.Add(new Machine());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        List<ApiMachineResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        var record = new Machine();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        ApiMachineResponseModel response = await service.Get(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult<Machine>(null));
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        ApiMachineResponseModel response = await service.Get(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<string>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        var model = new ApiMachineRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Machine>())).Returns(Task.FromResult(new Machine()));
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        CreateResponse<ApiMachineResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.MachineModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiMachineRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Machine>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        var model = new ApiMachineRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Machine>())).Returns(Task.FromResult(new Machine()));
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        ActionResponse response = await service.Update(default(string), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.MachineModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<string>(), It.IsAny<ApiMachineRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Machine>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        var model = new ApiMachineRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(Task.CompletedTask);
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        ActionResponse response = await service.Delete(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<string>()));
                        mock.ModelValidatorMockFactory.MachineModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Exists()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        var record = new Machine();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        ApiMachineResponseModel response = await service.ByName(default(string));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByName_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Machine>(null));
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        ApiMachineResponseModel response = await service.ByName(default(string));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
                }

                [Fact]
                public async void ByMachinePolicyId_Exists()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        var records = new List<Machine>();
                        records.Add(new Machine());
                        mock.RepositoryMock.Setup(x => x.ByMachinePolicyId(It.IsAny<string>())).Returns(Task.FromResult(records));
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        List<ApiMachineResponseModel> response = await service.ByMachinePolicyId(default(string));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByMachinePolicyId(It.IsAny<string>()));
                }

                [Fact]
                public async void ByMachinePolicyId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IMachineRepository>();
                        mock.RepositoryMock.Setup(x => x.ByMachinePolicyId(It.IsAny<string>())).Returns(Task.FromResult<List<Machine>>(new List<Machine>()));
                        var service = new MachineService(mock.LoggerMock.Object,
                                                         mock.RepositoryMock.Object,
                                                         mock.ModelValidatorMockFactory.MachineModelValidatorMock.Object,
                                                         mock.BOLMapperMockFactory.BOLMachineMapperMock,
                                                         mock.DALMapperMockFactory.DALMachineMapperMock);

                        List<ApiMachineResponseModel> response = await service.ByMachinePolicyId(default(string));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByMachinePolicyId(It.IsAny<string>()));
                }
        }
}

/*<Codenesium>
    <Hash>78eb6a1741f2ccbada32557bffb4cb26</Hash>
</Codenesium>*/