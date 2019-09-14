using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Organization")]
	[Trait("Area", "ApiModel")]
	public class TestApiOrganizationModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiOrganizationModelMapper();
			var model = new ApiOrganizationClientRequestModel();
			model.SetProperties("A");
			ApiOrganizationClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiOrganizationModelMapper();
			var model = new ApiOrganizationClientResponseModel();
			model.SetProperties(1, "A");
			ApiOrganizationClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e6f63524345e39d4ec30cba165a2c14f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/