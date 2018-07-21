using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductCostHistory")]
        [Trait("Area", "DALMapper")]
        public class TestDALProductCostHistoryMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProductCostHistoryMapper();
                        var bo = new BOProductCostHistory();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        ProductCostHistory response = mapper.MapBOToEF(bo);

                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.StandardCost.Should().Be(1m);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProductCostHistoryMapper();
                        ProductCostHistory entity = new ProductCostHistory();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        BOProductCostHistory response = mapper.MapEFToBO(entity);

                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.StandardCost.Should().Be(1m);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProductCostHistoryMapper();
                        ProductCostHistory entity = new ProductCostHistory();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        List<BOProductCostHistory> response = mapper.MapEFToBO(new List<ProductCostHistory>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1180121b9e2ee93c280a8e454e4321a2</Hash>
</Codenesium>*/