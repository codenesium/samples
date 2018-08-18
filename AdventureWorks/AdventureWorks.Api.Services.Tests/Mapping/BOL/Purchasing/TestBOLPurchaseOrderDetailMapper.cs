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
	[Trait("Table", "PurchaseOrderDetail")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPurchaseOrderDetailMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPurchaseOrderDetailMapper();
			ApiPurchaseOrderDetailRequestModel model = new ApiPurchaseOrderDetailRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1m);
			BOPurchaseOrderDetail response = mapper.MapModelToBO(1, model);

			response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LineTotal.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.PurchaseOrderDetailID.Should().Be(1);
			response.ReceivedQty.Should().Be(1);
			response.RejectedQty.Should().Be(1);
			response.StockedQty.Should().Be(1);
			response.UnitPrice.Should().Be(1m);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPurchaseOrderDetailMapper();
			BOPurchaseOrderDetail bo = new BOPurchaseOrderDetail();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1m);
			ApiPurchaseOrderDetailResponseModel response = mapper.MapBOToModel(bo);

			response.DueDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LineTotal.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.PurchaseOrderDetailID.Should().Be(1);
			response.PurchaseOrderID.Should().Be(1);
			response.ReceivedQty.Should().Be(1);
			response.RejectedQty.Should().Be(1);
			response.StockedQty.Should().Be(1);
			response.UnitPrice.Should().Be(1m);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPurchaseOrderDetailMapper();
			BOPurchaseOrderDetail bo = new BOPurchaseOrderDetail();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, 1, 1, 1m);
			List<ApiPurchaseOrderDetailResponseModel> response = mapper.MapBOToModel(new List<BOPurchaseOrderDetail>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>793577f8002a39fa6cf5eb3a951e7773</Hash>
</Codenesium>*/