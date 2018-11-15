using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostHistoryTypeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPostHistoryTypeModelMapper();
			var model = new ApiPostHistoryTypeClientRequestModel();
			model.SetProperties("A");
			ApiPostHistoryTypeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPostHistoryTypeModelMapper();
			var model = new ApiPostHistoryTypeClientResponseModel();
			model.SetProperties(1, "A");
			ApiPostHistoryTypeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Type.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>972839096d1f1c235c20baa0b9290b36</Hash>
</Codenesium>*/