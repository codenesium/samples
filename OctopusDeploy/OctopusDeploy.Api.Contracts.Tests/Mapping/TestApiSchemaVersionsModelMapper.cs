using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaVersions")]
	[Trait("Area", "ApiModel")]
	public class TestApiSchemaVersionsModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSchemaVersionsModelMapper();
			var model = new ApiSchemaVersionsRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiSchemaVersionsResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.ScriptName.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSchemaVersionsModelMapper();
			var model = new ApiSchemaVersionsResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiSchemaVersionsRequestModel response = mapper.MapResponseToRequest(model);

			response.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScriptName.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSchemaVersionsModelMapper();
			var model = new ApiSchemaVersionsRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiSchemaVersionsRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSchemaVersionsRequestModel();
			patch.ApplyTo(response);
			response.Applied.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ScriptName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>a604319e6138d1faa2873aa09ca93b66</Hash>
</Codenesium>*/