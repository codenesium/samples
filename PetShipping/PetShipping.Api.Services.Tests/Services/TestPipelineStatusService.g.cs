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
	[Trait("Table", "PipelineStatus")]
	[Trait("Area", "Services")]
	public partial class PipelineStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var records = new List<PipelineStatus>();
			records.Add(new PipelineStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineStatusServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var record = new PipelineStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			ApiPipelineStatusServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(null));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			ApiPipelineStatusServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var model = new ApiPipelineStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStatus>())).Returns(Task.FromResult(new PipelineStatus()));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			CreateResponse<ApiPipelineStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStatusCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var model = new ApiPipelineStatusServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStatusServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			CreateResponse<ApiPipelineStatusServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStatusCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var model = new ApiPipelineStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStatus>())).Returns(Task.FromResult(new PipelineStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatus()));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			UpdateResponse<ApiPipelineStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStatusServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStatus>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStatusUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var model = new ApiPipelineStatusServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStatusServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatus()));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			UpdateResponse<ApiPipelineStatusServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStatusServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStatusUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var model = new ApiPipelineStatusServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStatusDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var model = new ApiPipelineStatusServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStatusServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        validatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStatusDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PipelinesByPipelineStatusId_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			var records = new List<Pipeline>();
			records.Add(new Pipeline());
			mock.RepositoryMock.Setup(x => x.PipelinesByPipelineStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineServerResponseModel> response = await service.PipelinesByPipelineStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelinesByPipelineStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelinesByPipelineStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStatusRepository>();
			mock.RepositoryMock.Setup(x => x.PipelinesByPipelineStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Pipeline>>(new List<Pipeline>()));
			var service = new PipelineStatusService(mock.LoggerMock.Object,
			                                        mock.MediatorMock.Object,
			                                        mock.RepositoryMock.Object,
			                                        mock.ModelValidatorMockFactory.PipelineStatusModelValidatorMock.Object,
			                                        mock.DALMapperMockFactory.DALPipelineStatusMapperMock,
			                                        mock.DALMapperMockFactory.DALPipelineMapperMock);

			List<ApiPipelineServerResponseModel> response = await service.PipelinesByPipelineStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelinesByPipelineStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>78e5ba6b067491a1cd1937454b4ac320</Hash>
</Codenesium>*/