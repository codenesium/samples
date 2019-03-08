using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Badges")]
	[Trait("Area", "DALMapper")]
	public class TestDALBadgesMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALBadgesMapper();
			ApiBadgesServerRequestModel model = new ApiBadgesServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			Badges response = mapper.MapModelToEntity(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALBadgesMapper();
			Badges item = new Badges();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiBadgesServerResponseModel response = mapper.MapEntityToModel(item);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALBadgesMapper();
			Badges item = new Badges();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			List<ApiBadgesServerResponseModel> response = mapper.MapEntityToModel(new List<Badges>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4d903d8e9c90cddb6bf9797b798be4aa</Hash>
</Codenesium>*/