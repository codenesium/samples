using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALChainStatuMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALChainStatuMapper();
			var bo = new BOChainStatu();
			bo.SetProperties(1, "A");

			ChainStatu response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALChainStatuMapper();
			ChainStatu entity = new ChainStatu();
			entity.SetProperties(1, "A");

			BOChainStatu response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALChainStatuMapper();
			ChainStatu entity = new ChainStatu();
			entity.SetProperties(1, "A");

			List<BOChainStatu> response = mapper.MapEFToBO(new List<ChainStatu>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>976f1ea0befb9445870bfb78678a506b</Hash>
</Codenesium>*/