using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CreditCard")]
	[Trait("Area", "ApiModel")]
	public class TestApiCreditCardModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCreditCardModelMapper();
			var model = new ApiCreditCardClientRequestModel();
			model.SetProperties("A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiCreditCardClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCreditCardModelMapper();
			var model = new ApiCreditCardClientResponseModel();
			model.SetProperties(1, "A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiCreditCardClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>285f3f6270966e0c6fd803fda75f16ed</Hash>
</Codenesium>*/