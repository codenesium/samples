using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSaleTicketMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSaleTicketMapper();
			ApiSaleTicketRequestModel model = new ApiSaleTicketRequestModel();
			model.SetProperties(1, 1);
			BOSaleTicket response = mapper.MapModelToBO(1, model);

			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSaleTicketMapper();
			BOSaleTicket bo = new BOSaleTicket();
			bo.SetProperties(1, 1, 1);
			ApiSaleTicketResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSaleTicketMapper();
			BOSaleTicket bo = new BOSaleTicket();
			bo.SetProperties(1, 1, 1);
			List<ApiSaleTicketResponseModel> response = mapper.MapBOToModel(new List<BOSaleTicket>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8655f47d6891f6a77a4f66613a7b44a2</Hash>
</Codenesium>*/