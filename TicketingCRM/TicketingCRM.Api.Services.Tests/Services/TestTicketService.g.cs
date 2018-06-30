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
        [Trait("Table", "Ticket")]
        [Trait("Area", "Services")]
        public partial class TicketServiceTests
        {
                [Fact]
                public async void All()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        var records = new List<Ticket>();
                        records.Add(new Ticket());
                        mock.RepositoryMock.Setup(x => x.All(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        List<ApiTicketResponseModel> response = await service.All();

                        response.Should().HaveCount(1);
                        mock.RepositoryMock.Verify(x => x.All(It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void Get()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        var record = new Ticket();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(record));
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        ApiTicketResponseModel response = await service.Get(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Get_null_record()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        mock.RepositoryMock.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        ApiTicketResponseModel response = await service.Get(default(int));

                        response.Should().BeNull();
                        mock.RepositoryMock.Verify(x => x.Get(It.IsAny<int>()));
                }

                [Fact]
                public async void Create()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        var model = new ApiTicketRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Ticket>())).Returns(Task.FromResult(new Ticket()));
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        CreateResponse<ApiTicketResponseModel> response = await service.Create(model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Verify(x => x.ValidateCreateAsync(It.IsAny<ApiTicketRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Create(It.IsAny<Ticket>()));
                }

                [Fact]
                public async void Update()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        var model = new ApiTicketRequestModel();
                        mock.RepositoryMock.Setup(x => x.Create(It.IsAny<Ticket>())).Returns(Task.FromResult(new Ticket()));
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        ActionResponse response = await service.Update(default(int), model);

                        response.Should().NotBeNull();
                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Verify(x => x.ValidateUpdateAsync(It.IsAny<int>(), It.IsAny<ApiTicketRequestModel>()));
                        mock.RepositoryMock.Verify(x => x.Update(It.IsAny<Ticket>()));
                }

                [Fact]
                public async void Delete()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        var model = new ApiTicketRequestModel();
                        mock.RepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Returns(Task.CompletedTask);
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        ActionResponse response = await service.Delete(default(int));

                        response.Should().NotBeNull();
                        mock.RepositoryMock.Verify(x => x.Delete(It.IsAny<int>()));
                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Verify(x => x.ValidateDeleteAsync(It.IsAny<int>()));
                }

                [Fact]
                public async void ByTicketStatusId_Exists()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        var records = new List<Ticket>();
                        records.Add(new Ticket());
                        mock.RepositoryMock.Setup(x => x.ByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        List<ApiTicketResponseModel> response = await service.ByTicketStatusId(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByTicketStatusId(It.IsAny<int>()));
                }

                [Fact]
                public async void ByTicketStatusId_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        mock.RepositoryMock.Setup(x => x.ByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult<List<Ticket>>(new List<Ticket>()));
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        List<ApiTicketResponseModel> response = await service.ByTicketStatusId(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.ByTicketStatusId(It.IsAny<int>()));
                }

                [Fact]
                public async void SaleTickets_Exists()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        var records = new List<SaleTickets>();
                        records.Add(new SaleTickets());
                        mock.RepositoryMock.Setup(x => x.SaleTickets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(records));
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        List<ApiSaleTicketsResponseModel> response = await service.SaleTickets(default(int));

                        response.Should().NotBeEmpty();
                        mock.RepositoryMock.Verify(x => x.SaleTickets(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }

                [Fact]
                public async void SaleTickets_Not_Exists()
                {
                        var mock = new ServiceMockFacade<ITicketRepository>();
                        mock.RepositoryMock.Setup(x => x.SaleTickets(default(int), It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<List<SaleTickets>>(new List<SaleTickets>()));
                        var service = new TicketService(mock.LoggerMock.Object,
                                                        mock.RepositoryMock.Object,
                                                        mock.ModelValidatorMockFactory.TicketModelValidatorMock.Object,
                                                        mock.BOLMapperMockFactory.BOLTicketMapperMock,
                                                        mock.DALMapperMockFactory.DALTicketMapperMock,
                                                        mock.BOLMapperMockFactory.BOLSaleTicketsMapperMock,
                                                        mock.DALMapperMockFactory.DALSaleTicketsMapperMock);

                        List<ApiSaleTicketsResponseModel> response = await service.SaleTickets(default(int));

                        response.Should().BeEmpty();
                        mock.RepositoryMock.Verify(x => x.SaleTickets(default(int), It.IsAny<int>(), It.IsAny<int>()));
                }
        }
}

/*<Codenesium>
    <Hash>729ca853178cc4cb37a26fe8dac551f2</Hash>
</Codenesium>*/