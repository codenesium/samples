using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesPersonModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSalesPersonModelMapper();
			var model = new ApiSalesPersonClientRequestModel();
			model.SetProperties(1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
			ApiSalesPersonClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSalesPersonModelMapper();
			var model = new ApiSalesPersonClientResponseModel();
			model.SetProperties(1, 1m, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1m, 1m, 1);
			ApiSalesPersonClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
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
    <Hash>65eff216e2468b92aa6710b31fd0b08f</Hash>
</Codenesium>*/