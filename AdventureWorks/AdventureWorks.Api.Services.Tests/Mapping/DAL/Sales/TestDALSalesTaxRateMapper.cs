using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "DALMapper")]
	public class TestDALSalesTaxRateMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSalesTaxRateMapper();
			var bo = new BOSalesTaxRate();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);

			SalesTaxRate response = mapper.MapBOToEF(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesTaxRateID.Should().Be(1);
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSalesTaxRateMapper();
			SalesTaxRate entity = new SalesTaxRate();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1);

			BOSalesTaxRate response = mapper.MapEFToBO(entity);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesTaxRateID.Should().Be(1);
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSalesTaxRateMapper();
			SalesTaxRate entity = new SalesTaxRate();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, 1m, 1);

			List<BOSalesTaxRate> response = mapper.MapEFToBO(new List<SalesTaxRate>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>394781b3a1a3c3b4b072fe8fc79707cb</Hash>
</Codenesium>*/