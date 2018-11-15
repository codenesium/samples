using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionStatuModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTransactionStatuModelMapper();
			var model = new ApiTransactionStatuClientRequestModel();
			model.SetProperties("A");
			ApiTransactionStatuClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTransactionStatuModelMapper();
			var model = new ApiTransactionStatuClientResponseModel();
			model.SetProperties(1, "A");
			ApiTransactionStatuClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>3a17d591f886102137a64adb4eef4ec7</Hash>
</Codenesium>*/