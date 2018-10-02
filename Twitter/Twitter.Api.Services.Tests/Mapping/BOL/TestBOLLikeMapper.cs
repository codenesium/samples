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
	[Trait("Table", "Like")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLLikeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLikeMapper();
			ApiLikeRequestModel model = new ApiLikeRequestModel();
			model.SetProperties(1, 1);
			BOLike response = mapper.MapModelToBO(1, model);

			response.LikerUserId.Should().Be(1);
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLikeMapper();
			BOLike bo = new BOLike();
			bo.SetProperties(1, 1, 1);
			ApiLikeResponseModel response = mapper.MapBOToModel(bo);

			response.LikeId.Should().Be(1);
			response.LikerUserId.Should().Be(1);
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLikeMapper();
			BOLike bo = new BOLike();
			bo.SetProperties(1, 1, 1);
			List<ApiLikeResponseModel> response = mapper.MapBOToModel(new List<BOLike>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c91c1f8d76661dd8b9cd8bc76baab0e7</Hash>
</Codenesium>*/