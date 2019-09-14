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
	[Trait("Table", "Destination")]
	[Trait("Area", "Services")]
	public partial class DestinationServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();
			var records = new List<Destination>();
			records.Add(new Destination());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			List<ApiDestinationServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();
			var record = new Destination();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			ApiDestinationServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Destination>(null));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			ApiDestinationServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();

			var model = new ApiDestinationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Destination>())).Returns(Task.FromResult(new Destination()));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			CreateResponse<ApiDestinationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDestinationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Destination>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DestinationCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();
			var model = new ApiDestinationServerRequestModel();
			var validatorMock = new Mock<IApiDestinationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiDestinationServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			CreateResponse<ApiDestinationServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiDestinationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DestinationCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();
			var model = new ApiDestinationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Destination>())).Returns(Task.FromResult(new Destination()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Destination()));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			UpdateResponse<ApiDestinationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDestinationServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Destination>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DestinationUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();
			var model = new ApiDestinationServerRequestModel();
			var validatorMock = new Mock<IApiDestinationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDestinationServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Destination()));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			UpdateResponse<ApiDestinationServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiDestinationServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DestinationUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();
			var model = new ApiDestinationServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DestinationDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();
			var model = new ApiDestinationServerRequestModel();
			var validatorMock = new Mock<IApiDestinationServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<DestinationDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PipelineStepDestinationsByDestinationId_Exists()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();
			var records = new List<PipelineStepDestination>();
			records.Add(new PipelineStepDestination());
			mock.RepositoryMock.Setup(x => x.PipelineStepDestinationsByDestinationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			List<ApiPipelineStepDestinationServerResponseModel> response = await service.PipelineStepDestinationsByDestinationId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepDestinationsByDestinationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepDestinationsByDestinationId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IDestinationService, IDestinationRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepDestinationsByDestinationId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStepDestination>>(new List<PipelineStepDestination>()));
			var service = new DestinationService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.DestinationModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALDestinationMapperMock,
			                                     mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock);

			List<ApiPipelineStepDestinationServerResponseModel> response = await service.PipelineStepDestinationsByDestinationId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepDestinationsByDestinationId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>405b87fb3fd1676f0b2d228e6829483e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/