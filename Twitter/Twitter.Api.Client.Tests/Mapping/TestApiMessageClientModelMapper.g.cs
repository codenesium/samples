using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TwitterNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Message")]
	[Trait("Area", "ApiModel")]
	public class TestApiMessageModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiMessageModelMapper();
			var model = new ApiMessageClientRequestModel();
			model.SetProperties("A", 1);
			ApiMessageClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiMessageModelMapper();
			var model = new ApiMessageClientResponseModel();
			model.SetProperties(1, "A", 1);
			ApiMessageClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Content.Should().Be("A");
			response.SenderUserId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>43255ab6211578a87768673b22fa8a56</Hash>
</Codenesium>*/