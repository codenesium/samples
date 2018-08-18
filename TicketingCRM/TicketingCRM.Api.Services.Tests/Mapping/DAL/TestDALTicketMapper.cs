using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Ticket")]
	[Trait("Area", "DALMapper")]
	public class TestDALTicketMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTicketMapper();
			var bo = new BOTicket();
			bo.SetProperties(1, "A", 1);

			Ticket response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTicketMapper();
			Ticket entity = new Ticket();
			entity.SetProperties(1, "A", 1);

			BOTicket response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTicketMapper();
			Ticket entity = new Ticket();
			entity.SetProperties(1, "A", 1);

			List<BOTicket> response = mapper.MapEFToBO(new List<Ticket>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f7970e4ac4261fbf1eab4784f3663bbd</Hash>
</Codenesium>*/