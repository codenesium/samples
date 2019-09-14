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
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "Services")]
	public partial class PipelineStepDestinationServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPipelineStepDestinationService, IPipelineStepDestinationRepository>();
			var records = new List<PipelineStepDestination>();
			records.Add(new PipelineStepDestination());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
			                                                 mock.MediatorMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
			                                                 mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			List<ApiPipelineStepDestinationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPipelineStepDestinationService, IPipelineStepDestinationRepository>();
			var record = new PipelineStepDestination();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
			                                                 mock.MediatorMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
			                                                 mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			ApiPipelineStepDestinationServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IPipelineStepDestinationService, IPipelineStepDestinationRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepDestination>(null));
			var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
			                                                 mock.MediatorMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
			                                                 mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			ApiPipelineStepDestinationServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepDestinationService, IPipelineStepDestinationRepository>();

			var model = new ApiPipelineStepDestinationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepDestination>())).Returns(Task.FromResult(new PipelineStepDestination()));
			var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
			                                                 mock.MediatorMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
			                                                 mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			CreateResponse<ApiPipelineStepDestinationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepDestinationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStepDestination>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepDestinationCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepDestinationService, IPipelineStepDestinationRepository>();
			var model = new ApiPipelineStepDestinationServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepDestinationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepDestinationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
			                                                 mock.MediatorMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 validatorMock.Object,
			                                                 mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			CreateResponse<ApiPipelineStepDestinationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepDestinationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepDestinationCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepDestinationService, IPipelineStepDestinationRepository>();
			var model = new ApiPipelineStepDestinationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepDestination>())).Returns(Task.FromResult(new PipelineStepDestination()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepDestination()));
			var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
			                                                 mock.MediatorMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
			                                                 mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			UpdateResponse<ApiPipelineStepDestinationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStepDestination>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepDestinationUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepDestinationService, IPipelineStepDestinationRepository>();
			var model = new ApiPipelineStepDestinationServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepDestinationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepDestination()));
			var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
			                                                 mock.MediatorMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 validatorMock.Object,
			                                                 mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			UpdateResponse<ApiPipelineStepDestinationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepDestinationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepDestinationUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepDestinationService, IPipelineStepDestinationRepository>();
			var model = new ApiPipelineStepDestinationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
			                                                 mock.MediatorMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Object,
			                                                 mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStepDestinationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepDestinationDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepDestinationService, IPipelineStepDestinationRepository>();
			var model = new ApiPipelineStepDestinationServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepDestinationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepDestinationService(mock.LoggerMock.Object,
			                                                 mock.MediatorMock.Object,
			                                                 mock.RepositoryMock.Object,
			                                                 validatorMock.Object,
			                                                 mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepDestinationDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>17591a718abf9dc9cb7ef6c31e160dde</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/