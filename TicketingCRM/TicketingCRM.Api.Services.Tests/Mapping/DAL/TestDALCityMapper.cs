using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "City")]
	[Trait("Area", "DALMapper")]
	public class TestDALCityMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALCityMapper();
			var bo = new BOCity();
			bo.SetProperties(1, "A", 1);

			City response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALCityMapper();
			City entity = new City();
			entity.SetProperties(1, "A", 1);

			BOCity response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALCityMapper();
			City entity = new City();
			entity.SetProperties(1, "A", 1);

			List<BOCity> response = mapper.MapEFToBO(new List<City>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8adb5c16bbc0ef72a83b1ed509f5c318</Hash>
</Codenesium>*/