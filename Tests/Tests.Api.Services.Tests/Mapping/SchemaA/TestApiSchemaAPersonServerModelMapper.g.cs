using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiSchemaAPersonServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSchemaAPersonServerModelMapper();
			var model = new ApiSchemaAPersonServerRequestModel();
			model.SetProperties("A");
			ApiSchemaAPersonServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSchemaAPersonServerModelMapper();
			var model = new ApiSchemaAPersonServerResponseModel();
			model.SetProperties(1, "A");
			ApiSchemaAPersonServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSchemaAPersonServerModelMapper();
			var model = new ApiSchemaAPersonServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiSchemaAPersonServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSchemaAPersonServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>6ebad3db4c4af1e91e49784fbdca7e53</Hash>
</Codenesium>*/