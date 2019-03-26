using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionHistoryArchiveModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTransactionHistoryArchiveModelMapper();
			var model = new ApiTransactionHistoryArchiveClientRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiTransactionHistoryArchiveClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTransactionHistoryArchiveModelMapper();
			var model = new ApiTransactionHistoryArchiveClientResponseModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiTransactionHistoryArchiveClientRequestModel response = mapper.MapClientResponseToRequest(model);
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
	}
}

/*<Codenesium>
    <Hash>e2b76f67696a7dea28be1070a789d004</Hash>
</Codenesium>*/