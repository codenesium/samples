using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Country")]
	[Trait("Area", "ApiModel")]
	public class TestApiCountryServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCountryServerModelMapper();
			var model = new ApiCountryServerRequestModel();
			model.SetProperties("A");
			ApiCountryServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCountryServerModelMapper();
			var model = new ApiCountryServerResponseModel();
			model.SetProperties(1, "A");
			ApiCountryServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCountryServerModelMapper();
			var model = new ApiCountryServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiCountryServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCountryServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>469d73e57669969ff9a748cde768f2a1</Hash>
</Codenesium>*/