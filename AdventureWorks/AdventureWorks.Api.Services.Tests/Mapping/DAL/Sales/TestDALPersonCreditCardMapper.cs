using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PersonCreditCard")]
        [Trait("Area", "DALMapper")]
        public class TestDALPersonCreditCardMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPersonCreditCardMapper();
                        var bo = new BOPersonCreditCard();
                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        PersonCreditCard response = mapper.MapBOToEF(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.CreditCardID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPersonCreditCardMapper();
                        PersonCreditCard entity = new PersonCreditCard();
                        entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        BOPersonCreditCard response = mapper.MapEFToBO(entity);

                        response.BusinessEntityID.Should().Be(1);
                        response.CreditCardID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPersonCreditCardMapper();
                        PersonCreditCard entity = new PersonCreditCard();
                        entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        List<BOPersonCreditCard> response = mapper.MapEFToBO(new List<PersonCreditCard>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>4fe03a87a292480a553319adde310f81</Hash>
</Codenesium>*/