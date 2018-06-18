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
        [Trait("Table", "CurrencyRate")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCurrencyRateActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCurrencyRateMapper();

                        ApiCurrencyRateRequestModel model = new ApiCurrencyRateRequestModel();

                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOCurrencyRate response = mapper.MapModelToBO(1, model);

                        response.AverageRate.Should().Be(1);
                        response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.EndOfDayRate.Should().Be(1);
                        response.FromCurrencyCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ToCurrencyCode.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCurrencyRateMapper();

                        BOCurrencyRate bo = new BOCurrencyRate();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiCurrencyRateResponseModel response = mapper.MapBOToModel(bo);

                        response.AverageRate.Should().Be(1);
                        response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.CurrencyRateID.Should().Be(1);
                        response.EndOfDayRate.Should().Be(1);
                        response.FromCurrencyCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ToCurrencyCode.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCurrencyRateMapper();

                        BOCurrencyRate bo = new BOCurrencyRate();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiCurrencyRateResponseModel> response = mapper.MapBOToModel(new List<BOCurrencyRate>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>300a32bbc43c487f94ad99e2f7ed6445</Hash>
</Codenesium>*/