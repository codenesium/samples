using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "ApiModel")]
	public class TestApiCurrencyRateModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiCurrencyRateModelMapper();
			var model = new ApiCurrencyRateRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyRateResponseModel response = mapper.MapRequestToResponse(1, model);

			response.AverageRate.Should().Be(1m);
			response.CurrencyRateDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.CurrencyRateID.Should().Be(1);
			response.EndOfDayRate.Should().Be(1m);
			response.FromCurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ToCurrencyCode.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiCurrencyRateModelMapper();
			var model = new ApiCurrencyRateResponseModel();
			model.SetProperties(1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyRateRequestModel response = mapper.MapResponseToRequest(model);

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
			var mapper = new ApiCurrencyRateModelMapper();
			var model = new ApiCurrencyRateRequestModel();
			model.SetProperties(1m, DateTime.Parse("1/1/1987 12:00:00 AM"), 1m, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiCurrencyRateRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCurrencyRateRequestModel();
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
    <Hash>2350046e0efe5a80739e1089d159fa9a</Hash>
</Codenesium>*/