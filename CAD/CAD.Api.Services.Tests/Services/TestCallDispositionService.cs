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
	[Trait("Table", "CallDisposition")]
	[Trait("Area", "Services")]
	public partial class CallDispositionServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();
			var records = new List<CallDisposition>();
			records.Add(new CallDisposition());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallDispositionServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();
			var record = new CallDisposition();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			ApiCallDispositionServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CallDisposition>(null));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			ApiCallDispositionServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();

			var model = new ApiCallDispositionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallDisposition>())).Returns(Task.FromResult(new CallDisposition()));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiCallDispositionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallDispositionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CallDisposition>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallDispositionCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();
			var model = new ApiCallDispositionServerRequestModel();
			var validatorMock = new Mock<IApiCallDispositionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiCallDispositionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			CreateResponse<ApiCallDispositionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCallDispositionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallDispositionCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();
			var model = new ApiCallDispositionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CallDisposition>())).Returns(Task.FromResult(new CallDisposition()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallDisposition()));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiCallDispositionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallDispositionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CallDisposition>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallDispositionUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();
			var model = new ApiCallDispositionServerRequestModel();
			var validatorMock = new Mock<IApiCallDispositionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallDispositionServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallDisposition()));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			UpdateResponse<ApiCallDispositionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCallDispositionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallDispositionUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();
			var model = new ApiCallDispositionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallDispositionDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();
			var model = new ApiCallDispositionServerRequestModel();
			var validatorMock = new Mock<IApiCallDispositionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         validatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<CallDispositionDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void CallsByCallDispositionId_Exists()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();
			var records = new List<Call>();
			records.Add(new Call());
			mock.RepositoryMock.Setup(x => x.CallsByCallDispositionId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByCallDispositionId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByCallDispositionId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void CallsByCallDispositionId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICallDispositionService, ICallDispositionRepository>();
			mock.RepositoryMock.Setup(x => x.CallsByCallDispositionId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Call>>(new List<Call>()));
			var service = new CallDispositionService(mock.LoggerMock.Object,
			                                         mock.MediatorMock.Object,
			                                         mock.RepositoryMock.Object,
			                                         mock.ModelValidatorMockFactory.CallDispositionModelValidatorMock.Object,
			                                         mock.DALMapperMockFactory.DALCallDispositionMapperMock,
			                                         mock.DALMapperMockFactory.DALCallMapperMock);

			List<ApiCallServerResponseModel> response = await service.CallsByCallDispositionId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.CallsByCallDispositionId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>577be370cb0227861418315e0ebf9ff5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/