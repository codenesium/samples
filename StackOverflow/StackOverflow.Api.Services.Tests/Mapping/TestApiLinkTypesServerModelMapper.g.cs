using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkTypesServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiLinkTypesServerModelMapper();
			var model = new ApiLinkTypesServerRequestModel();
			model.SetProperties("A");
			ApiLinkTypesServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiLinkTypesServerModelMapper();
			var model = new ApiLinkTypesServerResponseModel();
			model.SetProperties(1, "A");
			ApiLinkTypesServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLinkTypesServerModelMapper();
			var model = new ApiLinkTypesServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiLinkTypesServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLinkTypesServerRequestModel();
			patch.ApplyTo(response);
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ff60454eb72deb22f088fa687d931a22</Hash>
</Codenesium>*/