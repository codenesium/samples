using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Reply")]
	[Trait("Area", "DALMapper")]
	public class TestDALReplyMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALReplyMapper();
			var bo = new BOReply();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("0"));

			Reply response = mapper.MapBOToEF(bo);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.ReplyId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALReplyMapper();
			Reply entity = new Reply();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"));

			BOReply response = mapper.MapEFToBO(entity);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.ReplyId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALReplyMapper();
			Reply entity = new Reply();
			entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"));

			List<BOReply> response = mapper.MapEFToBO(new List<Reply>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>054724baf413e7cf4104da2edd91d52b</Hash>
</Codenesium>*/