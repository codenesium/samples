using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Venue")]
	[Trait("Area", "ApiModel")]
	public class TestApiVenueServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVenueServerModelMapper();
			var model = new ApiVenueServerRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", "A", 1, "A");
			ApiVenueServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.AdminId.Should().Be(1);
			response.Email.Should().Be("A");
			response.Facebook.Should().Be("A");
			response.Name.Should().Be("A");
			response.Phone.Should().Be("A");
			response.ProvinceId.Should().Be(1);
			response.Website.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVenueServerModelMapper();
			var model = new ApiVenueServerResponseModel();
			model.SetProperties(1, "A", "A", 1, "A", "A", "A", "A", 1, "A");
			ApiVenueServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.AdminId.Should().Be(1);
			response.Email.Should().Be("A");
			response.Facebook.Should().Be("A");
			response.Name.Should().Be("A");
			response.Phone.Should().Be("A");
			response.ProvinceId.Should().Be(1);
			response.Website.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVenueServerModelMapper();
			var model = new ApiVenueServerRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", "A", 1, "A");

			JsonPatchDocument<ApiVenueServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVenueServerRequestModel();
			patch.ApplyTo(response);
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.AdminId.Should().Be(1);
			response.Email.Should().Be("A");
			response.Facebook.Should().Be("A");
			response.Name.Should().Be("A");
			response.Phone.Should().Be("A");
			response.ProvinceId.Should().Be(1);
			response.Website.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>a39e463c272280a2631f568b1633636a</Hash>
</Codenesium>*/