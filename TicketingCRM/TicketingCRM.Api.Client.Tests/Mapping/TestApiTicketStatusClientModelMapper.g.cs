using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiTicketStatusModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTicketStatusModelMapper();
			var model = new ApiTicketStatusClientRequestModel();
			model.SetProperties("A");
			ApiTicketStatusClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTicketStatusModelMapper();
			var model = new ApiTicketStatusClientResponseModel();
			model.SetProperties(1, "A");
			ApiTicketStatusClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5be345cb87157f8bd0008cfde610b5df</Hash>
</Codenesium>*/