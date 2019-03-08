using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostHistoryTypesModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPostHistoryTypesModelMapper();
			var model = new ApiPostHistoryTypesClientRequestModel();
			model.SetProperties("A");
			ApiPostHistoryTypesClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPostHistoryTypesModelMapper();
			var model = new ApiPostHistoryTypesClientResponseModel();
			model.SetProperties(1, "A");
			ApiPostHistoryTypesClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d04cebb550f210a2fd90d1b3d767be69</Hash>
</Codenesium>*/