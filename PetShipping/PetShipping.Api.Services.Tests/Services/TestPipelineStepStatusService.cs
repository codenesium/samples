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
	[Trait("Table", "PipelineStepStatus")]
	[Trait("Area", "Services")]
	public partial class PipelineStepStatusServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();
			var records = new List<PipelineStepStatus>();
			records.Add(new PipelineStepStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepStatusServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();
			var record = new PipelineStepStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ApiPipelineStepStatusServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatus>(null));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ApiPipelineStepStatusServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();

			var model = new ApiPipelineStepStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStatus>())).Returns(Task.FromResult(new PipelineStepStatus()));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			CreateResponse<ApiPipelineStepStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStepStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatusCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();
			var model = new ApiPipelineStepStatusServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			CreateResponse<ApiPipelineStepStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatusCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();
			var model = new ApiPipelineStepStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStatus>())).Returns(Task.FromResult(new PipelineStepStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatus()));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			UpdateResponse<ApiPipelineStepStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStepStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatusUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();
			var model = new ApiPipelineStepStatusServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatus()));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			UpdateResponse<ApiPipelineStepStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatusUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();
			var model = new ApiPipelineStepStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatusDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();
			var model = new ApiPipelineStepStatusServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatusDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PipelineStepsByPipelineStepStatusId_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();
			var records = new List<PipelineStep>();
			records.Add(new PipelineStep());
			mock.RepositoryMock.Setup(x => x.PipelineStepsByPipelineStepStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepServerResponseModel> response = await service.PipelineStepsByPipelineStepStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepsByPipelineStepStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepsByPipelineStepStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatusService, IPipelineStepStatusRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepsByPipelineStepStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStep>>(new List<PipelineStep>()));
			var service = new PipelineStepStatusService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.PipelineStepStatusModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALPipelineStepStatusMapperMock,
			                                            mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepServerResponseModel> response = await service.PipelineStepsByPipelineStepStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepsByPipelineStepStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>d76a301be14c593eafb6e20cda14de6e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/