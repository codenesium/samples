using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStatuMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPipelineStatuMapper();
			var bo = new BOPipelineStatu();
			bo.SetProperties(1, "A");

			PipelineStatu response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPipelineStatuMapper();
			PipelineStatu entity = new PipelineStatu();
			entity.SetProperties(1, "A");

			BOPipelineStatu response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPipelineStatuMapper();
			PipelineStatu entity = new PipelineStatu();
			entity.SetProperties(1, "A");

			List<BOPipelineStatu> response = mapper.MapEFToBO(new List<PipelineStatu>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c8f3b6a7b80d6a91da65745eaed05b6d</Hash>
</Codenesium>*/