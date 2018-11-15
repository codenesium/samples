using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "ApiModel")]
	public class TestApiAdminModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiAdminModelMapper();
			var model = new ApiAdminClientRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");
			ApiAdminClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiAdminModelMapper();
			var model = new ApiAdminClientResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A", "A");
			ApiAdminClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5aabb8838472c34eab0744f30cbf2276</Hash>
</Codenesium>*/