using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "DALMapper")]
	public class TestDALTransactionHistoryArchiveMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALTransactionHistoryArchiveMapper();
			ApiTransactionHistoryArchiveServerRequestModel model = new ApiTransactionHistoryArchiveServerRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			TransactionHistoryArchive response = mapper.MapModelToBO(1, model);

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
			var mapper = new DALTransactionHistoryArchiveMapper();
			TransactionHistoryArchive item = new TransactionHistoryArchive();
			item.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiTransactionHistoryArchiveServerResponseModel response = mapper.MapBOToModel(item);

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
			var mapper = new DALTransactionHistoryArchiveMapper();
			TransactionHistoryArchive item = new TransactionHistoryArchive();
			item.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiTransactionHistoryArchiveServerResponseModel> response = mapper.MapBOToModel(new List<TransactionHistoryArchive>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1bd9b9cec4b6ef0d63b8df814983ee52</Hash>
</Codenesium>*/