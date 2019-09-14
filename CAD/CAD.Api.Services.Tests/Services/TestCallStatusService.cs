using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallStatus")]
	[Trait("Area", "Services")]
	public partial class CallStatusServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();
			var records = new List<CallStatus>();
			records.Add(new CallStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallStatusServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();
			var record = new CallStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			ApiCallStatusServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CallStatus>(null));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			ApiCallStatusServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();

			var model = new ApiCallStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallStatus>())).Returns(Task.FromResult(new CallStatus()));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiCallStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CallStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatusCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();
			var model = new ApiCallStatusServerRequestModel();
			var validatorMock = new Mock<IApiCallStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiCallStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatusCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();
			var model = new ApiCallStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallStatus>())).Returns(Task.FromResult(new CallStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatus()));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiCallStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CallStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatusUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();
			var model = new ApiCallStatusServerRequestModel();
			var validatorMock = new Mock<IApiCallStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallStatusServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallStatus()));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiCallStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatusUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();
			var model = new ApiCallStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatusDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();
			var model = new ApiCallStatusServerRequestModel();
			var validatorMock = new Mock<IApiCallStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    validatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallStatusDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CallsByCallStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();
			var records = new List<Call>();
			records.Add(new Call());
			mock.RepositoryMock.Setup(x => x.CallsByCallStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByCallStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByCallStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CallsByCallStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICallStatusService, ICallStatusRepository>();
			mock.RepositoryMock.Setup(x => x.CallsByCallStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Call>>(new List<Call>()));
			var service = new CallStatusService(mock.LoggerMock.Object,
			                                    mock.MediatorMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CallStatusModelValidatorMock.Object,
			                                    mock.DALMapperMockFactory.DALCallStatusMapperMock,
			                                    mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByCallStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByCallStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>8410e49378aee60cb99c740c28375f9d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/