using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALTicketStatusMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTicketStatusMapper();
			var bo = new BOTicketStatus();
			bo.SetProperties(1, "A");

			TicketStatus response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTicketStatusMapper();
			TicketStatus entity = new TicketStatus();
			entity.SetProperties(1, "A");

			BOTicketStatus response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTicketStatusMapper();
			TicketStatus entity = new TicketStatus();
			entity.SetProperties(1, "A");

			List<BOTicketStatus> response = mapper.MapEFToBO(new List<TicketStatus>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>982f67a178998c04a596ec809f5bd592</Hash>
</Codenesium>*/