using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistory")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionHistoryServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTransactionHistoryServerModelMapper();
			var model = new ApiTransactionHistoryServerRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiTransactionHistoryServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ActualCost.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ReferenceOrderID.Should().Be(1);
			response.ReferenceOrderLineID.Should().Be(1);
			response.TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionType.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTransactionHistoryServerModelMapper();
			var model = new ApiTransactionHistoryServerResponseModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiTransactionHistoryServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ActualCost.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ReferenceOrderID.Should().Be(1);
			response.ReferenceOrderLineID.Should().Be(1);
			response.TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionType.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTransactionHistoryServerModelMapper();
			var model = new ApiTransactionHistoryServerRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiTransactionHistoryServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTransactionHistoryServerRequestModel();
			patch.ApplyTo(response);
			response.ActualCost.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ReferenceOrderID.Should().Be(1);
			response.ReferenceOrderLineID.Should().Be(1);
			response.TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>3cbde4dd037c3f0a3f01e351e100b905</Hash>
</Codenesium>*/