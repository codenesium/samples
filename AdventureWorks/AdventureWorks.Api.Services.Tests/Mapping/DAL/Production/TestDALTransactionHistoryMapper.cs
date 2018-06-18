using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TransactionHistory")]
        [Trait("Area", "DALMapper")]
        public class TestDALTransactionHistoryActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALTransactionHistoryMapper();

                        var bo = new BOTransactionHistory();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        TransactionHistory response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALTransactionHistoryMapper();

                        TransactionHistory entity = new TransactionHistory();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

                        BOTransactionHistory  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALTransactionHistoryMapper();

                        TransactionHistory entity = new TransactionHistory();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

                        List<BOTransactionHistory> response = mapper.MapEFToBO(new List<TransactionHistory>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>619d59cc1b29265b598dfa01d6ea216a</Hash>
</Codenesium>*/