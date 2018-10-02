using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tag")]
	[Trait("Area", "DALMapper")]
	public class TestDALTagMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTagMapper();
			var bo = new BOTag();
			bo.SetProperties(1, 1, 1, "A", 1);

			Tag response = mapper.MapBOToEF(bo);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.Id.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTagMapper();
			Tag entity = new Tag();
			entity.SetProperties(1, 1, 1, "A", 1);

			BOTag response = mapper.MapEFToBO(entity);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.Id.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTagMapper();
			Tag entity = new Tag();
			entity.SetProperties(1, 1, 1, "A", 1);

			List<BOTag> response = mapper.MapEFToBO(new List<Tag>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>19250e037e71de7d7f34bca0b97445f4</Hash>
</Codenesium>*/