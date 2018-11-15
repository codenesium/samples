using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiSchemaBPersonServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSchemaBPersonServerModelMapper();
			var model = new ApiSchemaBPersonServerRequestModel();
			model.SetProperties("A");
			ApiSchemaBPersonServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSchemaBPersonServerModelMapper();
			var model = new ApiSchemaBPersonServerResponseModel();
			model.SetProperties(1, "A");
			ApiSchemaBPersonServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSchemaBPersonServerModelMapper();
			var model = new ApiSchemaBPersonServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiSchemaBPersonServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSchemaBPersonServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>1bcdfe3f8165ae78d1ba087254064de4</Hash>
</Codenesium>*/