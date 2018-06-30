using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BusinessEntityAddress")]
        [Trait("Area", "ApiModel")]
        public class TestApiBusinessEntityAddressModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiBusinessEntityAddressModelMapper();
                        var model = new ApiBusinessEntityAddressRequestModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiBusinessEntityAddressResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AddressID.Should().Be(1);
                        response.AddressTypeID.Should().Be(1);
                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiBusinessEntityAddressModelMapper();
                        var model = new ApiBusinessEntityAddressResponseModel();
                        model.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiBusinessEntityAddressRequestModel response = mapper.MapResponseToRequest(model);

                        response.AddressID.Should().Be(1);
                        response.AddressTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>ebc6f2478d95fabc6b48f297ff1ac1fa</Hash>
</Codenesium>*/