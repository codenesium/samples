using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesTerritoryServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSalesTerritoryServerModelMapper();
			var model = new ApiSalesTerritoryServerRequestModel();
			model.SetProperties("A", 1m, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiSalesTerritoryServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSalesTerritoryServerModelMapper();
			var model = new ApiSalesTerritoryServerResponseModel();
			model.SetProperties(1, "A", 1m, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiSalesTerritoryServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
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
		public void CreatePatch()
		{
			var mapper = new ApiSalesTerritoryServerModelMapper();
			var model = new ApiSalesTerritoryServerRequestModel();
			model.SetProperties("A", 1m, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);

			JsonPatchDocument<ApiSalesTerritoryServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSalesTerritoryServerRequestModel();
			patch.ApplyTo(response);
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
	}
}

/*<Codenesium>
    <Hash>47ea7eef5cc7ede8f013b6c012b850ff</Hash>
</Codenesium>*/