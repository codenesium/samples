using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "ApiModel")]
	public class TestApiBreedServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiBreedServerModelMapper();
			var model = new ApiBreedServerRequestModel();
			model.SetProperties("A", 1);
			ApiBreedServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiBreedServerModelMapper();
			var model = new ApiBreedServerResponseModel();
			model.SetProperties(1, "A", 1);
			ApiBreedServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiBreedServerModelMapper();
			var model = new ApiBreedServerRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiBreedServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiBreedServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3e69467103c882ea62a51a731e81d7c1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/