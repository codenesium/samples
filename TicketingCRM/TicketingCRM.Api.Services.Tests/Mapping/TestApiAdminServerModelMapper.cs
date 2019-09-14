using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "ApiModel")]
	public class TestApiAdminServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiAdminServerModelMapper();
			var model = new ApiAdminServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");
			ApiAdminServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiAdminServerModelMapper();
			var model = new ApiAdminServerResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A", "A");
			ApiAdminServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
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
			var mapper = new ApiAdminServerModelMapper();
			var model = new ApiAdminServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");

			JsonPatchDocument<ApiAdminServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiAdminServerRequestModel();
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
    <Hash>c3f79dc15134dd708e7a4d471ba79e30</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/