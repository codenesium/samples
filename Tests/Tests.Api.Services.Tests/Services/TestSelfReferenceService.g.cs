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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "Services")]
	public partial class SelfReferenceServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var records = new List<SelfReference>();
			records.Add(new SelfReference());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			List<ApiSelfReferenceServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var record = new SelfReference();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			ApiSelfReferenceServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(null));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			ApiSelfReferenceServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var model = new ApiSelfReferenceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SelfReference>())).Returns(Task.FromResult(new SelfReference()));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			CreateResponse<ApiSelfReferenceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSelfReferenceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SelfReference>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SelfReferenceCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var model = new ApiSelfReferenceServerRequestModel();
			var validatorMock = new Mock<IApiSelfReferenceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			CreateResponse<ApiSelfReferenceServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSelfReferenceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SelfReferenceCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var model = new ApiSelfReferenceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SelfReference>())).Returns(Task.FromResult(new SelfReference()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SelfReference()));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			UpdateResponse<ApiSelfReferenceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SelfReference>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SelfReferenceUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var model = new ApiSelfReferenceServerRequestModel();
			var validatorMock = new Mock<IApiSelfReferenceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SelfReference()));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			UpdateResponse<ApiSelfReferenceServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSelfReferenceServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SelfReferenceUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var model = new ApiSelfReferenceServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SelfReferenceDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var model = new ApiSelfReferenceServerRequestModel();
			var validatorMock = new Mock<IApiSelfReferenceServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       validatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<SelfReferenceDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void SelfReferencesBySelfReferenceId_Exists()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var records = new List<SelfReference>();
			records.Add(new SelfReference());
			mock.RepositoryMock.Setup(x => x.SelfReferencesBySelfReferenceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			List<ApiSelfReferenceServerResponseModel> response = await service.SelfReferencesBySelfReferenceId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SelfReferencesBySelfReferenceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SelfReferencesBySelfReferenceId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			mock.RepositoryMock.Setup(x => x.SelfReferencesBySelfReferenceId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SelfReference>>(new List<SelfReference>()));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			List<ApiSelfReferenceServerResponseModel> response = await service.SelfReferencesBySelfReferenceId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SelfReferencesBySelfReferenceId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SelfReferencesBySelfReferenceId2_Exists()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			var records = new List<SelfReference>();
			records.Add(new SelfReference());
			mock.RepositoryMock.Setup(x => x.SelfReferencesBySelfReferenceId2(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			List<ApiSelfReferenceServerResponseModel> response = await service.SelfReferencesBySelfReferenceId2(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SelfReferencesBySelfReferenceId2(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SelfReferencesBySelfReferenceId2_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISelfReferenceRepository>();
			mock.RepositoryMock.Setup(x => x.SelfReferencesBySelfReferenceId2(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SelfReference>>(new List<SelfReference>()));
			var service = new SelfReferenceService(mock.LoggerMock.Object,
			                                       mock.MediatorMock.Object,
			                                       mock.RepositoryMock.Object,
			                                       mock.ModelValidatorMockFactory.SelfReferenceModelValidatorMock.Object,
			                                       mock.DALMapperMockFactory.DALSelfReferenceMapperMock);

			List<ApiSelfReferenceServerResponseModel> response = await service.SelfReferencesBySelfReferenceId2(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SelfReferencesBySelfReferenceId2(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>3261ead75f8ba986d62b32c297503843</Hash>
</Codenesium>*/