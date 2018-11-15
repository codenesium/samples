using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiTicketStatuModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTicketStatuModelMapper();
			var model = new ApiTicketStatuClientRequestModel();
			model.SetProperties("A");
			ApiTicketStatuClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTicketStatuModelMapper();
			var model = new ApiTicketStatuClientResponseModel();
			model.SetProperties(1, "A");
			ApiTicketStatuClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>01f3efa9bcf291cfd9b3a77017425e35</Hash>
</Codenesium>*/