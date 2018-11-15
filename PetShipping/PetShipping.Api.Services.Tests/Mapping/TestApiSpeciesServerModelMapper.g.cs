using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
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
    <Hash>5584226a108645478b6407baaabad184</Hash>
</Codenesium>*/