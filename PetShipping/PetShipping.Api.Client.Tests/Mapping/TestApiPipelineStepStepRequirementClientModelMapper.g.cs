using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepStepRequirementModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPipelineStepStepRequirementModelMapper();
			var model = new ApiPipelineStepStepRequirementClientRequestModel();
			model.SetProperties("A", 1, true);
			ApiPipelineStepStepRequirementClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Details.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPipelineStepStepRequirementModelMapper();
			var model = new ApiPipelineStepStepRequirementClientResponseModel();
			model.SetProperties(1, "A", 1, true);
			ApiPipelineStepStepRequirementClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Details.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>9fbdbeae0a27baae4e58ce2a1f69da29</Hash>
</Codenesium>*/