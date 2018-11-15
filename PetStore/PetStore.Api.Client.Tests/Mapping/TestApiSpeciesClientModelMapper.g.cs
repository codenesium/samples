using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Species")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpeciesModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSpeciesModelMapper();
			var model = new ApiSpeciesClientRequestModel();
			model.SetProperties("A");
			ApiSpeciesClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSpeciesModelMapper();
			var model = new ApiSpeciesClientResponseModel();
			model.SetProperties(1, "A");
			ApiSpeciesClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>842e2bca8db14fb61d2c853a726f42ab</Hash>
</Codenesium>*/