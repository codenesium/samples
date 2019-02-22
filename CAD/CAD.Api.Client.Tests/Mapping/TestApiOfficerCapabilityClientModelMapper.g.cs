using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerCapabilityModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiOfficerCapabilityModelMapper();
			var model = new ApiOfficerCapabilityClientRequestModel();
			model.SetProperties("A");
			ApiOfficerCapabilityClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiOfficerCapabilityModelMapper();
			var model = new ApiOfficerCapabilityClientResponseModel();
			model.SetProperties(1, "A");
			ApiOfficerCapabilityClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ec7312b935a517b8211a04faab27e664</Hash>
</Codenesium>*/