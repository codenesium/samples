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
			ApiFollowingRequestModel model = new ApiFollowingRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOFollowing response = mapper.MapModelToBO("A", model);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLFollowingMapper();
			BOFollowing bo = new BOFollowing();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiFollowingResponseModel response = mapper.MapBOToModel(bo);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
			response.UserId.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLFollowingMapper();
			BOFollowing bo = new BOFollowing();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiFollowingResponseModel> response = mapper.MapBOToModel(new List<BOFollowing>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3622f71a59a4c453b98b99d4e7cfd8f9</Hash>
</Codenesium>*/