using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Handler")]
	[Trait("Area", "ApiModel")]
	public class TestApiHandlerModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiHandlerModelMapper();
			var model = new ApiHandlerRequestModel();
			model.SetProperties(1, "A", "A", "A", "A");
			ApiHandlerResponseModel response = mapper.MapRequestToResponse(1, model);

			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiHandlerModelMapper();
			var model = new ApiHandlerResponseModel();
			model.SetProperties(1, 1, "A", "A", "A", "A");
			ApiHandlerRequestModel response = mapper.MapResponseToRequest(model);

			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiHandlerModelMapper();
			var model = new ApiHandlerRequestModel();
			model.SetProperties(1, "A", "A", "A", "A");

			JsonPatchDocument<ApiHandlerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiHandlerRequestModel();
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
    <Hash>7c658ab46dcc6c108708dadafa6f983f</Hash>
</Codenesium>*/