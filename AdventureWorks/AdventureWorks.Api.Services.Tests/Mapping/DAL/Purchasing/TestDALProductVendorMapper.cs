using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductVendor")]
	[Trait("Area", "DALMapper")]
	public class TestDALProductVendorMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProductVendorMapper();
			var bo = new BOProductVendor();
			bo.SetProperties(1, 1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, "A");

			ProductVendor response = mapper.MapBOToEF(bo);

			response.AverageLeadTime.Should().Be(1);
			response.BusinessEntityID.Should().Be(1);
			response.LastReceiptCost.Should().Be(1m);
			response.LastReceiptDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxOrderQty.Should().Be(1);
			response.MinOrderQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OnOrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.StandardPrice.Should().Be(1m);
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALProductVendorMapper();
			ProductVendor entity = new ProductVendor();
			entity.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, "A");

			BOProductVendor response = mapper.MapEFToBO(entity);

			response.AverageLeadTime.Should().Be(1);
			response.BusinessEntityID.Should().Be(1);
			response.LastReceiptCost.Should().Be(1m);
			response.LastReceiptDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.MaxOrderQty.Should().Be(1);
			response.MinOrderQty.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.OnOrderQty.Should().Be(1);
			response.ProductID.Should().Be(1);
			response.StandardPrice.Should().Be(1m);
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALProductVendorMapper();
			ProductVendor entity = new ProductVendor();
			entity.SetProperties(1, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1m, "A");

			List<BOProductVendor> response = mapper.MapEFToBO(new List<ProductVendor>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5dc46964fe681ec74813e6bd73253c8f</Hash>
</Codenesium>*/