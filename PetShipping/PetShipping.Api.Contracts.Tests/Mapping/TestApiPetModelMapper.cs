using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pet")]
	[Trait("Area", "ApiModel")]
	public class TestApiPetModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPetModelMapper();
			var model = new ApiPetRequestModel();
			model.SetProperties(1, 1, "A", 1);
			ApiPetResponseModel response = mapper.MapRequestToResponse(1, model);

			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPetModelMapper();
			var model = new ApiPetResponseModel();
			model.SetProperties(1, 1, 1, "A", 1);
			ApiPetRequestModel response = mapper.MapResponseToRequest(model);

			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPetModelMapper();
			var model = new ApiPetRequestModel();
			model.SetProperties(1, 1, "A", 1);

			JsonPatchDocument<ApiPetRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPetRequestModel();
			patch.ApplyTo(response);
			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9b5076fbcea4fba06f644a17b86456d6</Hash>
</Codenesium>*/