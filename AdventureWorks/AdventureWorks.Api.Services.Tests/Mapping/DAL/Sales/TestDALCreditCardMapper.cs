using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CreditCard")]
        [Trait("Area", "DALMapper")]
        public class TestDALCreditCardMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCreditCardMapper();
                        var bo = new BOCreditCard();
                        bo.SetProperties(1, "A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        CreditCard response = mapper.MapBOToEF(bo);

                        response.CardNumber.Should().Be("A");
                        response.CardType.Should().Be("A");
                        response.CreditCardID.Should().Be(1);
                        response.ExpMonth.Should().Be(1);
                        response.ExpYear.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCreditCardMapper();
                        CreditCard entity = new CreditCard();
                        entity.SetProperties("A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        BOCreditCard response = mapper.MapEFToBO(entity);

                        response.CardNumber.Should().Be("A");
                        response.CardType.Should().Be("A");
                        response.CreditCardID.Should().Be(1);
                        response.ExpMonth.Should().Be(1);
                        response.ExpYear.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCreditCardMapper();
                        CreditCard entity = new CreditCard();
                        entity.SetProperties("A", "A", 1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        List<BOCreditCard> response = mapper.MapEFToBO(new List<CreditCard>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a14aa39310f106cd304dfc3931aab885</Hash>
</Codenesium>*/