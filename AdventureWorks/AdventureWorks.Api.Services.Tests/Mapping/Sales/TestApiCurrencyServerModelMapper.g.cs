using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Currency")]
	[Trait("Area", "ApiModel")]
	public class TestApiCurrencyServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCurrencyServerModelMapper();
			var model = new ApiCurrencyServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyServerResponseModel response = mapper.MapServerRequestToResponse("A", model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCurrencyServerModelMapper();
			var model = new ApiCurrencyServerResponseModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCurrencyServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCurrencyServerModelMapper();
			var model = new ApiCurrencyServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiCurrencyServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCurrencyServerRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>6fd655507881e6503ac785c910fa6b73</Hash>
</Codenesium>*/