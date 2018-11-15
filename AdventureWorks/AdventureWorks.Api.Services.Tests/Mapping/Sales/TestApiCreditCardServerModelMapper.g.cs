using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CreditCard")]
	[Trait("Area", "ApiModel")]
	public class TestApiCreditCardServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCreditCardServerModelMapper();
			var model = new ApiCreditCardServerRequestModel();
			model.SetProperties("A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiCreditCardServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCreditCardServerModelMapper();
			var model = new ApiCreditCardServerResponseModel();
			model.SetProperties(1, "A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiCreditCardServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCreditCardServerModelMapper();
			var model = new ApiCreditCardServerRequestModel();
			model.SetProperties("A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

			JsonPatchDocument<ApiCreditCardServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCreditCardServerRequestModel();
			patch.ApplyTo(response);
			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>ec479810596cff5fa6c2c58ce039280c</Hash>
</Codenesium>*/