using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkType")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkTypeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALLinkTypeMapper();
			var bo = new BOLinkType();
			bo.SetProperties(1, "A");

			LinkType response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLinkTypeMapper();
			LinkType entity = new LinkType();
			entity.SetProperties(1, "A");

			BOLinkType response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLinkTypeMapper();
			LinkType entity = new LinkType();
			entity.SetProperties(1, "A");

			List<BOLinkType> response = mapper.MapEFToBO(new List<LinkType>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2825a654bc45ff642ffa61e5d2afb685</Hash>
</Codenesium>*/