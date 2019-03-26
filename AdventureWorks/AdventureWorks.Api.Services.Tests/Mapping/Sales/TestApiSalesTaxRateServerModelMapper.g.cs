using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesTaxRateServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSalesTaxRateServerModelMapper();
			var model = new ApiSalesTaxRateServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);
			ApiSalesTaxRateServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSalesTaxRateServerModelMapper();
			var model = new ApiSalesTaxRateServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);
			ApiSalesTaxRateServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSalesTaxRateServerModelMapper();
			var model = new ApiSalesTaxRateServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1m, 1);

			JsonPatchDocument<ApiSalesTaxRateServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSalesTaxRateServerRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
			response.TaxRate.Should().Be(1m);
			response.TaxType.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e5ff4ef16088712e9da090d7ebd39366</Hash>
</Codenesium>*/