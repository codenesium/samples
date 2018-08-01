using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistory")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostHistoryMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPostHistoryMapper();
			var bo = new BOPostHistory();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);

			PostHistory response = mapper.MapBOToEF(bo);

			response.Comment.Should().Be("A");
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostHistoryTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RevisionGUID.Should().Be("A");
			response.Text.Should().Be("A");
			response.UserDisplayName.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPostHistoryMapper();
			PostHistory entity = new PostHistory();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", "A", "A", 1);

			BOPostHistory response = mapper.MapEFToBO(entity);

			response.Comment.Should().Be("A");
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostHistoryTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RevisionGUID.Should().Be("A");
			response.Text.Should().Be("A");
			response.UserDisplayName.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPostHistoryMapper();
			PostHistory entity = new PostHistory();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, "A", "A", "A", 1);

			List<BOPostHistory> response = mapper.MapEFToBO(new List<PostHistory>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f84d62fb34ee549c50b6a4927ca3fa91</Hash>
</Codenesium>*/