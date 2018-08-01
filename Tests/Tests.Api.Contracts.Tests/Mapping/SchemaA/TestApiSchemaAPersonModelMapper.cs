using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiSchemaAPersonModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSchemaAPersonModelMapper();
			var model = new ApiSchemaAPersonRequestModel();
			model.SetProperties("A");
			ApiSchemaAPersonResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSchemaAPersonModelMapper();
			var model = new ApiSchemaAPersonResponseModel();
			model.SetProperties(1, "A");
			ApiSchemaAPersonRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSchemaAPersonModelMapper();
			var model = new ApiSchemaAPersonRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiSchemaAPersonRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSchemaAPersonRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f8c64724348c7c51fb910b8f771ab744</Hash>
</Codenesium>*/