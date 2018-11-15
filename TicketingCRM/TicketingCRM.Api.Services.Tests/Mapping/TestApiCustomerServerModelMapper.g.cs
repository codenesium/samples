using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "ApiModel")]
	public class TestApiCustomerServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCustomerServerModelMapper();
			var model = new ApiCustomerServerRequestModel();
			model.SetProperties("A", "A", "A", "A");
			ApiCustomerServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCustomerServerModelMapper();
			var model = new ApiCustomerServerResponseModel();
			model.SetProperties(1, "A", "A", "A", "A");
			ApiCustomerServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCustomerServerModelMapper();
			var model = new ApiCustomerServerRequestModel();
			model.SetProperties("A", "A", "A", "A");

			JsonPatchDocument<ApiCustomerServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCustomerServerRequestModel();
			patch.ApplyTo(response);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>75587e58cb12b85d9283ea2278253c7f</Hash>
</Codenesium>*/