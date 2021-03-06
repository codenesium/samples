using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Handler")]
	[Trait("Area", "Services")]
	public partial class HandlerServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var records = new List<Handler>();
			records.Add(new Handler());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiHandlerServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var record = new Handler();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiHandlerServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ApiHandlerServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();

			var model = new ApiHandlerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Handler>())).Returns(Task.FromResult(new Handler()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			CreateResponse<ApiHandlerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Handler>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var model = new ApiHandlerServerRequestModel();
			var validatorMock = new Mock<IApiHandlerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			CreateResponse<ApiHandlerServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var model = new ApiHandlerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Handler>())).Returns(Task.FromResult(new Handler()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			UpdateResponse<ApiHandlerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Handler>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var model = new ApiHandlerServerRequestModel();
			var validatorMock = new Mock<IApiHandlerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			UpdateResponse<ApiHandlerServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var model = new ApiHandlerServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var model = new ApiHandlerServerRequestModel();
			var validatorMock = new Mock<IApiHandlerServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 validatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void AirTransportsByHandlerId_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var records = new List<AirTransport>();
			records.Add(new AirTransport());
			mock.RepositoryMock.Setup(x => x.AirTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiAirTransportServerResponseModel> response = await service.AirTransportsByHandlerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.AirTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void AirTransportsByHandlerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			mock.RepositoryMock.Setup(x => x.AirTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<AirTransport>>(new List<AirTransport>()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiAirTransportServerResponseModel> response = await service.AirTransportsByHandlerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.AirTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void HandlerPipelineStepsByHandlerId_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var records = new List<HandlerPipelineStep>();
			records.Add(new HandlerPipelineStep());
			mock.RepositoryMock.Setup(x => x.HandlerPipelineStepsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiHandlerPipelineStepServerResponseModel> response = await service.HandlerPipelineStepsByHandlerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.HandlerPipelineStepsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void HandlerPipelineStepsByHandlerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			mock.RepositoryMock.Setup(x => x.HandlerPipelineStepsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<HandlerPipelineStep>>(new List<HandlerPipelineStep>()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiHandlerPipelineStepServerResponseModel> response = await service.HandlerPipelineStepsByHandlerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.HandlerPipelineStepsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OtherTransportsByHandlerId_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			var records = new List<OtherTransport>();
			records.Add(new OtherTransport());
			mock.RepositoryMock.Setup(x => x.OtherTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiOtherTransportServerResponseModel> response = await service.OtherTransportsByHandlerId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.OtherTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OtherTransportsByHandlerId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IHandlerService, IHandlerRepository>();
			mock.RepositoryMock.Setup(x => x.OtherTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<OtherTransport>>(new List<OtherTransport>()));
			var service = new HandlerService(mock.LoggerMock.Object,
			                                 mock.MediatorMock.Object,
			                                 mock.RepositoryMock.Object,
			                                 mock.ModelValidatorMockFactory.HandlerModelValidatorMock.Object,
			                                 mock.DALMapperMockFactory.DALHandlerMapperMock,
			                                 mock.DALMapperMockFactory.DALAirTransportMapperMock,
			                                 mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                 mock.DALMapperMockFactory.DALOtherTransportMapperMock);

			List<ApiOtherTransportServerResponseModel> response = await service.OtherTransportsByHandlerId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.OtherTransportsByHandlerId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>52306c0d0dcfca5e3180a411d1bc12f6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/