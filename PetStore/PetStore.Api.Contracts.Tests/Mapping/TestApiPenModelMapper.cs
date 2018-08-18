using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pen")]
	[Trait("Area", "ApiModel")]
	public class TestApiPenModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPenModelMapper();
			var model = new ApiPenRequestModel();
			model.SetProperties("A");
			ApiPenResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPenModelMapper();
			var model = new ApiPenResponseModel();
			model.SetProperties(1, "A");
			ApiPenRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPenModelMapper();
			var model = new ApiPenRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPenRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPenRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>093db86fa7ef40c8fa7601111204fda4</Hash>
</Codenesium>*/