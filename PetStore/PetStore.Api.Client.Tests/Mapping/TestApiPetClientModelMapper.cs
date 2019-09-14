using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Client.Tests
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
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m);
			ApiPetClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPetModelMapper();
			var model = new ApiPetClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m);
			ApiPetClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
		}
	}
}

/*<Codenesium>
    <Hash>7c0ec3df260b086e9c163ef4e31bff77</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/