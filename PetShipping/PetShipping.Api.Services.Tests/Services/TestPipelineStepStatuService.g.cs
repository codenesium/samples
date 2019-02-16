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
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "Services")]
	public partial class PipelineStepStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var records = new List<PipelineStepStatu>();
			records.Add(new PipelineStepStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepStatuServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var record = new PipelineStepStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ApiPipelineStepStatuServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatu>(null));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ApiPipelineStepStatuServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var model = new ApiPipelineStepStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStatu>())).Returns(Task.FromResult(new PipelineStepStatu()));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			CreateResponse<ApiPipelineStepStatuServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<PipelineStepStatu>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatuCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var model = new ApiPipelineStepStatuServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatuServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			CreateResponse<ApiPipelineStepStatuServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiPipelineStepStatuServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatuCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var model = new ApiPipelineStepStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<PipelineStepStatu>())).Returns(Task.FromResult(new PipelineStepStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			UpdateResponse<ApiPipelineStepStatuServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatuServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<PipelineStepStatu>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatuUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var model = new ApiPipelineStepStatuServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatuServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			UpdateResponse<ApiPipelineStepStatuServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiPipelineStepStatuServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatuUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var model = new ApiPipelineStepStatuServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatuDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var model = new ApiPipelineStepStatuServerRequestModel();
			var validatorMock = new Mock<IApiPipelineStepStatuServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           validatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<PipelineStepStatuDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void PipelineStepsByPipelineStepStatusId_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			var records = new List<PipelineStep>();
			records.Add(new PipelineStep());
			mock.RepositoryMock.Setup(x => x.PipelineStepsByPipelineStepStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepServerResponseModel> response = await service.PipelineStepsByPipelineStepStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepsByPipelineStepStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void PipelineStepsByPipelineStepStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IPipelineStepStatuRepository>();
			mock.RepositoryMock.Setup(x => x.PipelineStepsByPipelineStepStatusId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<PipelineStep>>(new List<PipelineStep>()));
			var service = new PipelineStepStatuService(mock.LoggerMock.Object,
			                                           mock.MediatorMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.PipelineStepStatuModelValidatorMock.Object,
			                                           mock.DALMapperMockFactory.DALPipelineStepStatuMapperMock,
			                                           mock.DALMapperMockFactory.DALPipelineStepMapperMock);

			List<ApiPipelineStepServerResponseModel> response = await service.PipelineStepsByPipelineStepStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.PipelineStepsByPipelineStepStatusId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a8d85b50a015d5f8f95f7b6a89a55bac</Hash>
</Codenesium>*/