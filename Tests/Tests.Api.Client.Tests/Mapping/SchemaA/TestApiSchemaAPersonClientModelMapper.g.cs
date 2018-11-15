using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiSchemaAPersonModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSchemaAPersonModelMapper();
			var model = new ApiSchemaAPersonClientRequestModel();
			model.SetProperties("A");
			ApiSchemaAPersonClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSchemaAPersonModelMapper();
			var model = new ApiSchemaAPersonClientResponseModel();
			model.SetProperties(1, "A");
			ApiSchemaAPersonClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e7b6ba71660c9f82e55097962580e8a6</Hash>
</Codenesium>*/