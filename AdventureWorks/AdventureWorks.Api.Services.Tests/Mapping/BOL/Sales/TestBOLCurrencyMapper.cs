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
        [Trait("Table", "Currency")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCurrencyActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCurrencyMapper();

                        ApiCurrencyRequestModel model = new ApiCurrencyRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOCurrency response = mapper.MapModelToBO("A", model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCurrencyMapper();

                        BOCurrency bo = new BOCurrency();

                        bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiCurrencyResponseModel response = mapper.MapBOToModel(bo);

                        response.CurrencyCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCurrencyMapper();

                        BOCurrency bo = new BOCurrency();

                        bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiCurrencyResponseModel> response = mapper.MapBOToModel(new List<BOCurrency>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>4af8375ebdabc5570de945c00348e348</Hash>
</Codenesium>*/