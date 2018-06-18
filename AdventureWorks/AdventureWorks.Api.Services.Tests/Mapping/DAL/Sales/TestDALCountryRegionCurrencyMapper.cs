using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRegionCurrency")]
        [Trait("Area", "DALMapper")]
        public class TestDALCountryRegionCurrencyActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCountryRegionCurrencyMapper();

                        var bo = new BOCountryRegionCurrency();

                        bo.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"));

                        CountryRegionCurrency response = mapper.MapBOToEF(bo);

                        response.CountryRegionCode.Should().Be("A");
                        response.CurrencyCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCountryRegionCurrencyMapper();

                        CountryRegionCurrency entity = new CountryRegionCurrency();

                        entity.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"));

                        BOCountryRegionCurrency  response = mapper.MapEFToBO(entity);

                        response.CountryRegionCode.Should().Be("A");
                        response.CurrencyCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCountryRegionCurrencyMapper();

                        CountryRegionCurrency entity = new CountryRegionCurrency();

                        entity.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"));

                        List<BOCountryRegionCurrency> response = mapper.MapEFToBO(new List<CountryRegionCurrency>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>62ae0ab6054efa6af625a29b60cdfe3a</Hash>
</Codenesium>*/