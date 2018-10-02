using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiTicketStatuModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTicketStatuModelMapper();
			var model = new ApiTicketStatuRequestModel();
			model.SetProperties("A");
			ApiTicketStatuResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTicketStatuModelMapper();
			var model = new ApiTicketStatuResponseModel();
			model.SetProperties(1, "A");
			ApiTicketStatuRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTicketStatuModelMapper();
			var model = new ApiTicketStatuRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTicketStatuRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTicketStatuRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>36b729a2f6602616662e162decb2d6a4</Hash>
</Codenesium>*/