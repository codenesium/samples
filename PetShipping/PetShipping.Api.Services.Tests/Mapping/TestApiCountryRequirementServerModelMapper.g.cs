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
			response.Detail.Should().Be("A");
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
			response.Detail.Should().Be("A");
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
			response.Detail.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>af68a5c0e402f43e6afde04c900e771a</Hash>
</Codenesium>*/