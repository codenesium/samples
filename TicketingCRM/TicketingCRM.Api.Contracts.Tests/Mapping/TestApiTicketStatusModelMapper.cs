using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiTicketStatusModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTicketStatusModelMapper();
			var model = new ApiTicketStatusRequestModel();
			model.SetProperties("A");
			ApiTicketStatusResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTicketStatusModelMapper();
			var model = new ApiTicketStatusResponseModel();
			model.SetProperties(1, "A");
			ApiTicketStatusRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTicketStatusModelMapper();
			var model = new ApiTicketStatusRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTicketStatusRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTicketStatusRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f7fe9073fdc1febd5988c5bc8b311292</Hash>
</Codenesium>*/