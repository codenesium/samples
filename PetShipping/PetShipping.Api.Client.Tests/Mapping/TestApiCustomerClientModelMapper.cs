using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "ApiModel")]
	public class TestApiCustomerModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCustomerModelMapper();
			var model = new ApiCustomerClientRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiCustomerClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Notes.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCustomerModelMapper();
			var model = new ApiCustomerClientResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiCustomerClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Notes.Should().Be("A");
			response.Phone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>a445f0b5c40e01b80639c34dcdcb9dda</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/