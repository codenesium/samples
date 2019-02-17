using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionStatusModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTransactionStatusModelMapper();
			var model = new ApiTransactionStatusClientRequestModel();
			model.SetProperties("A");
			ApiTransactionStatusClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTransactionStatusModelMapper();
			var model = new ApiTransactionStatusClientResponseModel();
			model.SetProperties(1, "A");
			ApiTransactionStatusClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>bebee0698652351cb7c89686f48aeaee</Hash>
</Codenesium>*/