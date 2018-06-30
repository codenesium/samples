using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductProductPhoto")]
        [Trait("Area", "ApiModel")]
        public class TestApiProductProductPhotoModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProductProductPhotoModelMapper();
                        var model = new ApiProductProductPhotoRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
                        ApiProductProductPhotoResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Primary.Should().Be(true);
                        response.ProductID.Should().Be(1);
                        response.ProductPhotoID.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProductProductPhotoModelMapper();
                        var model = new ApiProductProductPhotoResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
                        ApiProductProductPhotoRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Primary.Should().Be(true);
                        response.ProductPhotoID.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>cd17adeb66e276eefccd4e2ce0408ba2</Hash>
</Codenesium>*/