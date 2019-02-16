using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
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
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			List<ApiDeviceServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var record = new Device();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Device>(null));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var model = new ApiDeviceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Device>())).Returns(Task.FromResult(new Device()));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			CreateResponse<ApiDeviceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Device>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var model = new ApiDeviceServerRequestModel();
			var validatorMock = new Mock<IApiDeviceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			CreateResponse<ApiDeviceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var model = new ApiDeviceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Device>())).Returns(Task.FromResult(new Device()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Device()));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			UpdateResponse<ApiDeviceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Device>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var model = new ApiDeviceServerRequestModel();
			var validatorMock = new Mock<IApiDeviceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Device()));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			UpdateResponse<ApiDeviceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var model = new ApiDeviceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var model = new ApiDeviceServerRequestModel();
			var validatorMock = new Mock<IApiDeviceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByPublicId_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var record = new Device();
			mock.RepositoryMock.Setup(x => x.ByPublicId(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceServerResponseModel response = await service.ByPublicId(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByPublicId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByPublicId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			mock.RepositoryMock.Setup(x => x.ByPublicId(It.IsAny<Guid>())).Returns(Task.FromResult<Device>(null));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceServerResponseModel response = await service.ByPublicId(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByPublicId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void DeviceActionsByDeviceId_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			var records = new List<DeviceAction>();
			records.Add(new DeviceAction());
			mock.RepositoryMock.Setup(x => x.DeviceActionsByDeviceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			List<ApiDeviceActionServerResponseModel> response = await service.DeviceActionsByDeviceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.DeviceActionsByDeviceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void DeviceActionsByDeviceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceRepository>();
			mock.RepositoryMock.Setup(x => x.DeviceActionsByDeviceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<DeviceAction>>(new List<DeviceAction>()));
			var service = new DeviceService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.DeviceModelValidatorMock.Object,
			                                mock.DALMapperMockFactory.DALDeviceMapperMock,
			                                mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			List<ApiDeviceActionServerResponseModel> response = await service.DeviceActionsByDeviceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.DeviceActionsByDeviceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>745fcdd0a61d823733a07db73e4a8265</Hash>
</Codenesium>*/