using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "ApiModel")]
	public class TestApiPurchaseOrderHeaderModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPurchaseOrderHeaderModelMapper();
			var model = new ApiPurchaseOrderHeaderClientRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
			ApiPurchaseOrderHeaderClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.EmployeeID.Should().Be(1);
			response.Freight.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RevisionNumber.Should().Be(1);
			response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ShipMethodID.Should().Be(1);
			response.Status.Should().Be(1);
			response.SubTotal.Should().Be(1m);
			response.TaxAmt.Should().Be(1m);
			response.TotalDue.Should().Be(1m);
			response.VendorID.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPurchaseOrderHeaderModelMapper();
			var model = new ApiPurchaseOrderHeaderClientResponseModel();
			model.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
			ApiPurchaseOrderHeaderClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.EmployeeID.Should().Be(1);
			response.Freight.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.RevisionNumber.Should().Be(1);
			response.ShipDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ShipMethodID.Should().Be(1);
			response.Status.Should().Be(1);
			response.SubTotal.Should().Be(1m);
			response.TaxAmt.Should().Be(1m);
			response.TotalDue.Should().Be(1m);
			response.VendorID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c0eb10a07f9ca7209a25df74b524e2a7</Hash>
</Codenesium>*/