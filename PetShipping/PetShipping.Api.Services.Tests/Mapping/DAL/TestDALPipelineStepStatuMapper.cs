using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepStatuMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPipelineStepStatuMapper();
			var bo = new BOPipelineStepStatu();
			bo.SetProperties(1, "A");

			PipelineStepStatu response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPipelineStepStatuMapper();
			PipelineStepStatu entity = new PipelineStepStatu();
			entity.SetProperties(1, "A");

			BOPipelineStepStatu response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPipelineStepStatuMapper();
			PipelineStepStatu entity = new PipelineStepStatu();
			entity.SetProperties(1, "A");

			List<BOPipelineStepStatu> response = mapper.MapEFToBO(new List<PipelineStepStatu>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>28b5ea5672ae333c5a8f97a274ac0c96</Hash>
</Codenesium>*/