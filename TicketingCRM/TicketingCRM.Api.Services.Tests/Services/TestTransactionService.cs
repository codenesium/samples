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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Transaction")]
	[Trait("Area", "Services")]
	public partial class TransactionServiceTests
	{
		[Fact]
		public async void All_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			var records = new List<Transaction>();
			records.Add(new Transaction());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult(records));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiTransactionServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
		}

		[Fact]
		public async void Get_ShouldReturnRecords()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			var record = new Transaction();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiTransactionServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_ShouldReturnNullBecauseRecordNotFound()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();

			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(null));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiTransactionServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();

			var model = new ApiTransactionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Transaction>())).Returns(Task.FromResult(new Transaction()));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			CreateResponse<ApiTransactionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Transaction>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionCreatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Create_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			var model = new ApiTransactionServerRequestModel();
			var validatorMock = new Mock<IApiTransactionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionServerRequestModel>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			CreateResponse<ApiTransactionServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionCreatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Update_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			var model = new ApiTransactionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Transaction>())).Returns(Task.FromResult(new Transaction()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			UpdateResponse<ApiTransactionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Transaction>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionUpdatedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Update_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			var model = new ApiTransactionServerRequestModel();
			var validatorMock = new Mock<IApiTransactionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionServerRequestModel>())).Returns(Task.FromResult(new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			UpdateResponse<ApiTransactionServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionServerRequestModel>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionUpdatedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void Delete_NoErrorsOccurred_ShouldReturnResponse()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			var model = new ApiTransactionServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeTrue();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionDeletedNotification>(), It.IsAny<CancellationToken>()));
		}

		[Fact]
		public async void Delete_ErrorsOccurred_ShouldReturnErrorResponse()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			var model = new ApiTransactionServerRequestModel();
			var validatorMock = new Mock<IApiTransactionServerRequestModelValidator>();
			validatorMock.Setup(x => x.ValidateDeleteAsync(It.IsAny<int>())).Returns(Task.FromResult(new FluentValidation.Results.ValidationResult(new List<ValidationFailure>() { new ValidationFailure("text", "test") })));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     validatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			response.Success.Should().BeFalse();
			validatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
			mock.MediatorMock.Verify(x => x.Publish(It.IsAny<TransactionDeletedNotification>(), It.IsAny<CancellationToken>()), Times.Never());
		}

		[Fact]
		public async void ByTransactionStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			var records = new List<Transaction>();
			records.Add(new Transaction());
			mock.RepositoryMock.Setup(x => x.ByTransactionStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiTransactionServerResponseModel> response = await service.ByTransactionStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTransactionStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTransactionStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			mock.RepositoryMock.Setup(x => x.ByTransactionStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Transaction>>(new List<Transaction>()));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiTransactionServerResponseModel> response = await service.ByTransactionStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTransactionStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesByTransactionId_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.SalesByTransactionId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleServerResponseModel> response = await service.SalesByTransactionId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesByTransactionId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesByTransactionId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionService, ITransactionRepository>();
			mock.RepositoryMock.Setup(x => x.SalesByTransactionId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Sale>>(new List<Sale>()));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.MediatorMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleServerResponseModel> response = await service.SalesByTransactionId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesByTransactionId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>3ce7fb4982f98cf15f01aa836fe9d00a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/