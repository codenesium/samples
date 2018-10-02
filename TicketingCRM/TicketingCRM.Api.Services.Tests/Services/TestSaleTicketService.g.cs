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
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "Services")]
	public partial class SaleTicketServiceTests
	{
		[Fact]
		public async void All()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var records = new List<SaleTicket>();
			records.Add(new SaleTicket());
			mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSaleTicketMapperMock,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			List<ApiSaleTicketResponseModel> response = await service.All();

			response.Should().HaveCount(1);
			mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void Get()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var record = new SaleTicket();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSaleTicketMapperMock,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			ApiSaleTicketResponseModel response = await service.Get(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Get_null_record()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<SaleTicket>(null));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSaleTicketMapperMock,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			ApiSaleTicketResponseModel response = await service.Get(default(int));

			response.Should().BeNull();
			mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
		}

		[Fact]
		public async void Create()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var model = new ApiSaleTicketRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SaleTicket>())).Returns(Task.FromResult(new SaleTicket()));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSaleTicketMapperMock,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			CreateResponse<ApiSaleTicketResponseModel> response = await service.Create(model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiSaleTicketRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Create(It.IsAny<SaleTicket>()));
		}

		[Fact]
		public async void Update()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var model = new ApiSaleTicketRequestModel();
			mock.RepositoryMock.Setup(x => x.Create(It.IsAny<SaleTicket>())).Returns(Task.FromResult(new SaleTicket()));
			mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SaleTicket()));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSaleTicketMapperMock,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			UpdateResponse<ApiSaleTicketResponseModel> response = await service.Update(default(int), model);

			response.Should().NotBeNull();
			mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiSaleTicketRequestModel>()));
			mock.RepositoryMock.Verify(x => x.Update(It.IsAny<SaleTicket>()));
		}

		[Fact]
		public async void Delete()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var model = new ApiSaleTicketRequestModel();
			mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSaleTicketMapperMock,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			ActionResponse response = await service.Delete(default(int));

			response.Should().NotBeNull();
			mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
			mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
		}

		[Fact]
		public async void ByTicketId_Exists()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			var records = new List<SaleTicket>();
			records.Add(new SaleTicket());
			mock.RepositoryMock.Setup(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSaleTicketMapperMock,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			List<ApiSaleTicketResponseModel> response = await service.ByTicketId(default(int));

			response.Should().NotBeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}

		[Fact]
		public async void ByTicketId_Not_Exists()
		{
			var mock = new ServiceMockFacade<ISaleTicketRepository>();
			mock.RepositoryMock.Setup(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SaleTicket>>(new List<SaleTicket>()));
			var service = new SaleTicketService(mock.LoggerMock.Object,
			                                    mock.RepositoryMock.Object,
			                                    mock.ModelValidatorMockFactory.SaleTicketModelValidatorMock.Object,
			                                    mock.BOLMapperMockFactory.BOLSaleTicketMapperMock,
			                                    mock.DALMapperMockFactory.DALSaleTicketMapperMock);

			List<ApiSaleTicketResponseModel> response = await service.ByTicketId(default(int));

			response.Should().BeEmpty();
			mock.RepositoryMock.Verify(x => x.ByTicketId(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));
		}
	}
}

/*<Codenesium>
    <Hash>09d284f91cd92c92409371eb1807ed92</Hash>
</Codenesium>*/