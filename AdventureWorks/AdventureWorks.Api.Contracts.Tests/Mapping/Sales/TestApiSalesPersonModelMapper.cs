using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesPersonModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSalesPersonModelMapper();
			var model = new ApiSalesPersonRequestModel();
			model.SetProperties(1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
			ApiSalesPersonResponseModel response = mapper.MapRequestToResponse(1, model);

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
		public void MapResponseToRequest()
		{
			var mapper = new ApiSalesPersonModelMapper();
			var model = new ApiSalesPersonResponseModel();
			model.SetProperties(1, 1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
			ApiSalesPersonRequestModel response = mapper.MapResponseToRequest(model);

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
		public void CreatePatch()
		{
			var mapper = new ApiSalesPersonModelMapper();
			var model = new ApiSalesPersonRequestModel();
			model.SetProperties(1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);

			JsonPatchDocument<ApiSalesPersonRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSalesPersonRequestModel();
			patch.ApplyTo(response);
			response.Bonus.Should().Be(1m);
			response.CommissionPct.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesQuota.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
			response.TerritoryID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a07fc520dae1c5d1ffdf8e1c36a2286e</Hash>
</Codenesium>*/