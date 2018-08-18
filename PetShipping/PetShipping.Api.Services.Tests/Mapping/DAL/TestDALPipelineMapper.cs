using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pipeline")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPipelineMapper();
			var bo = new BOPipeline();
			bo.SetProperties(1, 1, 1);

			Pipeline response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPipelineMapper();
			Pipeline entity = new Pipeline();
			entity.SetProperties(1, 1, 1);

			BOPipeline response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPipelineMapper();
			Pipeline entity = new Pipeline();
			entity.SetProperties(1, 1, 1);

			List<BOPipeline> response = mapper.MapEFToBO(new List<Pipeline>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f189a1cc0fe491d8cd244e7f9abef56d</Hash>
</Codenesium>*/