using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepDestinationServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPipelineStepDestinationServerModelMapper();
			var model = new ApiPipelineStepDestinationServerRequestModel();
			model.SetProperties(1, 1);
			ApiPipelineStepDestinationServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.DestinationId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPipelineStepDestinationServerModelMapper();
			var model = new ApiPipelineStepDestinationServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiPipelineStepDestinationServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.DestinationId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepDestinationServerModelMapper();
			var model = new ApiPipelineStepDestinationServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiPipelineStepDestinationServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepDestinationServerRequestModel();
			patch.ApplyTo(response);
			response.DestinationId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1332b0d96721bc662755f882718ca37c</Hash>
</Codenesium>*/