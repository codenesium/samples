using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductModelIllustration")]
        [Trait("Area", "ApiModel")]
        public class TestApiProductModelIllustrationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProductModelIllustrationModelMapper();
                        var model = new ApiProductModelIllustrationRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiProductModelIllustrationResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.IllustrationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductModelID.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProductModelIllustrationModelMapper();
                        var model = new ApiProductModelIllustrationResponseModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiProductModelIllustrationRequestModel response = mapper.MapResponseToRequest(model);

                        response.IllustrationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>20875582d7c6eaa3ae057ebb0b5943ab</Hash>
</Codenesium>*/