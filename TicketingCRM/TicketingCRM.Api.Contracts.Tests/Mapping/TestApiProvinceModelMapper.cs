using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Province")]
	[Trait("Area", "ApiModel")]
	public class TestApiProvinceModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiProvinceModelMapper();
			var model = new ApiProvinceRequestModel();
			model.SetProperties(1, "A");
			ApiProvinceResponseModel response = mapper.MapRequestToResponse(1, model);

			response.CountryId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiProvinceModelMapper();
			var model = new ApiProvinceResponseModel();
			model.SetProperties(1, 1, "A");
			ApiProvinceRequestModel response = mapper.MapResponseToRequest(model);

			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProvinceModelMapper();
			var model = new ApiProvinceRequestModel();
			model.SetProperties(1, "A");

			JsonPatchDocument<ApiProvinceRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProvinceRequestModel();
			patch.ApplyTo(response);
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>13cc7c462b865b04dcf2a9b0bd5faf03</Hash>
</Codenesium>*/