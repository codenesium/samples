using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesReason")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSalesReasonActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSalesReasonMapper();

                        ApiSalesReasonRequestModel model = new ApiSalesReasonRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        BOSalesReason response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ReasonType.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSalesReasonMapper();

                        BOSalesReason bo = new BOSalesReason();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        ApiSalesReasonResponseModel response = mapper.MapBOToModel(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ReasonType.Should().Be("A");
                        response.SalesReasonID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSalesReasonMapper();

                        BOSalesReason bo = new BOSalesReason();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        List<ApiSalesReasonResponseModel> response = mapper.MapBOToModel(new List<BOSalesReason>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>25cee2c0609a6f833d7889149572c806</Hash>
</Codenesium>*/