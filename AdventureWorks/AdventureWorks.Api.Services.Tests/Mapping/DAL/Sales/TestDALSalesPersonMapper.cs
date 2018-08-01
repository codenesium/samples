using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "DALMapper")]
	public class TestDALSalesPersonMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSalesPersonMapper();
			var bo = new BOSalesPerson();
			bo.SetProperties(1, 1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);

			SalesPerson response = mapper.MapBOToEF(bo);

			response.Bonus.Should().Be(1m);
			response.BusinessEntityID.Should().Be(1);
			response.CommissionPct.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesQuota.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSalesPersonMapper();
			SalesPerson entity = new SalesPerson();
			entity.SetProperties(1m, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);

			BOSalesPerson response = mapper.MapEFToBO(entity);

			response.Bonus.Should().Be(1m);
			response.BusinessEntityID.Should().Be(1);
			response.CommissionPct.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesQuota.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSalesPersonMapper();
			SalesPerson entity = new SalesPerson();
			entity.SetProperties(1m, 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);

			List<BOSalesPerson> response = mapper.MapEFToBO(new List<SalesPerson>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2b27926949cdbc72b86c27d325520c13</Hash>
</Codenesium>*/