using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "DALMapper")]
	public class TestDALOtherTransportMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALOtherTransportMapper();
			var bo = new BOOtherTransport();
			bo.SetProperties(1, 1, 1);

			OtherTransport response = mapper.MapBOToEF(bo);

			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALOtherTransportMapper();
			OtherTransport entity = new OtherTransport();
			entity.SetProperties(1, 1, 1);

			BOOtherTransport response = mapper.MapEFToBO(entity);

			response.HandlerId.Should().Be(1);
			response.Id.Should().Be(1);
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALOtherTransportMapper();
			OtherTransport entity = new OtherTransport();
			entity.SetProperties(1, 1, 1);

			List<BOOtherTransport> response = mapper.MapEFToBO(new List<OtherTransport>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>660dc3cced596167d50bb8f30ce1971f</Hash>
</Codenesium>*/