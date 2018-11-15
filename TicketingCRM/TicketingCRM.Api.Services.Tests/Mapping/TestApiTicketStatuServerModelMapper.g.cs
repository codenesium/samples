using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiTicketStatuServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTicketStatuServerModelMapper();
			var model = new ApiTicketStatuServerRequestModel();
			model.SetProperties("A");
			ApiTicketStatuServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTicketStatuServerModelMapper();
			var model = new ApiTicketStatuServerResponseModel();
			model.SetProperties(1, "A");
			ApiTicketStatuServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTicketStatuServerModelMapper();
			var model = new ApiTicketStatuServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTicketStatuServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTicketStatuServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>567f7767d4c434a43261fd46fd1e1665</Hash>
</Codenesium>*/