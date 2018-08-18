using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Badges")]
	[Trait("Area", "DALMapper")]
	public class TestDALBadgesMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALBadgesMapper();
			var bo = new BOBadges();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			Badges response = mapper.MapBOToEF(bo);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALBadgesMapper();
			Badges entity = new Badges();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1);

			BOBadges response = mapper.MapEFToBO(entity);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALBadgesMapper();
			Badges entity = new Badges();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1);

			List<BOBadges> response = mapper.MapEFToBO(new List<Badges>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>17079ea364bb236bd9950623612f206d</Hash>
</Codenesium>*/