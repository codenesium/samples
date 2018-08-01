using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesOrderDetail")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesOrderDetailModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSalesOrderDetailModelMapper();
			var model = new ApiSalesOrderDetailRequestModel();
			model.SetProperties("A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1m);
			ApiSalesOrderDetailResponseModel response = mapper.MapRequestToResponse(1, model);

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
		public void MapResponseToRequest()
		{
			var mapper = new ApiSalesOrderDetailModelMapper();
			var model = new ApiSalesOrderDetailResponseModel();
			model.SetProperties(1, "A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1m);
			ApiSalesOrderDetailRequestModel response = mapper.MapResponseToRequest(model);

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
		public void CreatePatch()
		{
			var mapper = new ApiSalesOrderDetailModelMapper();
			var model = new ApiSalesOrderDetailRequestModel();
			model.SetProperties("A", 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1m);

			JsonPatchDocument<ApiSalesOrderDetailRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSalesOrderDetailRequestModel();
			patch.ApplyTo(response);
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
	}
}

/*<Codenesium>
    <Hash>b58d93c6c03800d92b6db831946d0ce6</Hash>
</Codenesium>*/