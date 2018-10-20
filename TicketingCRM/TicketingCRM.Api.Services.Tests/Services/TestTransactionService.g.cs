using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public async void All()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			var records = new List<Transaction>();
			records.Add(new Transaction());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiTransactionResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			var record = new Transaction();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiTransactionResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(null));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ApiTransactionResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			var model = new ApiTransactionRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Transaction>())).Returns(Task.FromResult(new Transaction()));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			CreateResponse<ApiTransactionResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Transaction>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			var model = new ApiTransactionRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Transaction>())).Returns(Task.FromResult(new Transaction()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			UpdateResponse<ApiTransactionResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Transaction>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			var model = new ApiTransactionRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByTransactionStatusId_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			var records = new List<Transaction>();
			records.Add(new Transaction());
			mock.RepositoryMock.Setup(x => x.ByTransactionStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiTransactionResponseModel> response = await service.ByTransactionStatusId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTransactionStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTransactionStatusId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			mock.RepositoryMock.Setup(x => x.ByTransactionStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Transaction>>(new List<Transaction>()));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiTransactionResponseModel> response = await service.ByTransactionStatusId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTransactionStatusId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesByTransactionId_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.SalesByTransactionId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleResponseModel> response = await service.SalesByTransactionId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesByTransactionId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesByTransactionId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionRepository>();
			mock.RepositoryMock.Setup(x => x.SalesByTransactionId(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Sale>>(new List<Sale>()));
			var service = new TransactionService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.TransactionModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                     mock.DALMapperMockFactory.DALTransactionMapperMock,
			                                     mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleMapperMock);

			List<ApiSaleResponseModel> response = await service.SalesByTransactionId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesByTransactionId(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>3f0a0811885526ec9d6e96fc7e3391f5</Hash>
</Codenesium>*/