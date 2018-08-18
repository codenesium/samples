using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductListPriceHistory")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductListPriceHistoryModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiProductListPriceHistoryModelMapper();
			var model = new ApiProductListPriceHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiProductListPriceHistoryResponseModel response = mapper.MapRequestToResponse(1, model);

			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ListPrice.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiProductListPriceHistoryModelMapper();
			var model = new ApiProductListPriceHistoryResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiProductListPriceHistoryRequestModel response = mapper.MapResponseToRequest(model);

			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ListPrice.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProductListPriceHistoryModelMapper();
			var model = new ApiProductListPriceHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));

			JsonPatchDocument<ApiProductListPriceHistoryRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductListPriceHistoryRequestModel();
			patch.ApplyTo(response);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ListPrice.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>b0265a0aee14e752236467807c20341e</Hash>
</Codenesium>*/