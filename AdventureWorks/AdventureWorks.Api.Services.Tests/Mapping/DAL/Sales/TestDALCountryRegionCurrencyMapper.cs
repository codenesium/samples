using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRegionCurrency")]
	[Trait("Area", "DALMapper")]
	public class TestDALCountryRegionCurrencyMapper
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

			BOCountryRegionCurrency response = mapper.MapEFToBO(entity);

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
    <Hash>4f07f715274dc5d8eeebb7b31e4faad8</Hash>
</Codenesium>*/