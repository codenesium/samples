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
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);
			ApiPetClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPetModelMapper();
			var model = new ApiPetClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);
			ApiPetClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
			response.SpeciesId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>62062bf1c6790c3617ca14c29e5e7851</Hash>
</Codenesium>*/