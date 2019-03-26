using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "ApiModel")]
	public class TestApiCurrencyRateModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCurrencyRateModelMapper();
			var model = new ApiCurrencyRateClientRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyRateClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AverageRate.Should().Be(1m);
			response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EndOfDayRate.Should().Be(1m);
			response.FromCurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCurrencyRateModelMapper();
			var model = new ApiCurrencyRateClientResponseModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyRateClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.AverageRate.Should().Be(1m);
			response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EndOfDayRate.Should().Be(1m);
			response.FromCurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ToCurrencyCode.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d5e51c04e6c543b2ada4f9ecec0db0e5</Hash>
</Codenesium>*/