using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiTicketStatusServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTicketStatusServerModelMapper();
			var model = new ApiTicketStatusServerRequestModel();
			model.SetProperties("A");
			ApiTicketStatusServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTicketStatusServerModelMapper();
			var model = new ApiTicketStatusServerResponseModel();
			model.SetProperties(1, "A");
			ApiTicketStatusServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTicketStatusServerModelMapper();
			var model = new ApiTicketStatusServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTicketStatusServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTicketStatusServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>8ea90bd56a4444207a071d98b0059cff</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/