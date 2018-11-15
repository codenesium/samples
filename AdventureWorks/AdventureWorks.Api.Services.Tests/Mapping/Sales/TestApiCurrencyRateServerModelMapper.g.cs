using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "ApiModel")]
	public class TestApiCurrencyRateServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCurrencyRateServerModelMapper();
			var model = new ApiCurrencyRateServerRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyRateServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AverageRate.Should().Be(1m);
			response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EndOfDayRate.Should().Be(1m);
			response.FromCurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCurrencyRateServerModelMapper();
			var model = new ApiCurrencyRateServerResponseModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyRateServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.AverageRate.Should().Be(1m);
			response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EndOfDayRate.Should().Be(1m);
			response.FromCurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCurrencyRateServerModelMapper();
			var model = new ApiCurrencyRateServerRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiCurrencyRateServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCurrencyRateServerRequestModel();
			patch.ApplyTo(response);
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
    <Hash>8f3636de948e38bfa496f1afb0e9f67f</Hash>
</Codenesium>*/