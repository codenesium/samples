using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DeviceAction")]
        [Trait("Area", "Services")]
        public partial class DeviceActionServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<IDeviceActionRepository>();
                        var records = new List<DeviceAction>();
                        records.Add(new DeviceAction());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new DeviceActionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
                                                              mock.DALMapperMockFactory.DALDeviceActionMapperMock);

                        List<ApiDeviceActionResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<IDeviceActionRepository>();
                        var record = new DeviceAction();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new DeviceActionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
                                                              mock.DALMapperMockFactory.DALDeviceActionMapperMock);

                        ApiDeviceActionResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<IDeviceActionRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<DeviceAction>(null));
                        var service = new DeviceActionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
                                                              mock.DALMapperMockFactory.DALDeviceActionMapperMock);

                        ApiDeviceActionResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<IDeviceActionRepository>();
                        var model = new ApiDeviceActionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeviceAction>())).Returns(Task.FromResult(new DeviceAction()));
                        var service = new DeviceActionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
                                                              mock.DALMapperMockFactory.DALDeviceActionMapperMock);

                        CreateResponse<ApiDeviceActionResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceActionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DeviceAction>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<IDeviceActionRepository>();
                        var model = new ApiDeviceActionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeviceAction>())).Returns(Task.FromResult(new DeviceAction()));
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));
                        var service = new DeviceActionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
                                                              mock.DALMapperMockFactory.DALDeviceActionMapperMock);

                        UpdateResponse<ApiDeviceActionResponseModel> response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceActionRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DeviceAction>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<IDeviceActionRepository>();
                        var model = new ApiDeviceActionRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new DeviceActionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
                                                              mock.DALMapperMockFactory.DALDeviceActionMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByDeviceId_Exists()
                {
                        var mock = new ServiceMockFacade<IDeviceActionRepository>();
                        var records = new List<DeviceAction>();
                        records.Add(new DeviceAction());
                        mock.RepositoryMock.Setup(x => x.ByDeviceId(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new DeviceActionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
                                                              mock.DALMapperMockFactory.DALDeviceActionMapperMock);

                        List<ApiDeviceActionResponseModel> response = await service.ByDeviceId(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDeviceId(It.IsAny<int>()));
                }

                [Fact]
                public async void ByDeviceId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<IDeviceActionRepository>();
                        mock.RepositoryMock.Setup(x => x.ByDeviceId(It.IsAny<int>())).Returns(Task.FromResult<List<DeviceAction>>(new List<DeviceAction>()));
                        var service = new DeviceActionService(mock.LoggerMock.Object,
                                                              mock.RepositoryMock.Object,
                                                              mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
                                                              mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
                                                              mock.DALMapperMockFactory.DALDeviceActionMapperMock);

                        List<ApiDeviceActionResponseModel> response = await service.ByDeviceId(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByDeviceId(It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>7eea157888e8435e5de0a2be9f800002</Hash>
</Codenesium>*/