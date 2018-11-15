using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Ticket")]
	[Trait("Area", "ApiModel")]
	public class TestApiTicketModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiTicketModelMapper();
			var model = new ApiTicketClientRequestModel();
			model.SetProperties("A", 1);
			ApiTicketClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiTicketModelMapper();
			var model = new ApiTicketClientResponseModel();
			model.SetProperties(1, "A", 1);
			ApiTicketClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8c0e1773851a93077c0e452fa8e92447</Hash>
</Codenesium>*/