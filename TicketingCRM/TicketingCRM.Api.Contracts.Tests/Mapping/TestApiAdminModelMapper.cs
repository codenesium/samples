using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "ApiModel")]
	public class TestApiAdminModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiAdminModelMapper();
			var model = new ApiAdminRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");
			ApiAdminResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiAdminModelMapper();
			var model = new ApiAdminResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A", "A");
			ApiAdminRequestModel response = mapper.MapResponseToRequest(model);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiAdminModelMapper();
			var model = new ApiAdminRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");

			JsonPatchDocument<ApiAdminRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiAdminRequestModel();
			patch.ApplyTo(response);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ba402b604cafb3ba75bbc91bca019f02</Hash>
</Codenesium>*/