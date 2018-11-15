using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiSchemaBPersonModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSchemaBPersonModelMapper();
			var model = new ApiSchemaBPersonClientRequestModel();
			model.SetProperties("A");
			ApiSchemaBPersonClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSchemaBPersonModelMapper();
			var model = new ApiSchemaBPersonClientResponseModel();
			model.SetProperties(1, "A");
			ApiSchemaBPersonClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>acf1c962ca44e7bc6089abcf935347d8</Hash>
</Codenesium>*/