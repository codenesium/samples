using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TransactionStatus")]
        [Trait("Area", "DALMapper")]
        public class TestDALTransactionStatusActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALTransactionStatusMapper();

                        var bo = new BOTransactionStatus();

                        bo.SetProperties(1, "A");

                        TransactionStatus response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALTransactionStatusMapper();

                        TransactionStatus entity = new TransactionStatus();

                        entity.SetProperties(1, "A");

                        BOTransactionStatus  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALTransactionStatusMapper();

                        TransactionStatus entity = new TransactionStatus();

                        entity.SetProperties(1, "A");

                        List<BOTransactionStatus> response = mapper.MapEFToBO(new List<TransactionStatus>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>77d8f4ac491ef1dcdc9dfb32fc290e0e</Hash>
</Codenesium>*/