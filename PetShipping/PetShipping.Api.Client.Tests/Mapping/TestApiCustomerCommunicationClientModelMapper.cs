using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "ApiModel")]
	public class TestApiCustomerCommunicationModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCustomerCommunicationModelMapper();
			var model = new ApiCustomerCommunicationClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiCustomerCommunicationClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Notes.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCustomerCommunicationModelMapper();
			var model = new ApiCustomerCommunicationClientResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiCustomerCommunicationClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Notes.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>defcfc396cdc1f00f20f74d3130f4137</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/