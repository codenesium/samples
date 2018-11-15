using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Species")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpeciesServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSpeciesServerModelMapper();
			var model = new ApiSpeciesServerRequestModel();
			model.SetProperties("A");
			ApiSpeciesServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSpeciesServerModelMapper();
			var model = new ApiSpeciesServerResponseModel();
			model.SetProperties(1, "A");
			ApiSpeciesServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpeciesServerModelMapper();
			var model = new ApiSpeciesServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiSpeciesServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpeciesServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>4bf6a03ce254aeb24b3a1a4593faa343</Hash>
</Codenesium>*/