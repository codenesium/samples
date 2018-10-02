using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Like")]
	[Trait("Area", "DALMapper")]
	public class TestDALLikeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALLikeMapper();
			var bo = new BOLike();
			bo.SetProperties(1, 1, 1);

			Like response = mapper.MapBOToEF(bo);

			response.LikeId.Should().Be(1);
			response.LikerUserId.Should().Be(1);
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLikeMapper();
			Like entity = new Like();
			entity.SetProperties(1, 1, 1);

			BOLike response = mapper.MapEFToBO(entity);

			response.LikeId.Should().Be(1);
			response.LikerUserId.Should().Be(1);
			response.TweetId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLikeMapper();
			Like entity = new Like();
			entity.SetProperties(1, 1, 1);

			List<BOLike> response = mapper.MapEFToBO(new List<Like>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>51b78892f0ef5d18443b62eda3a218de</Hash>
</Codenesium>*/