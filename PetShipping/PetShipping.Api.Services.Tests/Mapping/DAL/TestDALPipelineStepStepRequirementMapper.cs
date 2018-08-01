using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStepRequirement")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepStepRequirementMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPipelineStepStepRequirementMapper();
			var bo = new BOPipelineStepStepRequirement();
			bo.SetProperties(1, "A", 1, true);

			PipelineStepStepRequirement response = mapper.MapBOToEF(bo);

			response.Details.Should().Be("A");
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPipelineStepStepRequirementMapper();
			PipelineStepStepRequirement entity = new PipelineStepStepRequirement();
			entity.SetProperties("A", 1, 1, true);

			BOPipelineStepStepRequirement response = mapper.MapEFToBO(entity);

			response.Details.Should().Be("A");
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
			response.RequirementMet.Should().Be(true);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPipelineStepStepRequirementMapper();
			PipelineStepStepRequirement entity = new PipelineStepStepRequirement();
			entity.SetProperties("A", 1, 1, true);

			List<BOPipelineStepStepRequirement> response = mapper.MapEFToBO(new List<PipelineStepStepRequirement>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e76753193a530c37129b5e4a1d4a7057</Hash>
</Codenesium>*/