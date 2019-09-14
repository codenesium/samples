using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Team")]
	[Trait("Area", "ApiModel")]
	public class TestApiTeamModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTeamModelMapper();
			var model = new ApiTeamClientRequestModel();
			model.SetProperties("A", 1);
			ApiTeamClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.OrganizationId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTeamModelMapper();
			var model = new ApiTeamClientResponseModel();
			model.SetProperties(1, "A", 1);
			ApiTeamClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.OrganizationId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>17d2e2a6507c6b037a70f2c8f86917c1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/