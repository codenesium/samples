using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "DALMapper")]
	public class TestDALSalesPersonMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSalesPersonMapper();
			ApiSalesPersonServerRequestModel model = new ApiSalesPersonServerRequestModel();
			model.SetProperties(1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
			SalesPerson response = mapper.MapModelToEntity(1, model);

			response.Bonus.Should().Be(1m);
			response.CommissionPct.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesQuota.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSalesPersonMapper();
			SalesPerson item = new SalesPerson();
			item.SetProperties(1, 1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
			ApiSalesPersonServerResponseModel response = mapper.MapEntityToModel(item);

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
		public void MapEntityToModelList()
		{
			var mapper = new DALSalesPersonMapper();
			SalesPerson item = new SalesPerson();
			item.SetProperties(1, 1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
			List<ApiSalesPersonServerResponseModel> response = mapper.MapEntityToModel(new List<SalesPerson>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>86eb346af336906b57affd600fd22057</Hash>
</Codenesium>*/