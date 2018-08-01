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
	[Trait("Table", "Sale")]
	[Trait("Area", "Services")]
	public partial class SaleServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			var record = new Sale();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiSaleResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiSaleResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			var model = new ApiSaleRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Sale>())).Returns(Task.FromResult(new Sale()));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			CreateResponse<ApiSaleResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SaleModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSaleRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Sale>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			var model = new ApiSaleRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Sale>())).Returns(Task.FromResult(new Sale()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			UpdateResponse<ApiSaleResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SaleModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Sale>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			var model = new ApiSaleRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SaleModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByTransactionId_Exists()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			var records = new List<Sale>();
			records.Add(new Sale());
			mock.RepositoryMock.Setup(x => x.ByTransactionId(It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleResponseModel> response = await service.ByTransactionId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTransactionId(It.IsAny<int>()));
		}

		[Fact]
		public async void ByTransactionId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			mock.RepositoryMock.Setup(x => x.ByTransactionId(It.IsAny<int>())).Returns(Task.FromResult<List<Sale>>(new List<Sale>()));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleResponseModel> response = await service.ByTransactionId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTransactionId(It.IsAny<int>()));
		}

		[Fact]
		public async void SaleTickets_Exists()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			var records = new List<SaleTickets>();
			records.Add(new SaleTickets());
			mock.RepositoryMock.Setup(x => x.SaleTickets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsResponseModel> response = await service.SaleTickets(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.SaleTickets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void SaleTickets_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISaleRepository>();
			mock.RepositoryMock.Setup(x => x.SaleTickets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SaleTickets>>(new List<SaleTickets>()));
			var service = new SaleService(mock.LoggerMock.Object,
			                              mock.RepositoryMock.Object,
			                              mock.ModelValidatorMockFactory.SaleModelValidatorMock.Object,
			                              mock.BOLMapperMockFactory.BOLSaleMapperMock,
			                              mock.DALMapperMockFactory.DALSaleMapperMock,
			                              mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                              mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsResponseModel> response = await service.SaleTickets(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.SaleTickets(default(int), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>672331218d9c8df45e5fcfba92044c94</Hash>
</Codenesium>*/