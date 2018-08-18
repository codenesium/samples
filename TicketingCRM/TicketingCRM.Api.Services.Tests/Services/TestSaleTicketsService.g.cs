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
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "Services")]
	public partial class SaleTicketsServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISaleTicketsRepository>();
			var records = new List<SaleTickets>();
			records.Add(new SaleTickets());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISaleTicketsRepository>();
			var record = new SaleTickets();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiSaleTicketsResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISaleTicketsRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SaleTickets>(null));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ApiSaleTicketsResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISaleTicketsRepository>();
			var model = new ApiSaleTicketsRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SaleTickets>())).Returns(Task.FromResult(new SaleTickets()));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			CreateResponse<ApiSaleTicketsResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSaleTicketsRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SaleTickets>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISaleTicketsRepository>();
			var model = new ApiSaleTicketsRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SaleTickets>())).Returns(Task.FromResult(new SaleTickets()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SaleTickets()));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			UpdateResponse<ApiSaleTicketsResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleTicketsRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SaleTickets>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISaleTicketsRepository>();
			var model = new ApiSaleTicketsRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByTicketId_Exists()
		{
			var mock = new ServiceMockFacade<ISaleTicketsRepository>();
			var records = new List<SaleTickets>();
			records.Add(new SaleTickets());
			mock.RepositoryMock.Setup(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsResponseModel> response = await service.ByTicketId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTicketId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISaleTicketsRepository>();
			mock.RepositoryMock.Setup(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SaleTickets>>(new List<SaleTickets>()));
			var service = new SaleTicketsService(mock.LoggerMock.Object,
			                                     mock.RepositoryMock.Object,
			                                     mock.ModelValidatorMockFactory.SaleTicketsModelValidatorMock.Object,
			                                     mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
			                                     mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

			List<ApiSaleTicketsResponseModel> response = await service.ByTicketId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>c952f75fd23c4d31406c9fb905a15082</Hash>
</Codenesium>*/