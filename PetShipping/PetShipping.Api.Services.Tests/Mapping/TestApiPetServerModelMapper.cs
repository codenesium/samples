using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pet")]
	[Trait("Area", "ApiModel")]
	public class TestApiPetServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPetServerModelMapper();
			var model = new ApiPetServerRequestModel();
			model.SetProperties(1, 1, "A", 1);
			ApiPetServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPetServerModelMapper();
			var model = new ApiPetServerResponseModel();
			model.SetProperties(1, 1, 1, "A", 1);
			ApiPetServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPetServerModelMapper();
			var model = new ApiPetServerRequestModel();
			model.SetProperties(1, 1, "A", 1);

			JsonPatchDocument<ApiPetServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPetServerRequestModel();
			patch.ApplyTo(response);
			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bd66ce1bbe9b179cc3dac648b91058fa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/