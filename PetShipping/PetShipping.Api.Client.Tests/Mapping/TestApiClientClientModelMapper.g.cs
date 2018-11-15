using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Client")]
	[Trait("Area", "ApiModel")]
	public class TestApiClientModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiClientModelMapper();
			var model = new ApiClientClientRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiClientClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiClientModelMapper();
			var model = new ApiClientClientResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiClientClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>7ab4b817af69f4bbb6d68a9b198b11ce</Hash>
</Codenesium>*/