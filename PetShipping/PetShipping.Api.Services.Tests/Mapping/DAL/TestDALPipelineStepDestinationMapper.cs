using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepDestinationMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPipelineStepDestinationMapper();
			var bo = new BOPipelineStepDestination();
			bo.SetProperties(1, 1, 1);

			PipelineStepDestination response = mapper.MapBOToEF(bo);

			response.DestinationId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPipelineStepDestinationMapper();
			PipelineStepDestination entity = new PipelineStepDestination();
			entity.SetProperties(1, 1, 1);

			BOPipelineStepDestination response = mapper.MapEFToBO(entity);

			response.DestinationId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPipelineStepDestinationMapper();
			PipelineStepDestination entity = new PipelineStepDestination();
			entity.SetProperties(1, 1, 1);

			List<BOPipelineStepDestination> response = mapper.MapEFToBO(new List<PipelineStepDestination>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>924d142b1a3bee67ee88d32f49c5e94f</Hash>
</Codenesium>*/