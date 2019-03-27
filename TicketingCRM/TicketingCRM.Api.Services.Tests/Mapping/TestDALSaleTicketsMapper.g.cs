using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "DALMapper")]
	public class TestDALSaleTicketsMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSaleTicketsMapper();
			ApiSaleTicketsServerRequestModel model = new ApiSaleTicketsServerRequestModel();
			model.SetProperties(1, 1);
			SaleTickets response = mapper.MapModelToEntity(1, model);

			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSaleTicketsMapper();
			SaleTickets item = new SaleTickets();
			item.SetProperties(1, 1, 1);
			ApiSaleTicketsServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSaleTicketsMapper();
			SaleTickets item = new SaleTickets();
			item.SetProperties(1, 1, 1);
			List<ApiSaleTicketsServerResponseModel> response = mapper.MapEntityToModel(new List<SaleTickets>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e8d5588c00b921d66924836e56efbc6b</Hash>
</Codenesium>*/