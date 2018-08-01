using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkTypes")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkTypesMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALLinkTypesMapper();
			var bo = new BOLinkTypes();
			bo.SetProperties(1, "A");

			LinkTypes response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLinkTypesMapper();
			LinkTypes entity = new LinkTypes();
			entity.SetProperties(1, "A");

			BOLinkTypes response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLinkTypesMapper();
			LinkTypes entity = new LinkTypes();
			entity.SetProperties(1, "A");

			List<BOLinkTypes> response = mapper.MapEFToBO(new List<LinkTypes>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>122f4facb67e3597c944bcb6b8398b19</Hash>
</Codenesium>*/