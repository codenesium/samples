using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesOrderDetail")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSalesOrderDetailMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSalesOrderDetailMapper();
			ApiSalesOrderDetailRequestModel model = new ApiSalesOrderDetailRequestModel();
			model.SetProperties("A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1m);
			BOSalesOrderDetail response = mapper.MapModelToBO(1, model);

			response.CarrierTrackingNumber.Should().Be("A");
			response.LineTotal.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesOrderDetailID.Should().Be(1);
			response.SpecialOfferID.Should().Be(1);
			response.UnitPrice.Should().Be(1m);
			response.UnitPriceDiscount.Should().Be(1m);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSalesOrderDetailMapper();
			BOSalesOrderDetail bo = new BOSalesOrderDetail();
			bo.SetProperties(1, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1m);
			ApiSalesOrderDetailResponseModel response = mapper.MapBOToModel(bo);

			response.CarrierTrackingNumber.Should().Be("A");
			response.LineTotal.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesOrderDetailID.Should().Be(1);
			response.SalesOrderID.Should().Be(1);
			response.SpecialOfferID.Should().Be(1);
			response.UnitPrice.Should().Be(1m);
			response.UnitPriceDiscount.Should().Be(1m);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSalesOrderDetailMapper();
			BOSalesOrderDetail bo = new BOSalesOrderDetail();
			bo.SetProperties(1, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1m);
			List<ApiSalesOrderDetailResponseModel> response = mapper.MapBOToModel(new List<BOSalesOrderDetail>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ce77dd2cf38d70a65e9df603ccccc6ba</Hash>
</Codenesium>*/