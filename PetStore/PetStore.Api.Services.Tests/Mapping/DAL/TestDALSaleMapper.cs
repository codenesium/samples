using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Sale")]
        [Trait("Area", "DALMapper")]
        public class TestDALSaleActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSaleMapper();

                        var bo = new BOSale();

                        bo.SetProperties(1, 1, "A", "A", 1, 1, "A");

                        Sale response = mapper.MapBOToEF(bo);

                        response.Amount.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.PaymentTypeId.Should().Be(1);
                        response.PetId.Should().Be(1);
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSaleMapper();

                        Sale entity = new Sale();

                        entity.SetProperties(1, "A", 1, "A", 1, 1, "A");

                        BOSale  response = mapper.MapEFToBO(entity);

                        response.Amount.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.PaymentTypeId.Should().Be(1);
                        response.PetId.Should().Be(1);
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSaleMapper();

                        Sale entity = new Sale();

                        entity.SetProperties(1, "A", 1, "A", 1, 1, "A");

                        List<BOSale> response = mapper.MapEFToBO(new List<Sale>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>04d4218995b13bd1495675fbb6716bc2</Hash>
</Codenesium>*/