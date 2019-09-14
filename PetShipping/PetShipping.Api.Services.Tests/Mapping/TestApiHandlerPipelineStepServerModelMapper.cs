using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "ApiModel")]
	public class TestApiHandlerPipelineStepServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiHandlerPipelineStepServerModelMapper();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			model.SetProperties(1, 1);
			ApiHandlerPipelineStepServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiHandlerPipelineStepServerModelMapper();
			var model = new ApiHandlerPipelineStepServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiHandlerPipelineStepServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiHandlerPipelineStepServerModelMapper();
			var model = new ApiHandlerPipelineStepServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiHandlerPipelineStepServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiHandlerPipelineStepServerRequestModel();
			patch.ApplyTo(response);
			response.HandlerId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e209288c047df185deed3b6cafe2580a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/