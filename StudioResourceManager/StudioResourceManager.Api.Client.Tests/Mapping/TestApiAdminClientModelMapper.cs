using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Client.Tests
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
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			ApiAdminClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiAdminModelMapper();
			var model = new ApiAdminClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			ApiAdminClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fc666ecf98aff9450e9a7e74f14dc6f6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/