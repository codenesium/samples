using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ShipMethod")]
        [Trait("Area", "ApiModel")]
        public class TestApiShipMethodModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiShipMethodModelMapper();
                        var model = new ApiShipMethodRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        ApiShipMethodResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.ShipBase.Should().Be(1);
                        response.ShipMethodID.Should().Be(1);
                        response.ShipRate.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiShipMethodModelMapper();
                        var model = new ApiShipMethodResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        ApiShipMethodRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.ShipBase.Should().Be(1);
                        response.ShipRate.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b1e25672963a18fdd0bc6c85f5ab8a70</Hash>
</Codenesium>*/