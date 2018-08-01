using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Destination")]
	[Trait("Area", "ApiModel")]
	public class TestApiDestinationModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiDestinationModelMapper();
			var model = new ApiDestinationRequestModel();
			model.SetProperties(1, "A", 1);
			ApiDestinationResponseModel response = mapper.MapRequestToResponse(1, model);

			response.CountryId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiDestinationModelMapper();
			var model = new ApiDestinationResponseModel();
			model.SetProperties(1, 1, "A", 1);
			ApiDestinationRequestModel response = mapper.MapResponseToRequest(model);

			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDestinationModelMapper();
			var model = new ApiDestinationRequestModel();
			model.SetProperties(1, "A", 1);

			JsonPatchDocument<ApiDestinationRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDestinationRequestModel();
			patch.ApplyTo(response);
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c6b2b1d8654bc03d83fd5df70c2f5983</Hash>
</Codenesium>*/