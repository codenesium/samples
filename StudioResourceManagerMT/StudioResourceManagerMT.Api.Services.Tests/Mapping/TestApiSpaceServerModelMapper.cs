using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "ApiModel")]
	public class TestApiSpaceServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiSpaceServerModelMapper();
			var model = new ApiSpaceServerRequestModel();
			model.SetProperties("A", "A");
			ApiSpaceServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiSpaceServerModelMapper();
			var model = new ApiSpaceServerResponseModel();
			model.SetProperties(1, "A", "A");
			ApiSpaceServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSpaceServerModelMapper();
			var model = new ApiSpaceServerRequestModel();
			model.SetProperties("A", "A");

			JsonPatchDocument<ApiSpaceServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSpaceServerRequestModel();
			patch.ApplyTo(response);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>b86f695fafc23d16625fd5377df6b227</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/