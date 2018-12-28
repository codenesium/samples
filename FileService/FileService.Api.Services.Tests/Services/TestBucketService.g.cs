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
	[Trait("Table", "Bucket")]
	[Trait("Area", "Services")]
	public partial class BucketServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var records = new List<Bucket>();
			records.Add(new Bucket());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			List<ApiBucketServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var record = new Bucket();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			ApiBucketServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Bucket>(null));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			ApiBucketServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var model = new ApiBucketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Bucket>())).Returns(Task.FromResult(new Bucket()));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			CreateResponse<ApiBucketServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.BucketModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBucketServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Bucket>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BucketCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var model = new ApiBucketServerRequestModel();
			var validatorMock = new Mock<IApiBucketServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiBucketServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			CreateResponse<ApiBucketServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiBucketServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BucketCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var model = new ApiBucketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Bucket>())).Returns(Task.FromResult(new Bucket()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			UpdateResponse<ApiBucketServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.BucketModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBucketServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Bucket>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BucketUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var model = new ApiBucketServerRequestModel();
			var validatorMock = new Mock<IApiBucketServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBucketServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Bucket()));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			UpdateResponse<ApiBucketServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiBucketServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BucketUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var model = new ApiBucketServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.BucketModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BucketDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var model = new ApiBucketServerRequestModel();
			var validatorMock = new Mock<IApiBucketServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                validatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<BucketDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByExternalId_Exists()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var record = new Bucket();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult(record));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			ApiBucketServerResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByExternalId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			mock.RepositoryMock.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Bucket>(null));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			ApiBucketServerResponseModel response = await service.ByExternalId(default(Guid));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByExternalId(It.IsAny<Guid>()));
		}

		[Fact]
		public async void ByName_Exists()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var record = new Bucket();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			ApiBucketServerResponseModel response = await service.ByName("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void ByName_Not_Exists()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			mock.RepositoryMock.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Bucket>(null));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			ApiBucketServerResponseModel response = await service.ByName("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByName(It.IsAny<string>()));
		}

		[Fact]
		public async void FilesByBucketId_Exists()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			var records = new List<File>();
			records.Add(new File());
			mock.RepositoryMock.Setup(x => x.FilesByBucketId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			List<ApiFileServerResponseModel> response = await service.FilesByBucketId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.FilesByBucketId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void FilesByBucketId_Not_Exists()
		{
			var mock = new ServiceMockFacade<IBucketRepository>();
			mock.RepositoryMock.Setup(x => x.FilesByBucketId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<File>>(new List<File>()));
			var service = new BucketService(mock.LoggerMock.Object,
			                                mock.MediatorMock.Object,
			                                mock.RepositoryMock.Object,
			                                mock.ModelValidatorMockFactory.BucketModelValidatorMock.Object,
			                                mock.BOLMapperMockFactory.BOLBucketMapperMock,
			                                mock.DALMapperMockFactory.DALBucketMapperMock,
			                                mock.BOLMapperMockFactory.BOLFileMapperMock,
			                                mock.DALMapperMockFactory.DALFileMapperMock);

			List<ApiFileServerResponseModel> response = await service.FilesByBucketId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.FilesByBucketId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>5f2acf2dc9cfd64764739d9f26a7f344</Hash>
</Codenesium>*/