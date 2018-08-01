using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Country")]
	[Trait("Area", "ApiModel")]
	public class TestApiCountryModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiCountryModelMapper();
			var model = new ApiCountryRequestModel();
			model.SetProperties("A");
			ApiCountryResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiCountryModelMapper();
			var model = new ApiCountryResponseModel();
			model.SetProperties(1, "A");
			ApiCountryRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCountryModelMapper();
			var model = new ApiCountryRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiCountryRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCountryRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>52ab82a5a304139e9a6b22f3a9dad330</Hash>
</Codenesium>*/