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
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPurchaseOrderHeaderMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPurchaseOrderHeaderMapper();
			ApiPurchaseOrderHeaderServerRequestModel model = new ApiPurchaseOrderHeaderServerRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
			BOPurchaseOrderHeader response = mapper.MapModelToBO(1, model);

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
		public void MapBOToModel()
		{
			var mapper = new BOLPurchaseOrderHeaderMapper();
			BOPurchaseOrderHeader bo = new BOPurchaseOrderHeader();
			bo.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
			ApiPurchaseOrderHeaderServerResponseModel response = mapper.MapBOToModel(bo);

			response.EmployeeID.Should().Be(1);
			response.Freight.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OrderDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PurchaseOrderID.Should().Be(1);
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
		public void MapBOToModelList()
		{
			var mapper = new BOLPurchaseOrderHeaderMapper();
			BOPurchaseOrderHeader bo = new BOPurchaseOrderHeader();
			bo.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
			List<ApiPurchaseOrderHeaderServerResponseModel> response = mapper.MapBOToModel(new List<BOPurchaseOrderHeader>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0d09b9a3027d033a348fb2823dee021b</Hash>
</Codenesium>*/