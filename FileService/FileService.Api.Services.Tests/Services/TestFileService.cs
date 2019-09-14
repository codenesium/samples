using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "File")]
	[Trait("Area", "Services")]
	public partial class FileServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IFileService, IFileRepository>();
			var records = new List<File>();
			records.Add(new File());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new FileService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALFileMapperMock);

			List<ApiFileServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<IFileService, IFileRepository>();
			var record = new File();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new FileService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALFileMapperMock);

			ApiFileServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<IFileService, IFileRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<File>(null));
			var service = new FileService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALFileMapperMock);

			ApiFileServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IFileService, IFileRepository>();

			var model = new ApiFileServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<File>())).Returns(Task.FromResult(new File()));
			var service = new FileService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALFileMapperMock);

			CreateResponse<ApiFileServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FileModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFileServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<File>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FileCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IFileService, IFileRepository>();
			var model = new ApiFileServerRequestModel();
			var validatorMock = new Mock<IApiFileServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFileServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FileService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALFileMapperMock);

			CreateResponse<ApiFileServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFileServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FileCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IFileService, IFileRepository>();
			var model = new ApiFileServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<File>())).Returns(Task.FromResult(new File()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));
			var service = new FileService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALFileMapperMock);

			UpdateResponse<ApiFileServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FileModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<File>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FileUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IFileService, IFileRepository>();
			var model = new ApiFileServerRequestModel();
			var validatorMock = new Mock<IApiFileServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new File()));
			var service = new FileService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALFileMapperMock);

			UpdateResponse<ApiFileServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FileUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<IFileService, IFileRepository>();
			var model = new ApiFileServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new FileService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.FileModelValidatorMock.Object,
			                              mock.DALMapperMockFactory.DALFileMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.FileModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FileDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<IFileService, IFileRepository>();
			var model = new ApiFileServerRequestModel();
			var validatorMock = new Mock<IApiFileServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FileService(mock.LoggerMock.Object,
			                              mock.MediatorMock.Object,
			                              mock.RepositoryMock.Object,
			                              validatorMock.Object,
			                              mock.DALMapperMockFactory.DALFileMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<FileDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}
	}
}

/*<Codenesium>
    <Hash>ae45f3664926aa1632a7c1b1b04c5f8b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/