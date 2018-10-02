using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Badge")]
	[Trait("Area", "DALMapper")]
	public class TestDALBadgeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALBadgeMapper();
			var bo = new BOBadge();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			Badge response = mapper.MapBOToEF(bo);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALBadgeMapper();
			Badge entity = new Badge();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1);

			BOBadge response = mapper.MapEFToBO(entity);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALBadgeMapper();
			Badge entity = new Badge();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1);

			List<BOBadge> response = mapper.MapEFToBO(new List<Badge>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>58d5577148bfafd022edabb6b4f4bca7</Hash>
</Codenesium>*/