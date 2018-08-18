using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepStatusMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPipelineStepStatusMapper();
			var bo = new BOPipelineStepStatus();
			bo.SetProperties(1, "A");

			PipelineStepStatus response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPipelineStepStatusMapper();
			PipelineStepStatus entity = new PipelineStepStatus();
			entity.SetProperties(1, "A");

			BOPipelineStepStatus response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPipelineStepStatusMapper();
			PipelineStepStatus entity = new PipelineStepStatus();
			entity.SetProperties(1, "A");

			List<BOPipelineStepStatus> response = mapper.MapEFToBO(new List<PipelineStepStatus>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>02f6ca592020d66b0c21a6a779f49870</Hash>
</Codenesium>*/