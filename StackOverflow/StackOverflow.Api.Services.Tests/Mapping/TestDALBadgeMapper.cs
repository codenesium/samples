using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Badge")]
	[Trait("Area", "DALMapper")]
	public class TestDALBadgeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALBadgeMapper();
			ApiBadgeServerRequestModel model = new ApiBadgeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			Badge response = mapper.MapModelToEntity(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALBadgeMapper();
			Badge item = new Badge();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiBadgeServerResponseModel response = mapper.MapEntityToModel(item);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALBadgeMapper();
			Badge item = new Badge();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			List<ApiBadgeServerResponseModel> response = mapper.MapEntityToModel(new List<Badge>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7bcc8fdf1a21182fbe3209f0764dde82</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/