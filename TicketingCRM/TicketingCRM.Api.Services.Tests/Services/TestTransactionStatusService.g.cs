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
	[Trait("Table", "TransactionStatus")]
	[Trait("Area", "Services")]
	public partial class TransactionStatusServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var records = new List<TransactionStatus>();
			records.Add(new TransactionStatus());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionStatusResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var record = new TransactionStatus();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			ApiTransactionStatusResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatus>(null));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			ApiTransactionStatusResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var model = new ApiTransactionStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionStatus>())).Returns(Task.FromResult(new TransactionStatus()));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			CreateResponse<ApiTransactionStatusResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TransactionStatus>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var model = new ApiTransactionStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionStatus>())).Returns(Task.FromResult(new TransactionStatus()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			UpdateResponse<ApiTransactionStatusResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatusRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TransactionStatus>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var model = new ApiTransactionStatusRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Transactions_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			var records = new List<Transaction>();
			records.Add(new Transaction());
			mock.RepositoryMock.Setup(x => x.Transactions(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionResponseModel> response = await service.Transactions(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Transactions(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Transactions_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionStatusRepository>();
			mock.RepositoryMock.Setup(x => x.Transactions(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Transaction>>(new List<Transaction>()));
			var service = new TransactionStatusService(mock.LoggerMock.Object,
			                                           mock.RepositoryMock.Object,
			                                           mock.ModelValidatorMockFactory.TransactionStatusModelValidatorMock.Object,
			                                           mock.BOLMapperMockFactory.BOLTransactionStatusMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionStatusMapperMock,
			                                           mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                           mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionResponseModel> response = await service.Transactions(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Transactions(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>499bb375c5cff13055685208687c1678</Hash>
</Codenesium>*/