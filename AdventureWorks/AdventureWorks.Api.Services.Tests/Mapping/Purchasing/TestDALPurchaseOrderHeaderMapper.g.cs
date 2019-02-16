using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PurchaseOrderHeader")]
	[Trait("Area", "DALMapper")]
	public class TestDALPurchaseOrderHeaderMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALPurchaseOrderHeaderMapper();
			ApiPurchaseOrderHeaderServerRequestModel model = new ApiPurchaseOrderHeaderServerRequestModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
			PurchaseOrderHeader response = mapper.MapModelToBO(1, model);

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
			var mapper = new DALPurchaseOrderHeaderMapper();
			PurchaseOrderHeader item = new PurchaseOrderHeader();
			item.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
			ApiPurchaseOrderHeaderServerResponseModel response = mapper.MapBOToModel(item);

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
			var mapper = new DALPurchaseOrderHeaderMapper();
			PurchaseOrderHeader item = new PurchaseOrderHeader();
			item.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, 1m, 1m, 1);
			List<ApiPurchaseOrderHeaderServerResponseModel> response = mapper.MapBOToModel(new List<PurchaseOrderHeader>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1d6dcbd7afde7754c16bc979ef4bd733</Hash>
</Codenesium>*/