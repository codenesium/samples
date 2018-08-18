using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "DALMapper")]
	public class TestDALLocationMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALLocationMapper();
			var bo = new BOLocation();
			bo.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			Location response = mapper.MapBOToEF(bo);

			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.LocationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLocationMapper();
			Location entity = new Location();
			entity.SetProperties(1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			BOLocation response = mapper.MapEFToBO(entity);

			response.Availability.Should().Be(1);
			response.CostRate.Should().Be(1m);
			response.LocationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLocationMapper();
			Location entity = new Location();
			entity.SetProperties(1, 1m, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			List<BOLocation> response = mapper.MapEFToBO(new List<Location>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>791cfd9f405e925fe29f8d1c73bceacc</Hash>
</Codenesium>*/