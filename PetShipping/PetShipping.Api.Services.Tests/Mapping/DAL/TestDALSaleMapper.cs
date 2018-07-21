using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Sale")]
        [Trait("Area", "DALMapper")]
        public class TestDALSaleMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSaleMapper();
                        var bo = new BOSale();
                        bo.SetProperties(1, 1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        Sale response = mapper.MapBOToEF(bo);

                        response.Amount.Should().Be(1m);
                        response.ClientId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Note.Should().Be("A");
                        response.PetId.Should().Be(1);
                        response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesPersonId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSaleMapper();
                        Sale entity = new Sale();
                        entity.SetProperties(1m, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        BOSale response = mapper.MapEFToBO(entity);

                        response.Amount.Should().Be(1m);
                        response.ClientId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Note.Should().Be("A");
                        response.PetId.Should().Be(1);
                        response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesPersonId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSaleMapper();
                        Sale entity = new Sale();
                        entity.SetProperties(1m, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        List<BOSale> response = mapper.MapEFToBO(new List<Sale>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>280a4545a2a359a5d88796316c13c323</Hash>
</Codenesium>*/