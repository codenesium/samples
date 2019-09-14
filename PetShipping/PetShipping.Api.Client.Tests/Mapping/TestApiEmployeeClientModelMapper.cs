using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Employee")]
	[Trait("Area", "ApiModel")]
	public class TestApiEmployeeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiEmployeeModelMapper();
			var model = new ApiEmployeeClientRequestModel();
			model.SetProperties("A", true, true, "A");
			ApiEmployeeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiEmployeeModelMapper();
			var model = new ApiEmployeeClientResponseModel();
			model.SetProperties(1, "A", true, true, "A");
			ApiEmployeeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>66d13e35c31c853642802708d2ee2137</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/