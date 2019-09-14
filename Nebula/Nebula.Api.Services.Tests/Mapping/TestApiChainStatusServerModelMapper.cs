using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiChainStatusServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiChainStatusServerModelMapper();
			var model = new ApiChainStatusServerRequestModel();
			model.SetProperties("A");
			ApiChainStatusServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiChainStatusServerModelMapper();
			var model = new ApiChainStatusServerResponseModel();
			model.SetProperties(1, "A");
			ApiChainStatusServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiChainStatusServerModelMapper();
			var model = new ApiChainStatusServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiChainStatusServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiChainStatusServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f6d2ba0f4bd543c9d583d2fe8c3d3584</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/