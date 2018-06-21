using AdventureWorksNS.Api.Contracts;
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
        [Trait("Area", "BOLMapper")]
        public class TestBOLSalesOrderHeaderSalesReasonMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSalesOrderHeaderSalesReasonMapper();
                        ApiSalesOrderHeaderSalesReasonRequestModel model = new ApiSalesOrderHeaderSalesReasonRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        BOSalesOrderHeaderSalesReason response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesReasonID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSalesOrderHeaderSalesReasonMapper();
                        BOSalesOrderHeaderSalesReason bo = new BOSalesOrderHeaderSalesReason();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        ApiSalesOrderHeaderSalesReasonResponseModel response = mapper.MapBOToModel(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesOrderID.Should().Be(1);
                        response.SalesReasonID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSalesOrderHeaderSalesReasonMapper();
                        BOSalesOrderHeaderSalesReason bo = new BOSalesOrderHeaderSalesReason();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        List<ApiSalesOrderHeaderSalesReasonResponseModel> response = mapper.MapBOToModel(new List<BOSalesOrderHeaderSalesReason>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>97a2ae435d50042647830c4d9a87dc27</Hash>
</Codenesium>*/