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
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSalesTerritoryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSalesTerritoryMapper();
			ApiSalesTerritoryServerRequestModel model = new ApiSalesTerritoryServerRequestModel();
			model.SetProperties("A", 1m, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			BOSalesTerritory response = mapper.MapModelToBO(1, model);

			response.@Group.Should().Be("A");
			response.CostLastYear.Should().Be(1m);
			response.CostYTD.Should().Be(1m);
			response.CountryRegionCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSalesTerritoryMapper();
			BOSalesTerritory bo = new BOSalesTerritory();
			bo.SetProperties(1, "A", 1m, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiSalesTerritoryServerResponseModel response = mapper.MapBOToModel(bo);

			response.@Group.Should().Be("A");
			response.CostLastYear.Should().Be(1m);
			response.CostYTD.Should().Be(1m);
			response.CountryRegionCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSalesTerritoryMapper();
			BOSalesTerritory bo = new BOSalesTerritory();
			bo.SetProperties(1, "A", 1m, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			List<ApiSalesTerritoryServerResponseModel> response = mapper.MapBOToModel(new List<BOSalesTerritory>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>992fd2a850bd7ecd21d23995acc9a0ea</Hash>
</Codenesium>*/