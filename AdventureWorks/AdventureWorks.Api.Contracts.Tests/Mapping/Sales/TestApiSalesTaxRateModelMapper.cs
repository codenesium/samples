using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SalesTaxRate")]
        [Trait("Area", "ApiModel")]
        public class TestApiSalesTaxRateModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSalesTaxRateModelMapper();
                        var model = new ApiSalesTaxRateRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1);
                        ApiSalesTaxRateResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesTaxRateID.Should().Be(1);
                        response.StateProvinceID.Should().Be(1);
                        response.TaxRate.Should().Be(1);
                        response.TaxType.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSalesTaxRateModelMapper();
                        var model = new ApiSalesTaxRateResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1);
                        ApiSalesTaxRateRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.StateProvinceID.Should().Be(1);
                        response.TaxRate.Should().Be(1);
                        response.TaxType.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b556f1aa673c50d411735a7d0a37a8f5</Hash>
</Codenesium>*/