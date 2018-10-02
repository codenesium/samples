using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
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
			bo.SetProperties(1, 1, 1, "A");

			Location response = mapper.MapBOToEF(bo);

			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationId.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLocationMapper();
			Location entity = new Location();
			entity.SetProperties(1, 1, 1, "A");

			BOLocation response = mapper.MapEFToBO(entity);

			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationId.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLocationMapper();
			Location entity = new Location();
			entity.SetProperties(1, 1, 1, "A");

			List<BOLocation> response = mapper.MapEFToBO(new List<Location>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>93e16f6528b80108f0b0e251669a3e71</Hash>
</Codenesium>*/