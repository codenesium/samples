using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "ApiModel")]
	public class TestApiBreedModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiBreedModelMapper();
			var model = new ApiBreedRequestModel();
			model.SetProperties("A");
			ApiBreedResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiBreedModelMapper();
			var model = new ApiBreedResponseModel();
			model.SetProperties(1, "A");
			ApiBreedRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiBreedModelMapper();
			var model = new ApiBreedRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiBreedRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiBreedRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>4a084e9ffd5c4729f8300230635e1e19</Hash>
</Codenesium>*/