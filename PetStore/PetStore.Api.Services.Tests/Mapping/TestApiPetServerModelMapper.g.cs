using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
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
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m);
			ApiPetServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPetServerModelMapper();
			var model = new ApiPetServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m);
			ApiPetServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPetServerModelMapper();
			var model = new ApiPetServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m);

			JsonPatchDocument<ApiPetServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPetServerRequestModel();
			patch.ApplyTo(response);
			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
		}
	}
}

/*<Codenesium>
    <Hash>5ee08bc0c34ba9dba70c59b816c155ea</Hash>
</Codenesium>*/