using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "City")]
	[Trait("Area", "ApiModel")]
	public class TestApiCityServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCityServerModelMapper();
			var model = new ApiCityServerRequestModel();
			model.SetProperties("A", 1);
			ApiCityServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCityServerModelMapper();
			var model = new ApiCityServerResponseModel();
			model.SetProperties(1, "A", 1);
			ApiCityServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCityServerModelMapper();
			var model = new ApiCityServerRequestModel();
			model.SetProperties("A", 1);

			JsonPatchDocument<ApiCityServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCityServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>55cdbd774629353365542c8f37fd2e01</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/