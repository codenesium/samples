using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "ApiModel")]
	public class TestApiUserModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", "A", "A");
			ApiUserClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiUserModelMapper();
			var model = new ApiUserClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", "A", 1, "A", "A", "A", "A", "A");
			ApiUserClientRequestModel response = mapper.MapClientResponseToRequest(model);
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
	}
}

/*<Codenesium>
    <Hash>5257385061db27012312ab54cc50222c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/