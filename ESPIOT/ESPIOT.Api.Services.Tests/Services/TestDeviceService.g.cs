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
	[Trait("Table", "Device")]
	[Trait("Area", "Services")]
	public partial class DeviceServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var records = new List<Device>();
			records.Add(new Device());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			List<ApiDeviceResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var record = new Device();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Device>(null));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var model = new ApiDeviceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Device>())).Returns(Task.FromResult(new Device()));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			CreateResponse<ApiDeviceResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Device>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var model = new ApiDeviceRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Device>())).Returns(Task.FromResult(new Device()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Device()));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			UpdateResponse<ApiDeviceResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Device>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var model = new ApiDeviceRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByPublicId_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var record = new Device();
			mock.RepositoryMock.Setup(x => x.ByPublicId(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceResponseModel response = await service.ByPublicId(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByPublicId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByPublicId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			mock.RepositoryMock.Setup(x => x.ByPublicId(It.IsAny<Guid>())).Returns(Task.FromResult<Device>(null));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceResponseModel response = await service.ByPublicId(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByPublicId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void DeviceActions_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var records = new List<DeviceAction>();
			records.Add(new DeviceAction());
			mock.RepositoryMock.Setup(x => x.DeviceActions(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			List<ApiDeviceActionResponseModel> response = await service.DeviceActions(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.DeviceActions(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void DeviceActions_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			mock.RepositoryMock.Setup(x => x.DeviceActions(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<DeviceAction>>(new List<DeviceAction>()));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.BOLMapperMockFactory.BOLDeviceActionMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			List<ApiDeviceActionResponseModel> response = await service.DeviceActions(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.DeviceActions(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>84d35f375ea851af40d1b329616e4daf</Hash>
</Codenesium>*/