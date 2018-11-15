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
			response.Detail.Should().Be("A");
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
			response.Detail.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0103a39647e4a1132efebb6b1cfa0db8</Hash>
</Codenesium>*/