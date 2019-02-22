using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Officer")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiOfficerModelMapper();
			var model = new ApiOfficerClientRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiOfficerClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Badge.Should().Be("A");
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiOfficerModelMapper();
			var model = new ApiOfficerClientResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiOfficerClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Badge.Should().Be("A");
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>16d812996a53f13119b2329ae92a8b61</Hash>
</Codenesium>*/