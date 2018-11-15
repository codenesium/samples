using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "ApiModel")]
	public class TestApiOtherTransportServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiOtherTransportServerModelMapper();
			var model = new ApiOtherTransportServerRequestModel();
			model.SetProperties(1, 1);
			ApiOtherTransportServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiOtherTransportServerModelMapper();
			var model = new ApiOtherTransportServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiOtherTransportServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOtherTransportServerModelMapper();
			var model = new ApiOtherTransportServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiOtherTransportServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOtherTransportServerRequestModel();
			patch.ApplyTo(response);
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>70f21e5f3e65bcf24ced3835729c7d65</Hash>
</Codenesium>*/