using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepStepRequirementMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPipelineStepStepRequirementMapper();
			ApiPipelineStepStepRequirementServerRequestModel model = new ApiPipelineStepStepRequirementServerRequestModel();
			model.SetProperties("A", 1, true);
			PipelineStepStepRequirement response = mapper.MapModelToEntity(1, model);

			response.Details.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPipelineStepStepRequirementMapper();
			PipelineStepStepRequirement item = new PipelineStepStepRequirement();
			item.SetProperties(1, "A", 1, true);
			ApiPipelineStepStepRequirementServerResponseModel response = mapper.MapEntityToModel(item);

			response.Details.Should().Be("A");
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPipelineStepStepRequirementMapper();
			PipelineStepStepRequirement item = new PipelineStepStepRequirement();
			item.SetProperties(1, "A", 1, true);
			List<ApiPipelineStepStepRequirementServerResponseModel> response = mapper.MapEntityToModel(new List<PipelineStepStepRequirement>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1a8057e0fd44b83f93d735596a617d2c</Hash>
</Codenesium>*/