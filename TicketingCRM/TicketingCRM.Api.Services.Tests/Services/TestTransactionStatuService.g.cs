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
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "Services")]
	public partial class TransactionStatuServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var records = new List<TransactionStatu>();
			records.Add(new TransactionStatu());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionStatuResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var record = new TransactionStatu();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			ApiTransactionStatuResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatu>(null));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			ApiTransactionStatuResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var model = new ApiTransactionStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionStatu>())).Returns(Task.FromResult(new TransactionStatu()));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			CreateResponse<ApiTransactionStatuResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTransactionStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<TransactionStatu>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var model = new ApiTransactionStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<TransactionStatu>())).Returns(Task.FromResult(new TransactionStatu()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatu()));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			UpdateResponse<ApiTransactionStatuResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTransactionStatuRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<TransactionStatu>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var model = new ApiTransactionStatuRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void Transactions_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			var records = new List<Transaction>();
			records.Add(new Transaction());
			mock.RepositoryMock.Setup(x => x.Transactions(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionResponseModel> response = await service.Transactions(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.Transactions(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Transactions_Not_Exists()
		{
			var mock = new ServiceMockFacade<ITransactionStatuRepository>();
			mock.RepositoryMock.Setup(x => x.Transactions(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<Transaction>>(new List<Transaction>()));
			var service = new TransactionStatuService(mock.LoggerMock.Object,
			                                          mock.RepositoryMock.Object,
			                                          mock.ModelValidatorMockFactory.TransactionStatuModelValidatorMock.Object,
			                                          mock.BOLMapperMockFactory.BOLTransactionStatuMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionStatuMapperMock,
			                                          mock.BOLMapperMockFactory.BOLTransactionMapperMock,
			                                          mock.DALMapperMockFactory.DALTransactionMapperMock);

			List<ApiTransactionResponseModel> response = await service.Transactions(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.Transactions(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>0b51f313ef74b7b9ec903e3d397e3220</Hash>
</Codenesium>*/