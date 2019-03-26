using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductPhoto")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductPhotoServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiProductPhotoServerModelMapper();
			var model = new ApiProductPhotoServerRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			ApiProductPhotoServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiProductPhotoServerModelMapper();
			var model = new ApiProductPhotoServerResponseModel();
			model.SetProperties(1, BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");
			ApiProductPhotoServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProductPhotoServerModelMapper();
			var model = new ApiProductPhotoServerRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), BitConverter.GetBytes(1), "A");

			JsonPatchDocument<ApiProductPhotoServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductPhotoServerRequestModel();
			patch.ApplyTo(response);
			response.LargePhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.LargePhotoFileName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ThumbNailPhoto.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.ThumbnailPhotoFileName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>7bd32ad1857e44a828b65a18c57c9679</Hash>
</Codenesium>*/