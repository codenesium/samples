using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Address")]
        [Trait("Area", "ApiModel")]
        public class TestApiAddressModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiAddressModelMapper();
                        var model = new ApiAddressRequestModel();
                        model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
                        ApiAddressResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AddressID.Should().Be(1);
                        response.AddressLine1.Should().Be("A");
                        response.AddressLine2.Should().Be("A");
                        response.City.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PostalCode.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.StateProvinceID.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiAddressModelMapper();
                        var model = new ApiAddressResponseModel();
                        model.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
                        ApiAddressRequestModel response = mapper.MapResponseToRequest(model);

                        response.AddressLine1.Should().Be("A");
                        response.AddressLine2.Should().Be("A");
                        response.City.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PostalCode.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.StateProvinceID.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>d6879f392bb5afb05ba606d957d3c030</Hash>
</Codenesium>*/