using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Transaction")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTransactionServerModelMapper();
			var model = new ApiTransactionServerRequestModel();
			model.SetProperties(1m, "A", 1);
			ApiTransactionServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTransactionServerModelMapper();
			var model = new ApiTransactionServerResponseModel();
			model.SetProperties(1, 1m, "A", 1);
			ApiTransactionServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTransactionServerModelMapper();
			var model = new ApiTransactionServerRequestModel();
			model.SetProperties(1m, "A", 1);

			JsonPatchDocument<ApiTransactionServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTransactionServerRequestModel();
			patch.ApplyTo(response);
			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.TransactionStatusId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1504d23d8aa09ee7adb6d1accc1c6b30</Hash>
</Codenesium>*/