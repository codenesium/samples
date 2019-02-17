using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionStatusServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTransactionStatusServerModelMapper();
			var model = new ApiTransactionStatusServerRequestModel();
			model.SetProperties("A");
			ApiTransactionStatusServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTransactionStatusServerModelMapper();
			var model = new ApiTransactionStatusServerResponseModel();
			model.SetProperties(1, "A");
			ApiTransactionStatusServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTransactionStatusServerModelMapper();
			var model = new ApiTransactionStatusServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTransactionStatusServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTransactionStatusServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>bb7c156089db179d125baa59a2825742</Hash>
</Codenesium>*/