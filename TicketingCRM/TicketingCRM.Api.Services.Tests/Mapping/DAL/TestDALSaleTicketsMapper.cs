using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SaleTickets")]
        [Trait("Area", "DALMapper")]
        public class TestDALSaleTicketsActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSaleTicketsMapper();

                        var bo = new BOSaleTickets();

                        bo.SetProperties(1, 1, 1);

                        SaleTickets response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.SaleId.Should().Be(1);
                        response.TicketId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSaleTicketsMapper();

                        SaleTickets entity = new SaleTickets();

                        entity.SetProperties(1, 1, 1);

                        BOSaleTickets  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.SaleId.Should().Be(1);
                        response.TicketId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSaleTicketsMapper();

                        SaleTickets entity = new SaleTickets();

                        entity.SetProperties(1, 1, 1);

                        List<BOSaleTickets> response = mapper.MapEFToBO(new List<SaleTickets>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>38b1415a9741cfcd05bc54f0682b7fa4</Hash>
</Codenesium>*/