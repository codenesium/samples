using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TransactionHistoryArchive")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTransactionHistoryArchiveActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTransactionHistoryArchiveMapper();

                        ApiTransactionHistoryArchiveRequestModel model = new ApiTransactionHistoryArchiveRequestModel();

                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOTransactionHistoryArchive response = mapper.MapModelToBO(1, model);

                        response.ActualCost.Should().Be(1);
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

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiTransactionHistoryArchiveResponseModel response = mapper.MapBOToModel(bo);

                        response.ActualCost.Should().Be(1);
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

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiTransactionHistoryArchiveResponseModel> response = mapper.MapBOToModel(new List<BOTransactionHistoryArchive>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>7ad8a52f72b8455c237a6425c6043bf7</Hash>
</Codenesium>*/