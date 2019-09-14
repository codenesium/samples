using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Following")]
	[Trait("Area", "DALMapper")]
	public class TestDALFollowingMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALFollowingMapper();
			ApiFollowingServerRequestModel model = new ApiFollowingServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			Following response = mapper.MapModelToEntity(1, model);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALFollowingMapper();
			Following item = new Following();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiFollowingServerResponseModel response = mapper.MapEntityToModel(item);

			response.DateFollowed.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Muted.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALFollowingMapper();
			Following item = new Following();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiFollowingServerResponseModel> response = mapper.MapEntityToModel(new List<Following>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>712c066bceebebbece96d8bcb6297456</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/