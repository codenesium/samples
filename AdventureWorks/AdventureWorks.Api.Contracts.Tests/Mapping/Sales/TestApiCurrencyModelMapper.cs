using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Currency")]
	[Trait("Area", "ApiModel")]
	public class TestApiCurrencyModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiCurrencyModelMapper();
			var model = new ApiCurrencyRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyResponseModel response = mapper.MapRequestToResponse("A", model);

			response.CurrencyCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiCurrencyModelMapper();
			var model = new ApiCurrencyResponseModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyRequestModel response = mapper.MapResponseToRequest(model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCurrencyModelMapper();
			var model = new ApiCurrencyRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiCurrencyRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCurrencyRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d4114f27a8433359e92abdfb53fadc1e</Hash>
</Codenesium>*/