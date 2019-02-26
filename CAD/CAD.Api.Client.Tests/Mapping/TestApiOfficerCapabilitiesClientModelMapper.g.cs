using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerCapabilities")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerCapabilitiesModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiOfficerCapabilitiesModelMapper();
			var model = new ApiOfficerCapabilitiesClientRequestModel();
			model.SetProperties(1);
			ApiOfficerCapabilitiesClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiOfficerCapabilitiesModelMapper();
			var model = new ApiOfficerCapabilitiesClientResponseModel();
			model.SetProperties(1, 1);
			ApiOfficerCapabilitiesClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.OfficerId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3c75af02c4b634648e08988eb8f1186c</Hash>
</Codenesium>*/