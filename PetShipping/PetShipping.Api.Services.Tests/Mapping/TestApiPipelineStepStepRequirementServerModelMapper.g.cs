using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepStepRequirementServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPipelineStepStepRequirementServerModelMapper();
			var model = new ApiPipelineStepStepRequirementServerRequestModel();
			model.SetProperties("A", 1, true);
			ApiPipelineStepStepRequirementServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Detail.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPipelineStepStepRequirementServerModelMapper();
			var model = new ApiPipelineStepStepRequirementServerResponseModel();
			model.SetProperties(1, "A", 1, true);
			ApiPipelineStepStepRequirementServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Detail.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepStepRequirementServerModelMapper();
			var model = new ApiPipelineStepStepRequirementServerRequestModel();
			model.SetProperties("A", 1, true);

			JsonPatchDocument<ApiPipelineStepStepRequirementServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepStepRequirementServerRequestModel();
			patch.ApplyTo(response);
			response.Detail.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>07bcb866ff851abda508c90ad9ac4cc3</Hash>
</Codenesium>*/