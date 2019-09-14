using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRequirement")]
	[Trait("Area", "ApiModel")]
	public class TestApiCountryRequirementServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCountryRequirementServerModelMapper();
			var model = new ApiCountryRequirementServerRequestModel();
			model.SetProperties(1, "A");
			ApiCountryRequirementServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Details.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCountryRequirementServerModelMapper();
			var model = new ApiCountryRequirementServerResponseModel();
			model.SetProperties(1, 1, "A");
			ApiCountryRequirementServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Details.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCountryRequirementServerModelMapper();
			var model = new ApiCountryRequirementServerRequestModel();
			model.SetProperties(1, "A");

			JsonPatchDocument<ApiCountryRequirementServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCountryRequirementServerRequestModel();
			patch.ApplyTo(response);
			response.CountryId.Should().Be(1);
			response.Details.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>183925a4163fab2338b00325fcbf5a95</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/