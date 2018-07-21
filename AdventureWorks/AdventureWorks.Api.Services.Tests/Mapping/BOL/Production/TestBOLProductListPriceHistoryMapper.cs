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
        [Trait("Table", "ProductListPriceHistory")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProductListPriceHistoryMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProductListPriceHistoryMapper();
                        ApiProductListPriceHistoryRequestModel model = new ApiProductListPriceHistoryRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
                        BOProductListPriceHistory response = mapper.MapModelToBO(1, model);

                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ListPrice.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProductListPriceHistoryMapper();
                        BOProductListPriceHistory bo = new BOProductListPriceHistory();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiProductListPriceHistoryResponseModel response = mapper.MapBOToModel(bo);

                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ListPrice.Should().Be(1m);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProductListPriceHistoryMapper();
                        BOProductListPriceHistory bo = new BOProductListPriceHistory();
                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
                        List<ApiProductListPriceHistoryResponseModel> response = mapper.MapBOToModel(new List<BOProductListPriceHistory>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2f811233c333c9d4cd0919bf54f681e8</Hash>
</Codenesium>*/