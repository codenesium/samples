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
	[Trait("Table", "TransactionHistoryArchive")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTransactionHistoryArchiveMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTransactionHistoryArchiveMapper();
			ApiTransactionHistoryArchiveServerRequestModel model = new ApiTransactionHistoryArchiveServerRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOTransactionHistoryArchive response = mapper.MapModelToBO(1, model);

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
			var mapper = new BOLTransactionHistoryArchiveMapper();
			BOTransactionHistoryArchive bo = new BOTransactionHistoryArchive();
			bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiTransactionHistoryArchiveServerResponseModel response = mapper.MapBOToModel(bo);

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
			var mapper = new BOLTransactionHistoryArchiveMapper();
			BOTransactionHistoryArchive bo = new BOTransactionHistoryArchive();
			bo.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiTransactionHistoryArchiveServerResponseModel> response = mapper.MapBOToModel(new List<BOTransactionHistoryArchive>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3d04b255680b48fea4a277db0cd66da3</Hash>
</Codenesium>*/