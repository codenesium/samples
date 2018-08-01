using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Transaction")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTransactionModelMapper();
			var model = new ApiTransactionRequestModel();
			model.SetProperties(1m, "A", 1);
			ApiTransactionResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.Id.Should().Be(1);
			response.TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTransactionModelMapper();
			var model = new ApiTransactionResponseModel();
			model.SetProperties(1, 1m, "A", 1);
			ApiTransactionRequestModel response = mapper.MapResponseToRequest(model);

			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTransactionModelMapper();
			var model = new ApiTransactionRequestModel();
			model.SetProperties(1m, "A", 1);

			JsonPatchDocument<ApiTransactionRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTransactionRequestModel();
			patch.ApplyTo(response);
			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.TransactionStatusId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ccaacd60e5230638637252e9b369a351</Hash>
</Codenesium>*/