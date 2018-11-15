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
	[Trait("Table", "Currency")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCurrencyMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCurrencyMapper();
			ApiCurrencyServerRequestModel model = new ApiCurrencyServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOCurrency response = mapper.MapModelToBO("A", model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCurrencyMapper();
			BOCurrency bo = new BOCurrency();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyServerResponseModel response = mapper.MapBOToModel(bo);

			response.CurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCurrencyMapper();
			BOCurrency bo = new BOCurrency();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiCurrencyServerResponseModel> response = mapper.MapBOToModel(new List<BOCurrency>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e8366df6e73ad43f8806fef0f5e74625</Hash>
</Codenesium>*/