using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductPhoto")]
        [Trait("Area", "ApiModel")]
        public class TestApiProductPhotoModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiProductPhotoModelMapper();
                        var model = new ApiProductPhotoRequestModel();
                        model.SetProperties(BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
                        ApiProductPhotoResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.LargePhotoFileName.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductPhotoID.Should().Be(1);
                        response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.ThumbnailPhotoFileName.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiProductPhotoModelMapper();
                        var model = new ApiProductPhotoResponseModel();
                        model.SetProperties(1, BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
                        ApiProductPhotoRequestModel response = mapper.MapResponseToRequest(model);

                        response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.LargePhotoFileName.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.ThumbnailPhotoFileName.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>5b554d4e3c9aad2bf08acf840da0baac</Hash>
</Codenesium>*/