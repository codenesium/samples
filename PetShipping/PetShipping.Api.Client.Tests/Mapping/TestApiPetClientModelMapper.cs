using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pet")]
	[Trait("Area", "ApiModel")]
	public class TestApiPetModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPetModelMapper();
			var model = new ApiPetClientRequestModel();
			model.SetProperties(1, 1, "A", 1);
			ApiPetClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPetModelMapper();
			var model = new ApiPetClientResponseModel();
			model.SetProperties(1, 1, 1, "A", 1);
			ApiPetClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>49134ade9fd47ef5d1abde9682d93ac0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/