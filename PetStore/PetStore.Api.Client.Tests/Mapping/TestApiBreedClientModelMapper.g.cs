using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Client.Tests
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
			model.SetProperties("A");
			ApiBreedClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiBreedModelMapper();
			var model = new ApiBreedClientResponseModel();
			model.SetProperties(1, "A");
			ApiBreedClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f5fe1fc1da9132e970825c737a838fa0</Hash>
</Codenesium>*/