using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkStatuMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALLinkStatuMapper();
			var bo = new BOLinkStatu();
			bo.SetProperties(1, "A");

			LinkStatu response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLinkStatuMapper();
			LinkStatu entity = new LinkStatu();
			entity.SetProperties(1, "A");

			BOLinkStatu response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLinkStatuMapper();
			LinkStatu entity = new LinkStatu();
			entity.SetProperties(1, "A");

			List<BOLinkStatu> response = mapper.MapEFToBO(new List<LinkStatu>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a7ef6008ddad703db02dcf02c70c752a</Hash>
</Codenesium>*/