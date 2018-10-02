using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALTicketStatuMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTicketStatuMapper();
			var bo = new BOTicketStatu();
			bo.SetProperties(1, "A");

			TicketStatu response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTicketStatuMapper();
			TicketStatu entity = new TicketStatu();
			entity.SetProperties(1, "A");

			BOTicketStatu response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTicketStatuMapper();
			TicketStatu entity = new TicketStatu();
			entity.SetProperties(1, "A");

			List<BOTicketStatu> response = mapper.MapEFToBO(new List<TicketStatu>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8071830c82d41046e3a0f6b9ddc53ddd</Hash>
</Codenesium>*/