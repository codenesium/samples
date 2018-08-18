using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Ticket")]
	[Trait("Area", "ApiModel")]
	public class TestApiTicketModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTicketModelMapper();
			var model = new ApiTicketRequestModel();
			model.SetProperties("A", 1);
			ApiTicketResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTicketModelMapper();
			var model = new ApiTicketResponseModel();
			model.SetProperties(1, "A", 1);
			ApiTicketRequestModel response = mapper.MapResponseToRequest(model);

			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTicketModelMapper();
			var model = new ApiTicketRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiTicketRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTicketRequestModel();
			patch.ApplyTo(response);
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>208c9bfd18b2b503b0057920f8d003ae</Hash>
</Codenesium>*/