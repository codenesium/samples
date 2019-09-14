using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Unit")]
	[Trait("Area", "ApiModel")]
	public class TestApiUnitServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiUnitServerModelMapper();
			var model = new ApiUnitServerRequestModel();
			model.SetProperties("A");
			ApiUnitServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CallSign.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiUnitServerModelMapper();
			var model = new ApiUnitServerResponseModel();
			model.SetProperties(1, "A");
			ApiUnitServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CallSign.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiUnitServerModelMapper();
			var model = new ApiUnitServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiUnitServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiUnitServerRequestModel();
			patch.ApplyTo(response);
			response.CallSign.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ec52b63ffb25dc61ed82517efa9e01ad</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/