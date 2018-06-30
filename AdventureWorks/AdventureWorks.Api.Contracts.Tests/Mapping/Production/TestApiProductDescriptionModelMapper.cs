using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductDescription")]
        [Trait("Area", "ApiModel")]
        public class TestApiProductDescriptionModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProductDescriptionModelMapper();
                        var model = new ApiProductDescriptionRequestModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiProductDescriptionResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Description.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductDescriptionID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProductDescriptionModelMapper();
                        var model = new ApiProductDescriptionResponseModel();
                        model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiProductDescriptionRequestModel response = mapper.MapResponseToRequest(model);

                        response.Description.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>ba8d713b7d7ecf5767b22cb155108bee</Hash>
</Codenesium>*/