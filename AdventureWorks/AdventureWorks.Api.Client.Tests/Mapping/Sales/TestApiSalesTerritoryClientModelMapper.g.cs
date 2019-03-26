using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTerritory")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesTerritoryModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSalesTerritoryModelMapper();
			var model = new ApiSalesTerritoryClientRequestModel();
			model.SetProperties(1m, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiSalesTerritoryClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CostLastYear.Should().Be(1m);
			response.CostYTD.Should().Be(1m);
			response.CountryRegionCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReservedGroup.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSalesTerritoryModelMapper();
			var model = new ApiSalesTerritoryClientResponseModel();
			model.SetProperties(1, 1m, 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m);
			ApiSalesTerritoryClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CostLastYear.Should().Be(1m);
			response.CostYTD.Should().Be(1m);
			response.CountryRegionCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReservedGroup.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesLastYear.Should().Be(1m);
			response.SalesYTD.Should().Be(1m);
		}
	}
}

/*<Codenesium>
    <Hash>bee267459de96acc482df341860d904b</Hash>
</Codenesium>*/