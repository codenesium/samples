using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Client")]
	[Trait("Area", "ApiModel")]
	public class TestApiClientServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiClientServerModelMapper();
			var model = new ApiClientServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiClientServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiClientServerModelMapper();
			var model = new ApiClientServerResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiClientServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiClientServerModelMapper();
			var model = new ApiClientServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");

			JsonPatchDocument<ApiClientServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiClientServerRequestModel();
			patch.ApplyTo(response);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5018f9ed15e3901e8825c40177333599</Hash>
</Codenesium>*/