using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "ApiModel")]
	public class TestApiBreedModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiBreedModelMapper();
			var model = new ApiBreedClientRequestModel();
			model.SetProperties("A", 1);
			ApiBreedClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiBreedModelMapper();
			var model = new ApiBreedClientResponseModel();
			model.SetProperties(1, "A", 1);
			ApiBreedClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3ca19b1f7f2a6cbfb900ef2802a440c1</Hash>
</Codenesium>*/