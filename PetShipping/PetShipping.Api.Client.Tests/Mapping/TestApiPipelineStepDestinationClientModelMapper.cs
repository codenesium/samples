using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepDestinationModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPipelineStepDestinationModelMapper();
			var model = new ApiPipelineStepDestinationClientRequestModel();
			model.SetProperties(1, 1);
			ApiPipelineStepDestinationClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DestinationId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPipelineStepDestinationModelMapper();
			var model = new ApiPipelineStepDestinationClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiPipelineStepDestinationClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.DestinationId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>69862ce8d4510a8997e8cb81cf64d696</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/