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
	[Trait("Table", "DeviceAction")]
	[Trait("Area", "Services")]
	public partial class DeviceActionServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();
			var records = new List<DeviceAction>();
			records.Add(new DeviceAction());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			List<ApiDeviceActionServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();
			var record = new DeviceAction();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceActionServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<DeviceAction>(null));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ApiDeviceActionServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();

			var model = new ApiDeviceActionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeviceAction>())).Returns(Task.FromResult(new DeviceAction()));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			CreateResponse<ApiDeviceActionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceActionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<DeviceAction>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceActionCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();
			var model = new ApiDeviceActionServerRequestModel();
			var validatorMock = new Mock<IApiDeviceActionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			CreateResponse<ApiDeviceActionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDeviceActionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceActionCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();
			var model = new ApiDeviceActionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<DeviceAction>())).Returns(Task.FromResult(new DeviceAction()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			UpdateResponse<ApiDeviceActionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<DeviceAction>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceActionUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();
			var model = new ApiDeviceActionServerRequestModel();
			var validatorMock = new Mock<IApiDeviceActionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DeviceAction()));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			UpdateResponse<ApiDeviceActionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDeviceActionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceActionUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();
			var model = new ApiDeviceActionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceActionDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();
			var model = new ApiDeviceActionServerRequestModel();
			var validatorMock = new Mock<IApiDeviceActionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DeviceActionDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByDeviceId_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();
			var records = new List<DeviceAction>();
			records.Add(new DeviceAction());
			mock.RepositoryMock.Setup(x => x.ByDeviceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			List<ApiDeviceActionServerResponseModel> response = await service.ByDeviceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDeviceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByDeviceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDeviceActionService, IDeviceActionRepository>();
			mock.RepositoryMock.Setup(x => x.ByDeviceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<DeviceAction>>(new List<DeviceAction>()));
			var service = new DeviceActionService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.DeviceActionModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALDeviceActionMapperMock);

			List<ApiDeviceActionServerResponseModel> response = await service.ByDeviceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByDeviceId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>266bc6aff39877cd8493b56e6661bd64</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/