using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductModel")]
        [Trait("Area", "ApiModel")]
        public class TestApiProductModelModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProductModelModelMapper();
                        var model = new ApiProductModelRequestModel();
                        model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiProductModelResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.CatalogDescription.Should().Be("A");
                        response.Instructions.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ProductModelID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProductModelModelMapper();
                        var model = new ApiProductModelResponseModel();
                        model.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiProductModelRequestModel response = mapper.MapResponseToRequest(model);

                        response.CatalogDescription.Should().Be("A");
                        response.Instructions.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>2ad3021068e853746f73e89a740ad7d6</Hash>
</Codenesium>*/