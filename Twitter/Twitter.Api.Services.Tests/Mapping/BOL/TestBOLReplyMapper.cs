using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Reply")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLReplyMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLReplyMapper();
			ApiReplyServerRequestModel model = new ApiReplyServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			BOReply response = mapper.MapModelToBO(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLReplyMapper();
			BOReply bo = new BOReply();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiReplyServerResponseModel response = mapper.MapBOToModel(bo);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.ReplyId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLReplyMapper();
			BOReply bo = new BOReply();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			List<ApiReplyServerResponseModel> response = mapper.MapBOToModel(new List<BOReply>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c46152a8a60d9f401e306d375db23c0f</Hash>
</Codenesium>*/