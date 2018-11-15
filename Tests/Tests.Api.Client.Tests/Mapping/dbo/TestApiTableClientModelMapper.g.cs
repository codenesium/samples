using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Table")]
	[Trait("Area", "ApiModel")]
	public class TestApiTableModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTableModelMapper();
			var model = new ApiTableClientRequestModel();
			model.SetProperties("A");
			ApiTableClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTableModelMapper();
			var model = new ApiTableClientResponseModel();
			model.SetProperties(1, "A");
			ApiTableClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>10b986d5c9a4c44b38c2503b7d5ea57b</Hash>
</Codenesium>*/