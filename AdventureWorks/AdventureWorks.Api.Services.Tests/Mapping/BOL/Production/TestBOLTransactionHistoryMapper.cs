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
	[Trait("Table", "TransactionHistory")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTransactionHistoryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTransactionHistoryMapper();
			ApiTransactionHistoryServerRequestModel model = new ApiTransactionHistoryServerRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOTransactionHistory response = mapper.MapModelToBO(1, model);

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
		public void MapBOToModel()
		{
			var mapper = new BOLTransactionHistoryMapper();
			BOTransactionHistory bo = new BOTransactionHistory();
			bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiTransactionHistoryServerResponseModel response = mapper.MapBOToModel(bo);

			response.ActualCost.Should().Be(1m);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductID.Should().Be(1);
			response.Quantity.Should().Be(1);
			response.ReferenceOrderID.Should().Be(1);
			response.ReferenceOrderLineID.Should().Be(1);
			response.TransactionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.TransactionID.Should().Be(1);
			response.TransactionType.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTransactionHistoryMapper();
			BOTransactionHistory bo = new BOTransactionHistory();
			bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiTransactionHistoryServerResponseModel> response = mapper.MapBOToModel(new List<BOTransactionHistory>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e9a3272e51decca567d5262943ceb3bb</Hash>
</Codenesium>*/