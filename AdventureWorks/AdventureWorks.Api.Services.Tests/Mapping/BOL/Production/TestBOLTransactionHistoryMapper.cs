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
        [Trait("Table", "TransactionHistory")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTransactionHistoryActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTransactionHistoryMapper();

                        ApiTransactionHistoryRequestModel model = new ApiTransactionHistoryRequestModel();

                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOTransactionHistory response = mapper.MapModelToBO(1, model);

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
                        var mapper = new BOLTransactionHistoryMapper();

                        BOTransactionHistory bo = new BOTransactionHistory();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiTransactionHistoryResponseModel response = mapper.MapBOToModel(bo);

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
                        var mapper = new BOLTransactionHistoryMapper();

                        BOTransactionHistory bo = new BOTransactionHistory();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiTransactionHistoryResponseModel> response = mapper.MapBOToModel(new List<BOTransactionHistory>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>37f3e2fab65eb43fd9ca0b02eaae5ebe</Hash>
</Codenesium>*/