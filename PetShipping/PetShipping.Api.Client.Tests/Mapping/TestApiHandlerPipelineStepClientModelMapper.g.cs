using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "ApiModel")]
	public class TestApiHandlerPipelineStepModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiHandlerPipelineStepModelMapper();
			var model = new ApiHandlerPipelineStepClientRequestModel();
			model.SetProperties(1, 1);
			ApiHandlerPipelineStepClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiHandlerPipelineStepModelMapper();
			var model = new ApiHandlerPipelineStepClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiHandlerPipelineStepClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>74b67c15297580c2e095d8e167631272</Hash>
</Codenesium>*/