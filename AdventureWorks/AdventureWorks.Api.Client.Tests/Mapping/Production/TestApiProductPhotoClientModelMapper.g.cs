using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductPhotoModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiProductPhotoModelMapper();
			var model = new ApiProductPhotoClientRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			ApiProductPhotoClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiProductPhotoModelMapper();
			var model = new ApiProductPhotoClientResponseModel();
			model.SetProperties(1, BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			ApiProductPhotoClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>82b1aa6131a5b7225688d4ad8b5199da</Hash>
</Codenesium>*/