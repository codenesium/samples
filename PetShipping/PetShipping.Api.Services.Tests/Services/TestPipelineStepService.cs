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
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "Services")]
	public partial class PipelineStepServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var records = new List<PipelineStep>();
			records.Add(new PipelineStep());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var record = new PipelineStep();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ApiPipelineStepServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ApiPipelineStepServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();

			var model = new ApiPipelineStepServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStep>())).Returns(Task.FromResult(new PipelineStep()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			CreateResponse<ApiPipelineStepServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStep>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var model = new ApiPipelineStepServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			CreateResponse<ApiPipelineStepServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var model = new ApiPipelineStepServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStep>())).Returns(Task.FromResult(new PipelineStep()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			UpdateResponse<ApiPipelineStepServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStep>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var model = new ApiPipelineStepServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			UpdateResponse<ApiPipelineStepServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var model = new ApiPipelineStepServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var model = new ApiPipelineStepServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      validatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void HandlerPipelineStepsByPipelineStepId_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var records = new List<HandlerPipelineStep>();
			records.Add(new HandlerPipelineStep());
			mock.RepositoryMock.Setup(x => x.HandlerPipelineStepsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiHandlerPipelineStepServerResponseModel> response = await service.HandlerPipelineStepsByPipelineStepId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.HandlerPipelineStepsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void HandlerPipelineStepsByPipelineStepId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			mock.RepositoryMock.Setup(x => x.HandlerPipelineStepsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<HandlerPipelineStep>>(new List<HandlerPipelineStep>()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiHandlerPipelineStepServerResponseModel> response = await service.HandlerPipelineStepsByPipelineStepId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.HandlerPipelineStepsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OtherTransportsByPipelineStepId_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var records = new List<OtherTransport>();
			records.Add(new OtherTransport());
			mock.RepositoryMock.Setup(x => x.OtherTransportsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiOtherTransportServerResponseModel> response = await service.OtherTransportsByPipelineStepId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.OtherTransportsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void OtherTransportsByPipelineStepId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			mock.RepositoryMock.Setup(x => x.OtherTransportsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<OtherTransport>>(new List<OtherTransport>()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiOtherTransportServerResponseModel> response = await service.OtherTransportsByPipelineStepId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.OtherTransportsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepDestinationsByPipelineStepId_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var records = new List<PipelineStepDestination>();
			records.Add(new PipelineStepDestination());
			mock.RepositoryMock.Setup(x => x.PipelineStepDestinationsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepDestinationServerResponseModel> response = await service.PipelineStepDestinationsByPipelineStepId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepDestinationsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepDestinationsByPipelineStepId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepDestinationsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStepDestination>>(new List<PipelineStepDestination>()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepDestinationServerResponseModel> response = await service.PipelineStepDestinationsByPipelineStepId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepDestinationsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepNotesByPipelineStepId_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var records = new List<PipelineStepNote>();
			records.Add(new PipelineStepNote());
			mock.RepositoryMock.Setup(x => x.PipelineStepNotesByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepNoteServerResponseModel> response = await service.PipelineStepNotesByPipelineStepId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepNotesByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepNotesByPipelineStepId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepNotesByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStepNote>>(new List<PipelineStepNote>()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepNoteServerResponseModel> response = await service.PipelineStepNotesByPipelineStepId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepNotesByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepStepRequirementsByPipelineStepId_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			var records = new List<PipelineStepStepRequirement>();
			records.Add(new PipelineStepStepRequirement());
			mock.RepositoryMock.Setup(x => x.PipelineStepStepRequirementsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepStepRequirementServerResponseModel> response = await service.PipelineStepStepRequirementsByPipelineStepId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepStepRequirementsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepStepRequirementsByPipelineStepId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepService, IPipelineStepRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepStepRequirementsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStepStepRequirement>>(new List<PipelineStepStepRequirement>()));
			var service = new PipelineStepService(mock.LoggerMock.Object,
			                                      mock.MediatorMock.Object,
			                                      mock.RepositoryMock.Object,
			                                      mock.ModelValidatorMockFactory.PipelineStepModelValidatorMock.Object,
			                                      mock.DALMapperMockFactory.DALPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALHandlerPipelineStepMapperMock,
			                                      mock.DALMapperMockFactory.DALOtherTransportMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepDestinationMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepNoteMapperMock,
			                                      mock.DALMapperMockFactory.DALPipelineStepStepRequirementMapperMock);

			List<ApiPipelineStepStepRequirementServerResponseModel> response = await service.PipelineStepStepRequirementsByPipelineStepId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepStepRequirementsByPipelineStepId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>cf6595cff92035c41c3331521a714769</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/