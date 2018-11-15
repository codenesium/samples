using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CreditCard")]
	[Trait("Area", "Services")]
	public partial class CreditCardServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var records = new List<CreditCard>();
			records.Add(new CreditCard());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiCreditCardServerResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var record = new CreditCard();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCreditCardServerResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCreditCardServerResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var model = new ApiCreditCardServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CreditCard>())).Returns(Task.FromResult(new CreditCard()));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			CreateResponse<ApiCreditCardServerResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiCreditCardServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<CreditCard>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var model = new ApiCreditCardServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<CreditCard>())).Returns(Task.FromResult(new CreditCard()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CreditCard()));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			UpdateResponse<ApiCreditCardServerResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiCreditCardServerRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<CreditCard>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var model = new ApiCreditCardServerRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByCardNumber_Exists()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var record = new CreditCard();
			mock.RepositoryMock.Setup(x => x.ByCardNumber(It.IsAny<string>())).Returns(Task.FromResult(record));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCreditCardServerResponseModel response = await service.ByCardNumber("test_value");

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.ByCardNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void ByCardNumber_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			mock.RepositoryMock.Setup(x => x.ByCardNumber(It.IsAny<string>())).Returns(Task.FromResult<CreditCard>(null));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			ApiCreditCardServerResponseModel response = await service.ByCardNumber("test_value");

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.ByCardNumber(It.IsAny<string>()));
		}

		[Fact]
		public async void SalesOrderHeadersByCreditCardID_Exists()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			var records = new List<SalesOrderHeader>();
			records.Add(new SalesOrderHeader());
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByCreditCardID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByCreditCardID(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByCreditCardID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SalesOrderHeadersByCreditCardID_Not_Exists()
		{
			var mock = new ServiceMockFacade<ICreditCardRepository>();
			mock.RepositoryMock.Setup(x => x.SalesOrderHeadersByCreditCardID(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SalesOrderHeader>>(new List<SalesOrderHeader>()));
			var service = new CreditCardService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.CreditCardModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLCreditCardMapperMock,
			                                    mock.DALMapperMockFactory.DALCreditCardMapperMock,
			                                    mock.BOLMapperMockFactory.BOLSalesOrderHeaderMapperMock,
			                                    mock.DALMapperMockFactory.DALSalesOrderHeaderMapperMock);

			List<ApiSalesOrderHeaderServerResponseModel> response = await service.SalesOrderHeadersByCreditCardID(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SalesOrderHeadersByCreditCardID(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>e877d0cfb23324c752a3825450e86217</Hash>
</Codenesium>*/