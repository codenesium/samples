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
	[Trait("Table", "TransactionHistory")]
	[Trait("Area", "Services")]
	public partial class TransactionHistoryServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var records = new List<TransactionHistory>();
			records.Add(new TransactionHistory());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			List<ApiTransactionHistoryServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var record = new TransactionHistory();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			ApiTransactionHistoryServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TransactionHistory>(null));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			ApiTransactionHistoryServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var model = new ApiTransactionHistoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionHistory>())).Returns(Task.FromResult(new TransactionHistory()));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			CreateResponse<ApiTransactionHistoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TransactionHistory>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var model = new ApiTransactionHistoryServerRequestModel();
			var validatorMock = new Mock<IApiTransactionHistoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			CreateResponse<ApiTransactionHistoryServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionHistoryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var model = new ApiTransactionHistoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionHistory>())).Returns(Task.FromResult(new TransactionHistory()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			UpdateResponse<ApiTransactionHistoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TransactionHistory>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var model = new ApiTransactionHistoryServerRequestModel();
			var validatorMock = new Mock<IApiTransactionHistoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			UpdateResponse<ApiTransactionHistoryServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionHistoryServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var model = new ApiTransactionHistoryServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_Errors()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var model = new ApiTransactionHistoryServerRequestModel();
			var validatorMock = new Mock<IApiTransactionHistoryServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            validatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionHistoryDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByProductID_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var records = new List<TransactionHistory>();
			records.Add(new TransactionHistory());
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			List<ApiTransactionHistoryServerResponseModel> response = await service.ByProductID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByProductID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			mock.RepositoryMock.Setup(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistory>>(new List<TransactionHistory>()));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			List<ApiTransactionHistoryServerResponseModel> response = await service.ByProductID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByProductID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByReferenceOrderIDReferenceOrderLineID_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			var records = new List<TransactionHistory>();
			records.Add(new TransactionHistory());
			mock.RepositoryMock.Setup(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			List<ApiTransactionHistoryServerResponseModel> response = await service.ByReferenceOrderIDReferenceOrderLineID(default(int), default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByReferenceOrderIDReferenceOrderLineID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionHistoryRepository>();
			mock.RepositoryMock.Setup(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<TransactionHistory>>(new List<TransactionHistory>()));
			var service = new TransactionHistoryService(mock.LoggerMock.Object,
			                                            mock.MediatorMock.Object,
			                                            mock.RepositoryMock.Object,
			                                            mock.ModelValidatorMockFactory.TransactionHistoryModelValidatorMock.Object,
			                                            mock.DALMapperMockFactory.DALTransactionHistoryMapperMock);

			List<ApiTransactionHistoryServerResponseModel> response = await service.ByReferenceOrderIDReferenceOrderLineID(default(int), default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByReferenceOrderIDReferenceOrderLineID(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>02a25f8763fc8a565f1e4939a1d412ea</Hash>
</Codenesium>*/