using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Venue")]
	[Trait("Area", "ApiModel")]
	public class TestApiVenueModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVenueModelMapper();
			var model = new ApiVenueClientRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", "A", 1, "A");
			ApiVenueClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVenueModelMapper();
			var model = new ApiVenueClientResponseModel();
			model.SetProperties(1, "A", "A", 1, "A", "A", "A", "A", 1, "A");
			ApiVenueClientRequestModel response = mapper.MapClientResponseToRequest(model);
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
	}
}

/*<Codenesium>
    <Hash>2fc03f84e9f12f58e0faa0d84e5cd10e</Hash>
</Codenesium>*/