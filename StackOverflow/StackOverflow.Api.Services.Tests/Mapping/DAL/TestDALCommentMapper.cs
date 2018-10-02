using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Comment")]
	[Trait("Area", "DALMapper")]
	public class TestDALCommentMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALCommentMapper();
			var bo = new BOComment();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);

			Comment response = mapper.MapBOToEF(bo);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALCommentMapper();
			Comment entity = new Comment();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", 1);

			BOComment response = mapper.MapEFToBO(entity);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALCommentMapper();
			Comment entity = new Comment();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", 1);

			List<BOComment> response = mapper.MapEFToBO(new List<Comment>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>89cfbd006a9f37de571362e94d747e75</Hash>
</Codenesium>*/