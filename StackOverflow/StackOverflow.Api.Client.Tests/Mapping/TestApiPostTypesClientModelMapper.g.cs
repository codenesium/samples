using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostTypesModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPostTypesModelMapper();
			var model = new ApiPostTypesClientRequestModel();
			model.SetProperties("A");
			ApiPostTypesClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPostTypesModelMapper();
			var model = new ApiPostTypesClientResponseModel();
			model.SetProperties(1, "A");
			ApiPostTypesClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>70116fbc0b91bf6d6029567a5239c8b6</Hash>
</Codenesium>*/