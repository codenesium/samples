using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPipelineStepMapper();
			var bo = new BOPipelineStep();
			bo.SetProperties(1, "A", 1, 1);

			PipelineStep response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPipelineStepMapper();
			PipelineStep entity = new PipelineStep();
			entity.SetProperties(1, "A", 1, 1);

			BOPipelineStep response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPipelineStepMapper();
			PipelineStep entity = new PipelineStep();
			entity.SetProperties(1, "A", 1, 1);

			List<BOPipelineStep> response = mapper.MapEFToBO(new List<PipelineStep>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8f0acca4d21687191a2edb484d7c7127</Hash>
</Codenesium>*/