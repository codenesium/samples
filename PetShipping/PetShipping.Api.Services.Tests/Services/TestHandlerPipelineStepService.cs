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
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "Services")]
	public partial class HandlerPipelineStepServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepService, IHandlerPipelineStepRepository>();
			var records = new List<HandlerPipelineStep>();
			records.Add(new HandlerPipelineStep());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			List<ApiHandlerPipelineStepServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepService, IHandlerPipelineStepRepository>();
			var record = new HandlerPipelineStep();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			ApiHandlerPipelineStepServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepService, IHandlerPipelineStepRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<HandlerPipelineStep>(null));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			ApiHandlerPipelineStepServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepService, IHandlerPipelineStepRepository>();

			var model = new ApiHandlerPipelineStepServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<HandlerPipelineStep>())).Returns(Task.FromResult(new HandlerPipelineStep()));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			CreateResponse<ApiHandlerPipelineStepServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<HandlerPipelineStep>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerPipelineStepCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepService, IHandlerPipelineStepRepository>();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			var validatorMock = new Mock<IApiHandlerPipelineStepServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			CreateResponse<ApiHandlerPipelineStepServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerPipelineStepCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepService, IHandlerPipelineStepRepository>();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<HandlerPipelineStep>())).Returns(Task.FromResult(new HandlerPipelineStep()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new HandlerPipelineStep()));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			UpdateResponse<ApiHandlerPipelineStepServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<HandlerPipelineStep>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerPipelineStepUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepService, IHandlerPipelineStepRepository>();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			var validatorMock = new Mock<IApiHandlerPipelineStepServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new HandlerPipelineStep()));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			UpdateResponse<ApiHandlerPipelineStepServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiHandlerPipelineStepServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerPipelineStepUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepService, IHandlerPipelineStepRepository>();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Object,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.HandlerPipelineStepModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerPipelineStepDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IHandlerPipelineStepService, IHandlerPipelineStepRepository>();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			var validatorMock = new Mock<IApiHandlerPipelineStepServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new HandlerPipelineStepService(mock.LoggerMock.Object,
			                                             mock.MediatorMock.Object,
			                                             mock.RepositoryMock.Object,
			                                             validatorMock.Object,
			                                             mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<HandlerPipelineStepDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>e3741b85ff8ef22fd5d3de81274e08bb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/