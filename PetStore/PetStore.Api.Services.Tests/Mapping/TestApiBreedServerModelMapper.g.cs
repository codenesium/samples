using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "ApiModel")]
	public class TestApiBreedServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiBreedServerModelMapper();
			var model = new ApiBreedServerRequestModel();
			model.SetProperties("A");
			ApiBreedServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiBreedServerModelMapper();
			var model = new ApiBreedServerResponseModel();
			model.SetProperties(1, "A");
			ApiBreedServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiBreedServerModelMapper();
			var model = new ApiBreedServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiBreedServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiBreedServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>66d1e1199331751092e9bf37bae2cd38</Hash>
</Codenesium>*/