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
	[Trait("Table", "Following")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLFollowingMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLFollowingMapper();
			ApiFollowingServerRequestModel model = new ApiFollowingServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOFollowing response = mapper.MapModelToBO(1, model);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLFollowingMapper();
			BOFollowing bo = new BOFollowing();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiFollowingServerResponseModel response = mapper.MapBOToModel(bo);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLFollowingMapper();
			BOFollowing bo = new BOFollowing();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiFollowingServerResponseModel> response = mapper.MapBOToModel(new List<BOFollowing>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8140656ca9515497b7438d1572de8535</Hash>
</Codenesium>*/