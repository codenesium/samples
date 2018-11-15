using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkStatusServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiLinkStatusServerModelMapper();
			var model = new ApiLinkStatusServerRequestModel();
			model.SetProperties("A");
			ApiLinkStatusServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiLinkStatusServerModelMapper();
			var model = new ApiLinkStatusServerResponseModel();
			model.SetProperties(1, "A");
			ApiLinkStatusServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLinkStatusServerModelMapper();
			var model = new ApiLinkStatusServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiLinkStatusServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLinkStatusServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>df66ccca845750db6c78ab256c4f61d2</Hash>
</Codenesium>*/