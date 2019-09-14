using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSaleNS.Api.Services.Tests
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
    <Hash>4c224a38f5befa676edd85bcaa46cb6d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/