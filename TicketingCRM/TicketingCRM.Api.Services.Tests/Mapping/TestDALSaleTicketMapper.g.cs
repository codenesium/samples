using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "DALMapper")]
	public class TestDALSaleTicketMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSaleTicketMapper();
			ApiSaleTicketServerRequestModel model = new ApiSaleTicketServerRequestModel();
			model.SetProperties(1, 1);
			SaleTicket response = mapper.MapModelToEntity(1, model);

			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSaleTicketMapper();
			SaleTicket item = new SaleTicket();
			item.SetProperties(1, 1, 1);
			ApiSaleTicketServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.SaleId.Should().Be(1);
			response.TicketId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSaleTicketMapper();
			SaleTicket item = new SaleTicket();
			item.SetProperties(1, 1, 1);
			List<ApiSaleTicketServerResponseModel> response = mapper.MapEntityToModel(new List<SaleTicket>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>45f30baa9b855288772cfd3a8b14a2d8</Hash>
</Codenesium>*/