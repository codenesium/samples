using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "DALMapper")]
	public class TestDALSaleTicketsMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSaleTicketsMapper();
			var bo = new BOSaleTickets();
			bo.SetProperties(1, 1, 1);

			SaleTickets response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSaleTicketsMapper();
			SaleTickets entity = new SaleTickets();
			entity.SetProperties(1, 1, 1);

			BOSaleTickets response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSaleTicketsMapper();
			SaleTickets entity = new SaleTickets();
			entity.SetProperties(1, 1, 1);

			List<BOSaleTickets> response = mapper.MapEFToBO(new List<SaleTickets>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>35059279834f25afd86266c62a22e7d1</Hash>
</Codenesium>*/