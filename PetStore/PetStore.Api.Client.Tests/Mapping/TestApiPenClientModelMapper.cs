using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pen")]
	[Trait("Area", "ApiModel")]
	public class TestApiPenModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPenModelMapper();
			var model = new ApiPenClientRequestModel();
			model.SetProperties("A");
			ApiPenClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPenModelMapper();
			var model = new ApiPenClientResponseModel();
			model.SetProperties(1, "A");
			ApiPenClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>95cd896992e9fb5389e516e380c416be</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/