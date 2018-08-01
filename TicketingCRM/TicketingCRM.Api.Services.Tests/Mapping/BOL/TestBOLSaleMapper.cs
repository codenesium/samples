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
	[Trait("Table", "Sale")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSaleMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSaleMapper();
			ApiSaleRequestModel model = new ApiSaleRequestModel();
			model.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			BOSale response = mapper.MapModelToBO(1, model);

			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSaleMapper();
			BOSale bo = new BOSale();
			bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiSaleResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.IpAddress.Should().Be("A");
			response.Notes.Should().Be("A");
			response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSaleMapper();
			BOSale bo = new BOSale();
			bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			List<ApiSaleResponseModel> response = mapper.MapBOToModel(new List<BOSale>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3582a0e2821814ec4b1fe44d4267ca32</Hash>
</Codenesium>*/