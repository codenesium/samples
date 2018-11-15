using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "ApiModel")]
	public class TestApiUserServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", "A", "A");
			ApiUserServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.BioImgUrl.Should().Be("A");
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ContentDescription.Should().Be("A");
			response.Email.Should().Be("A");
			response.FullName.Should().Be("A");
			response.HeaderImgUrl.Should().Be("A");
			response.Interest.Should().Be("A");
			response.LocationLocationId.Should().Be(1);
			response.Password.Should().Be("A");
			response.PhoneNumber.Should().Be("A");
			response.Privacy.Should().Be("A");
			response.Username.Should().Be("A");
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", "A", "A");
			ApiUserServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.BioImgUrl.Should().Be("A");
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ContentDescription.Should().Be("A");
			response.Email.Should().Be("A");
			response.FullName.Should().Be("A");
			response.HeaderImgUrl.Should().Be("A");
			response.Interest.Should().Be("A");
			response.LocationLocationId.Should().Be(1);
			response.Password.Should().Be("A");
			response.PhoneNumber.Should().Be("A");
			response.Privacy.Should().Be("A");
			response.Username.Should().Be("A");
			response.Website.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUserServerModelMapper();
			var model = new ApiUserServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", "A", "A");

			JsonPatchDocument<ApiUserServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUserServerRequestModel();
			patch.ApplyTo(response);
			response.BioImgUrl.Should().Be("A");
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ContentDescription.Should().Be("A");
			response.Email.Should().Be("A");
			response.FullName.Should().Be("A");
			response.HeaderImgUrl.Should().Be("A");
			response.Interest.Should().Be("A");
			response.LocationLocationId.Should().Be(1);
			response.Password.Should().Be("A");
			response.PhoneNumber.Should().Be("A");
			response.Privacy.Should().Be("A");
			response.Username.Should().Be("A");
			response.Website.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>1a6cf778e65b754d74291202e5e8f5d0</Hash>
</Codenesium>*/