using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "ApiModel")]
	public class TestApiCompositePrimaryKeyModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCompositePrimaryKeyModelMapper();
			var model = new ApiCompositePrimaryKeyClientRequestModel();
			model.SetProperties(1);
			ApiCompositePrimaryKeyClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Id2.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCompositePrimaryKeyModelMapper();
			var model = new ApiCompositePrimaryKeyClientResponseModel();
			model.SetProperties(1, 1);
			ApiCompositePrimaryKeyClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Id2.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d032d6861ecf36446aa3834ed795ec98</Hash>
</Codenesium>*/