using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Handler")]
	[Trait("Area", "ApiModel")]
	public class TestApiHandlerModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiHandlerModelMapper();
			var model = new ApiHandlerClientRequestModel();
			model.SetProperties(1, "A", "A", "A", "A");
			ApiHandlerClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiHandlerModelMapper();
			var model = new ApiHandlerClientResponseModel();
			model.SetProperties(1, 1, "A", "A", "A", "A");
			ApiHandlerClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>c517d04617446f04422368ddb203e42b</Hash>
</Codenesium>*/