using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionStatusModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTransactionStatusModelMapper();
			var model = new ApiTransactionStatusRequestModel();
			model.SetProperties("A");
			ApiTransactionStatusResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTransactionStatusModelMapper();
			var model = new ApiTransactionStatusResponseModel();
			model.SetProperties(1, "A");
			ApiTransactionStatusRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTransactionStatusModelMapper();
			var model = new ApiTransactionStatusRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTransactionStatusRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTransactionStatusRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>75d30ce96995d5d8f65d21adcb950739</Hash>
</Codenesium>*/