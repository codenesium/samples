using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionStatuServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTransactionStatuServerModelMapper();
			var model = new ApiTransactionStatuServerRequestModel();
			model.SetProperties("A");
			ApiTransactionStatuServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTransactionStatuServerModelMapper();
			var model = new ApiTransactionStatuServerResponseModel();
			model.SetProperties(1, "A");
			ApiTransactionStatuServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTransactionStatuServerModelMapper();
			var model = new ApiTransactionStatuServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTransactionStatuServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTransactionStatuServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>07b5db09972b18467d121a0cf9b24bf0</Hash>
</Codenesium>*/