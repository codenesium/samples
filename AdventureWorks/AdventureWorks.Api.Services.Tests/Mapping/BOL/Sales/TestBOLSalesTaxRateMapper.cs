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
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSalesTaxRateMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSalesTaxRateMapper();
			ApiSalesTaxRateServerRequestModel model = new ApiSalesTaxRateServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);
			BOSalesTaxRate response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSalesTaxRateMapper();
			BOSalesTaxRate bo = new BOSalesTaxRate();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);
			ApiSalesTaxRateServerResponseModel response = mapper.MapBOToModel(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesTaxRateID.Should().Be(1);
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSalesTaxRateMapper();
			BOSalesTaxRate bo = new BOSalesTaxRate();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);
			List<ApiSalesTaxRateServerResponseModel> response = mapper.MapBOToModel(new List<BOSalesTaxRate>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>237724f9e83756794ab30562357af26e</Hash>
</Codenesium>*/