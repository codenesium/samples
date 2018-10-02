using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostLink")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostLinkMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPostLinkMapper();
			var bo = new BOPostLink();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);

			PostLink response = mapper.MapBOToEF(bo);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPostLinkMapper();
			PostLink entity = new PostLink();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);

			BOPostLink response = mapper.MapEFToBO(entity);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPostLinkMapper();
			PostLink entity = new PostLink();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);

			List<BOPostLink> response = mapper.MapEFToBO(new List<PostLink>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>19c1630ed07f5852814b745b141cdba5</Hash>
</Codenesium>*/