using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRequirement")]
	[Trait("Area", "ApiModel")]
	public class TestApiCountryRequirementModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCountryRequirementModelMapper();
			var model = new ApiCountryRequirementClientRequestModel();
			model.SetProperties(1, "A");
			ApiCountryRequirementClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Details.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCountryRequirementModelMapper();
			var model = new ApiCountryRequirementClientResponseModel();
			model.SetProperties(1, 1, "A");
			ApiCountryRequirementClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Details.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>75ebbef49029945a524706970dc5a36b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/