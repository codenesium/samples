using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "City")]
	[Trait("Area", "ApiModel")]
	public class TestApiCityModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiCityModelMapper();
			var model = new ApiCityRequestModel();
			model.SetProperties("A", 1);
			ApiCityResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiCityModelMapper();
			var model = new ApiCityResponseModel();
			model.SetProperties(1, "A", 1);
			ApiCityRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCityModelMapper();
			var model = new ApiCityRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiCityRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCityRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e356e6da018e5b3968270371b72812f9</Hash>
</Codenesium>*/