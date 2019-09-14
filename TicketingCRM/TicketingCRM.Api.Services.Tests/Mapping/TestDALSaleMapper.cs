using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "DALMapper")]
	public class TestDALSaleMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSaleMapper();
			ApiSaleServerRequestModel model = new ApiSaleServerRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			Sale response = mapper.MapModelToEntity(1, model);

			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSaleMapper();
			Sale item = new Sale();
			item.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSaleMapper();
			Sale item = new Sale();
			item.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			List<ApiSaleServerResponseModel> response = mapper.MapEntityToModel(new List<Sale>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d5096c06abd9a60f7fa22b2e684c2646</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/