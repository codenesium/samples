using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRegionCurrency")]
        [Trait("Area", "ApiModel")]
        public class TestApiCountryRegionCurrencyModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCountryRegionCurrencyModelMapper();
                        var model = new ApiCountryRegionCurrencyRequestModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiCountryRegionCurrencyResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.CountryRegionCode.Should().Be("A");
                        response.CurrencyCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCountryRegionCurrencyModelMapper();
                        var model = new ApiCountryRegionCurrencyResponseModel();
                        model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiCountryRegionCurrencyRequestModel response = mapper.MapResponseToRequest(model);

                        response.CurrencyCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>0dd28604cdfe804125115f8dba50fb0b</Hash>
</Codenesium>*/