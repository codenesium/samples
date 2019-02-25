using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Currency")]
	[Trait("Area", "DALMapper")]
	public class TestDALCurrencyMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCurrencyMapper();
			ApiCurrencyServerRequestModel model = new ApiCurrencyServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			Currency response = mapper.MapModelToEntity("A", model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCurrencyMapper();
			Currency item = new Currency();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyServerResponseModel response = mapper.MapEntityToModel(item);

			response.CurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCurrencyMapper();
			Currency item = new Currency();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiCurrencyServerResponseModel> response = mapper.MapEntityToModel(new List<Currency>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>506a274a384a23baee391fa9c7a72153</Hash>
</Codenesium>*/