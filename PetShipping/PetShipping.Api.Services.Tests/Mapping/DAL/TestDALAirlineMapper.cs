using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Airline")]
	[Trait("Area", "DALMapper")]
	public class TestDALAirlineMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALAirlineMapper();
			var bo = new BOAirline();
			bo.SetProperties(1, "A");

			Airline response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALAirlineMapper();
			Airline entity = new Airline();
			entity.SetProperties(1, "A");

			BOAirline response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALAirlineMapper();
			Airline entity = new Airline();
			entity.SetProperties(1, "A");

			List<BOAirline> response = mapper.MapEFToBO(new List<Airline>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e5c3ec6f60d967b0bc6a7f78ea6159aa</Hash>
</Codenesium>*/