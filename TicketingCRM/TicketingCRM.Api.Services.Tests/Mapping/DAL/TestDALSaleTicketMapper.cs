using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "DALMapper")]
	public class TestDALSaleTicketMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSaleTicketMapper();
			var bo = new BOSaleTicket();
			bo.SetProperties(1, 1, 1);

			SaleTicket response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSaleTicketMapper();
			SaleTicket entity = new SaleTicket();
			entity.SetProperties(1, 1, 1);

			BOSaleTicket response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSaleTicketMapper();
			SaleTicket entity = new SaleTicket();
			entity.SetProperties(1, 1, 1);

			List<BOSaleTicket> response = mapper.MapEFToBO(new List<SaleTicket>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>245383711144a44012745647710fe106</Hash>
</Codenesium>*/