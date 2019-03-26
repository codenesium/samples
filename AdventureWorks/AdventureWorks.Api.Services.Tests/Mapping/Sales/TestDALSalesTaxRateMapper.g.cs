using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "DALMapper")]
	public class TestDALSalesTaxRateMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSalesTaxRateMapper();
			ApiSalesTaxRateServerRequestModel model = new ApiSalesTaxRateServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);
			SalesTaxRate response = mapper.MapModelToEntity(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSalesTaxRateMapper();
			SalesTaxRate item = new SalesTaxRate();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);
			ApiSalesTaxRateServerResponseModel response = mapper.MapEntityToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesTaxRateID.Should().Be(1);
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSalesTaxRateMapper();
			SalesTaxRate item = new SalesTaxRate();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);
			List<ApiSalesTaxRateServerResponseModel> response = mapper.MapEntityToModel(new List<SalesTaxRate>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>92d59f8f579e7ccd77b4916b5e9d6879</Hash>
</Codenesium>*/