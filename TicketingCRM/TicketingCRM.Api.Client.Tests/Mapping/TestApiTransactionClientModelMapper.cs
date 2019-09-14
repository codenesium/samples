using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Transaction")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTransactionModelMapper();
			var model = new ApiTransactionClientRequestModel();
			model.SetProperties(1m, "A", 1);
			ApiTransactionClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTransactionModelMapper();
			var model = new ApiTransactionClientResponseModel();
			model.SetProperties(1, 1m, "A", 1);
			ApiTransactionClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.TransactionStatusId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>73180891800cbe57daf435181e0c539d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/