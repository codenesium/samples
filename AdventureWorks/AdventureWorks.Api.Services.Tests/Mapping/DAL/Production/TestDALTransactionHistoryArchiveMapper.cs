using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TransactionHistoryArchive")]
        [Trait("Area", "DALMapper")]
        public class TestDALTransactionHistoryArchiveActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALTransactionHistoryArchiveMapper();

                        var bo = new BOTransactionHistoryArchive();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        TransactionHistoryArchive response = mapper.MapBOToEF(bo);

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
                        var mapper = new DALTransactionHistoryArchiveMapper();

                        TransactionHistoryArchive entity = new TransactionHistoryArchive();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

                        BOTransactionHistoryArchive  response = mapper.MapEFToBO(entity);

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
                        var mapper = new DALTransactionHistoryArchiveMapper();

                        TransactionHistoryArchive entity = new TransactionHistoryArchive();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

                        List<BOTransactionHistoryArchive> response = mapper.MapEFToBO(new List<TransactionHistoryArchive>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>fba83c1b15e2dec67f41a5e7874de2be</Hash>
</Codenesium>*/