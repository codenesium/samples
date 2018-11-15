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
	[Trait("Table", "Vote")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVoteMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVoteMapper();
			ApiVoteServerRequestModel model = new ApiVoteServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			BOVote response = mapper.MapModelToBO(1, model);

			response.BountyAmount.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.UserId.Should().Be(1);
			response.VoteTypeId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLVoteMapper();
			BOVote bo = new BOVote();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			ApiVoteServerResponseModel response = mapper.MapBOToModel(bo);

			response.BountyAmount.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.UserId.Should().Be(1);
			response.VoteTypeId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLVoteMapper();
			BOVote bo = new BOVote();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			List<ApiVoteServerResponseModel> response = mapper.MapBOToModel(new List<BOVote>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>79a7e624b698acba283e0428f95cff85</Hash>
</Codenesium>*/