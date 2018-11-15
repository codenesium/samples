using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Comment")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCommentMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCommentMapper();
			ApiCommentServerRequestModel model = new ApiCommentServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			BOComment response = mapper.MapModelToBO(1, model);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCommentMapper();
			BOComment bo = new BOComment();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			ApiCommentServerResponseModel response = mapper.MapBOToModel(bo);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCommentMapper();
			BOComment bo = new BOComment();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			List<ApiCommentServerResponseModel> response = mapper.MapBOToModel(new List<BOComment>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5243d2b732c5c8c8520d8759a5576327</Hash>
</Codenesium>*/