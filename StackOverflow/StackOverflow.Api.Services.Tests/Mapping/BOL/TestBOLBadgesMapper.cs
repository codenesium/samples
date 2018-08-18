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
	[Trait("Table", "Badges")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLBadgesMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLBadgesMapper();
			ApiBadgesRequestModel model = new ApiBadgesRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			BOBadges response = mapper.MapModelToBO(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLBadgesMapper();
			BOBadges bo = new BOBadges();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			ApiBadgesResponseModel response = mapper.MapBOToModel(bo);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLBadgesMapper();
			BOBadges bo = new BOBadges();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			List<ApiBadgesResponseModel> response = mapper.MapBOToModel(new List<BOBadges>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a21b4fe0ae13f6930bc8a806ceba3593</Hash>
</Codenesium>*/