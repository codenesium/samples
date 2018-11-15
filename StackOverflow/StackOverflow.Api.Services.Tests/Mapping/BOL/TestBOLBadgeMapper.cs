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
	[Trait("Table", "Badge")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLBadgeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLBadgeMapper();
			ApiBadgeServerRequestModel model = new ApiBadgeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			BOBadge response = mapper.MapModelToBO(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLBadgeMapper();
			BOBadge bo = new BOBadge();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiBadgeServerResponseModel response = mapper.MapBOToModel(bo);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLBadgeMapper();
			BOBadge bo = new BOBadge();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			List<ApiBadgeServerResponseModel> response = mapper.MapBOToModel(new List<BOBadge>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8c992fb7528dbb37fadf5569285ba0f1</Hash>
</Codenesium>*/