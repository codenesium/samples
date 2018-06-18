using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Currency")]
        [Trait("Area", "DALMapper")]
        public class TestDALCurrencyActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCurrencyMapper();

                        var bo = new BOCurrency();

                        bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        Currency response = mapper.MapBOToEF(bo);

                        response.CurrencyCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCurrencyMapper();

                        Currency entity = new Currency();

                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOCurrency  response = mapper.MapEFToBO(entity);

                        response.CurrencyCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCurrencyMapper();

                        Currency entity = new Currency();

                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOCurrency> response = mapper.MapEFToBO(new List<Currency>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>94c6a42096b8773451a93c97d5b1e713</Hash>
</Codenesium>*/