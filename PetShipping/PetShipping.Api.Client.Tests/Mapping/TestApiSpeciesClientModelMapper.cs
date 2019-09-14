using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
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
    <Hash>c12cd0b0d164f0dc9e7c8517e3c06d1b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/