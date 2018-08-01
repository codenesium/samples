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
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSaleTicketsMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSaleTicketsMapper();
			ApiSaleTicketsRequestModel model = new ApiSaleTicketsRequestModel();
			model.SetProperties(1, 1);
			BOSaleTickets response = mapper.MapModelToBO(1, model);

			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSaleTicketsMapper();
			BOSaleTickets bo = new BOSaleTickets();
			bo.SetProperties(1, 1, 1);
			ApiSaleTicketsResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSaleTicketsMapper();
			BOSaleTickets bo = new BOSaleTickets();
			bo.SetProperties(1, 1, 1);
			List<ApiSaleTicketsResponseModel> response = mapper.MapBOToModel(new List<BOSaleTickets>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8be864a4047620c2ee315009e0eda5d6</Hash>
</Codenesium>*/