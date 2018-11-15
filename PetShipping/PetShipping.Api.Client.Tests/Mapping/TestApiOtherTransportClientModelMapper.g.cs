using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "ApiModel")]
	public class TestApiOtherTransportModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiOtherTransportModelMapper();
			var model = new ApiOtherTransportClientRequestModel();
			model.SetProperties(1, 1);
			ApiOtherTransportClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiOtherTransportModelMapper();
			var model = new ApiOtherTransportClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiOtherTransportClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>59220eab83f42776f62fe26b20181b5c</Hash>
</Codenesium>*/