using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPipelineStepStepRequirementMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPipelineStepStepRequirementMapper();
			ApiPipelineStepStepRequirementServerRequestModel model = new ApiPipelineStepStepRequirementServerRequestModel();
			model.SetProperties("A", 1, true);
			BOPipelineStepStepRequirement response = mapper.MapModelToBO(1, model);

			response.Detail.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPipelineStepStepRequirementMapper();
			BOPipelineStepStepRequirement bo = new BOPipelineStepStepRequirement();
			bo.SetProperties(1, "A", 1, true);
			ApiPipelineStepStepRequirementServerResponseModel response = mapper.MapBOToModel(bo);

			response.Detail.Should().Be("A");
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPipelineStepStepRequirementMapper();
			BOPipelineStepStepRequirement bo = new BOPipelineStepStepRequirement();
			bo.SetProperties(1, "A", 1, true);
			List<ApiPipelineStepStepRequirementServerResponseModel> response = mapper.MapBOToModel(new List<BOPipelineStepStepRequirement>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>87042ea684469c977a0fdb4f64549254</Hash>
</Codenesium>*/