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
using System.Threading.Tasks;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "FileType")]
	[Trait("Area", "Services")]
	public partial class FileTypeServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			var records = new List<FileType>();
			records.Add(new FileType());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			List<ApiFileTypeServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			var record = new FileType();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			ApiFileTypeServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<FileType>(null));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			ApiFileTypeServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			var model = new ApiFileTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<FileType>())).Returns(Task.FromResult(new FileType()));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			CreateResponse<ApiFileTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFileTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<FileType>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			var model = new ApiFileTypeServerRequestModel();
			var validatorMock = new Mock<IApiFileTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiFileTypeServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			CreateResponse<ApiFileTypeServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiFileTypeServerRequestModel>()));
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			var model = new ApiFileTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<FileType>())).Returns(Task.FromResult(new FileType()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			UpdateResponse<ApiFileTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileTypeServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<FileType>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			var model = new ApiFileTypeServerRequestModel();
			var validatorMock = new Mock<IApiFileTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileTypeServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new FileType()));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			UpdateResponse<ApiFileTypeServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiFileTypeServerRequestModel>()));
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			var model = new ApiFileTypeServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			var model = new ApiFileTypeServerRequestModel();
			var validatorMock = new Mock<IApiFileTypeServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  validatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void FilesByFileTypeId_Exists()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			var records = new List<File>();
			records.Add(new File());
			mock.RepositoryMock.Setup(x => x.FilesByFileTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			List<ApiFileServerResponseModel> response = await service.FilesByFileTypeId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.FilesByFileTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void FilesByFileTypeId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IFileTypeRepository>();
			mock.RepositoryMock.Setup(x => x.FilesByFileTypeId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<File>>(new List<File>()));
			var service = new FileTypeService(mock.LoggerMock.Object,
			                                  mock.RepositoryMock.Object,
			                                  mock.ModelValidatorMockFactory.FileTypeModelValidatorMock.Object,
			                                  mock.BOLMapperMockFactory.BOLFileTypeMapperMock,
			                                  mock.DALMapperMockFactory.DALFileTypeMapperMock,
			                                  mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                  mock.DALMapperMockFactory.DALFileMapperMock);

			List<ApiFileServerResponseModel> response = await service.FilesByFileTypeId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.FilesByFileTypeId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>a4dd5d6b2745a8252173329ec4a07edd</Hash>
</Codenesium>*/