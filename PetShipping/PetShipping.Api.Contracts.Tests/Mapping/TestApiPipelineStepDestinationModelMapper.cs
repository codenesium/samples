using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepDestinationModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPipelineStepDestinationModelMapper();
			var model = new ApiPipelineStepDestinationRequestModel();
			model.SetProperties(1, 1);
			ApiPipelineStepDestinationResponseModel response = mapper.MapRequestToResponse(1, model);

			response.DestinationId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPipelineStepDestinationModelMapper();
			var model = new ApiPipelineStepDestinationResponseModel();
			model.SetProperties(1, 1, 1);
			ApiPipelineStepDestinationRequestModel response = mapper.MapResponseToRequest(model);

			response.DestinationId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepDestinationModelMapper();
			var model = new ApiPipelineStepDestinationRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiPipelineStepDestinationRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepDestinationRequestModel();
			patch.ApplyTo(response);
			response.DestinationId.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4a3257da55e43c2f3fa2a1e4aaee15ff</Hash>
</Codenesium>*/