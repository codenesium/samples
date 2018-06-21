using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesOrderHeaderSalesReason")]
        [Trait("Area", "DALMapper")]
        public class TestDALSalesOrderHeaderSalesReasonMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSalesOrderHeaderSalesReasonMapper();
                        var bo = new BOSalesOrderHeaderSalesReason();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        SalesOrderHeaderSalesReason response = mapper.MapBOToEF(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesOrderID.Should().Be(1);
                        response.SalesReasonID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSalesOrderHeaderSalesReasonMapper();
                        SalesOrderHeaderSalesReason entity = new SalesOrderHeaderSalesReason();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);

                        BOSalesOrderHeaderSalesReason response = mapper.MapEFToBO(entity);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesOrderID.Should().Be(1);
                        response.SalesReasonID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSalesOrderHeaderSalesReasonMapper();
                        SalesOrderHeaderSalesReason entity = new SalesOrderHeaderSalesReason();
                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1);

                        List<BOSalesOrderHeaderSalesReason> response = mapper.MapEFToBO(new List<SalesOrderHeaderSalesReason>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>f5f235daf717ca0ad8395e07f08fa3a8</Hash>
</Codenesium>*/