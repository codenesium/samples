using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALChainStatusMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALChainStatusMapper();
			var bo = new BOChainStatus();
			bo.SetProperties(1, "A");

			ChainStatus response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALChainStatusMapper();
			ChainStatus entity = new ChainStatus();
			entity.SetProperties(1, "A");

			BOChainStatus response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALChainStatusMapper();
			ChainStatus entity = new ChainStatus();
			entity.SetProperties(1, "A");

			List<BOChainStatus> response = mapper.MapEFToBO(new List<ChainStatus>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2610e2665318e8d243e1a445dea8a315</Hash>
</Codenesium>*/