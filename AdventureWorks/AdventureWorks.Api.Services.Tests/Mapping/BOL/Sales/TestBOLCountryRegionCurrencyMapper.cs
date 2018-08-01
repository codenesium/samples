using AdventureWorksNS.Api.Contracts;
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
	[Trait("Area", "BOLMapper")]
	public class TestBOLCountryRegionCurrencyMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCountryRegionCurrencyMapper();
			ApiCountryRegionCurrencyRequestModel model = new ApiCountryRegionCurrencyRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			BOCountryRegionCurrency response = mapper.MapModelToBO("A", model);

			response.CurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCountryRegionCurrencyMapper();
			BOCountryRegionCurrency bo = new BOCountryRegionCurrency();
			bo.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiCountryRegionCurrencyResponseModel response = mapper.MapBOToModel(bo);

			response.CountryRegionCode.Should().Be("A");
			response.CurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCountryRegionCurrencyMapper();
			BOCountryRegionCurrency bo = new BOCountryRegionCurrency();
			bo.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiCountryRegionCurrencyResponseModel> response = mapper.MapBOToModel(new List<BOCountryRegionCurrency>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>46f55cc56af62e27169be1ab52f9e02c</Hash>
</Codenesium>*/