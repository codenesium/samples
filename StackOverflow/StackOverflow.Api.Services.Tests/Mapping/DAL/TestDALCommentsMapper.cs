using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Comments")]
	[Trait("Area", "DALMapper")]
	public class TestDALCommentsMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALCommentsMapper();
			var bo = new BOComments();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);

			Comments response = mapper.MapBOToEF(bo);

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
			var mapper = new DALCommentsMapper();
			Comments entity = new Comments();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", 1);

			BOComments response = mapper.MapEFToBO(entity);

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
			var mapper = new DALCommentsMapper();
			Comments entity = new Comments();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", 1);

			List<BOComments> response = mapper.MapEFToBO(new List<Comments>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>54fbcf54c310c53ba2908c5c7a67f415</Hash>
</Codenesium>*/