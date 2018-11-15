using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Handler")]
	[Trait("Area", "ApiModel")]
	public class TestApiHandlerServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiHandlerServerModelMapper();
			var model = new ApiHandlerServerRequestModel();
			model.SetProperties(1, "A", "A", "A", "A");
			ApiHandlerServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiHandlerServerModelMapper();
			var model = new ApiHandlerServerResponseModel();
			model.SetProperties(1, 1, "A", "A", "A", "A");
			ApiHandlerServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiHandlerServerModelMapper();
			var model = new ApiHandlerServerRequestModel();
			model.SetProperties(1, "A", "A", "A", "A");

			JsonPatchDocument<ApiHandlerServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiHandlerServerRequestModel();
			patch.ApplyTo(response);
			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>25e5dc8d0335aa7999e18be1837bd57f</Hash>
</Codenesium>*/