using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecureVideoCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Video")]
	[Trait("Area", "ApiModel")]
	public class TestApiVideoModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVideoModelMapper();
			var model = new ApiVideoClientRequestModel();
			model.SetProperties("A", "A", "A");
			ApiVideoClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Title.Should().Be("A");
			response.Url.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVideoModelMapper();
			var model = new ApiVideoClientResponseModel();
			model.SetProperties(1, "A", "A", "A");
			ApiVideoClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Title.Should().Be("A");
			response.Url.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>1ac17a63ed004d726d4bf979e8ad348c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/