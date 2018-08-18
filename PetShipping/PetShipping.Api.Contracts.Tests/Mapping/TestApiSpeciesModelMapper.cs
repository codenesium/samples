using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Species")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpeciesModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSpeciesModelMapper();
			var model = new ApiSpeciesRequestModel();
			model.SetProperties("A");
			ApiSpeciesResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSpeciesModelMapper();
			var model = new ApiSpeciesResponseModel();
			model.SetProperties(1, "A");
			ApiSpeciesRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpeciesModelMapper();
			var model = new ApiSpeciesRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiSpeciesRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpeciesRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>871f33cf0bc6ca29b52ac8d55ad2966a</Hash>
</Codenesium>*/