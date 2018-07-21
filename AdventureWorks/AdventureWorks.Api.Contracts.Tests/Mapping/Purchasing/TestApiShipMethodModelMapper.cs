using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
                        ApiShipMethodResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.ShipBase.Should().Be(1m);
                        response.ShipMethodID.Should().Be(1);
                        response.ShipRate.Should().Be(1m);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiShipMethodModelMapper();
                        var model = new ApiShipMethodResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
                        ApiShipMethodRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.ShipBase.Should().Be(1m);
                        response.ShipRate.Should().Be(1m);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiShipMethodModelMapper();
                        var model = new ApiShipMethodRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);

                        JsonPatchDocument<ApiShipMethodRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiShipMethodRequestModel();
                        patch.ApplyTo(response);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.ShipBase.Should().Be(1m);
                        response.ShipRate.Should().Be(1m);
                }
        }
}

/*<Codenesium>
    <Hash>bf25da89748fdb3c7d21819403ab3ebd</Hash>
</Codenesium>*/