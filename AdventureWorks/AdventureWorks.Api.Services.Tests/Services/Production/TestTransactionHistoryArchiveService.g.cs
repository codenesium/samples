using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "Services")]
	public partial class TransactionHistoryArchiveServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var records = new List<TransactionHistoryArchive>();
			records.Add(new TransactionHistoryArchive());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var record = new TransactionHistoryArchive();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			ApiTransactionHistoryArchiveServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TransactionHistoryArchive>(null));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			ApiTransactionHistoryArchiveServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionHistoryArchive>())).Returns(Task.FromResult(new TransactionHistoryArchive()));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			CreateResponse<ApiTransactionHistoryArchiveServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TransactionHistoryArchive>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryArchiveCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			var validatorMock = new Mock<IApiTransactionHistoryArchiveServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   validatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			CreateResponse<ApiTransactionHistoryArchiveServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryArchiveCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionHistoryArchive>())).Returns(Task.FromResult(new TransactionHistoryArchive()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TransactionHistoryArchive>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryArchiveUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			var validatorMock = new Mock<IApiTransactionHistoryArchiveServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   validatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			UpdateResponse<ApiTransactionHistoryArchiveServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryArchiveServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryArchiveUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryArchiveDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var model = new ApiTransactionHistoryArchiveServerRequestModel();
			var validatorMock = new Mock<IApiTransactionHistoryArchiveServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   validatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryArchiveDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByProductID_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var records = new List<TransactionHistoryArchive>();
			records.Add(new TransactionHistoryArchive());
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.ByProductID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistoryArchive>>(new List<TransactionHistoryArchive>()));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.ByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByReferenceOrderIDReferenceOrderLineID_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			var records = new List<TransactionHistoryArchive>();
			records.Add(new TransactionHistoryArchive());
			mock.RepositoryMock.Setup(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.ByReferenceOrderIDReferenceOrderLineID(default(int), default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByReferenceOrderIDReferenceOrderLineID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryArchiveRepository>();
			mock.RepositoryMock.Setup(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistoryArchive>>(new List<TransactionHistoryArchive>()));
			var service = new TransactionHistoryArchiveService(mock.LoggerMock.Object,
			                                                   mock.MediatorMock.Object,
			                                                   mock.RepositoryMock.Object,
			                                                   mock.ModelValidatorMockFactory.TransactionHistoryArchiveModelValidatorMock.Object,
			                                                   mock.BOLMapperMockFactory.BOLTransactionHistoryArchiveMapperMock,
			                                                   mock.DALMapperMockFactory.DALTransactionHistoryArchiveMapperMock);

			List<ApiTransactionHistoryArchiveServerResponseModel> response = await service.ByReferenceOrderIDReferenceOrderLineID(default(int), default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>06ce9449bf943eadab681d87ff6a4511</Hash>
</Codenesium>*/