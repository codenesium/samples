using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallType")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallTypeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCallTypeModelMapper();
			var model = new ApiCallTypeClientRequestModel();
			model.SetProperties("A");
			ApiCallTypeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCallTypeModelMapper();
			var model = new ApiCallTypeClientResponseModel();
			model.SetProperties(1, "A");
			ApiCallTypeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5a54e54e564300e2c546fef8cd085304</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/