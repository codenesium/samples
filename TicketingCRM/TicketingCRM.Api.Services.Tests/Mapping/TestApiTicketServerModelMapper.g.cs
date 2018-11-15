using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Ticket")]
	[Trait("Area", "ApiModel")]
	public class TestApiTicketServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTicketServerModelMapper();
			var model = new ApiTicketServerRequestModel();
			model.SetProperties("A", 1);
			ApiTicketServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTicketServerModelMapper();
			var model = new ApiTicketServerResponseModel();
			model.SetProperties(1, "A", 1);
			ApiTicketServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTicketServerModelMapper();
			var model = new ApiTicketServerRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiTicketServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTicketServerRequestModel();
			patch.ApplyTo(response);
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1b17a31481d29cdeaca18ecad8fdaa94</Hash>
</Codenesium>*/