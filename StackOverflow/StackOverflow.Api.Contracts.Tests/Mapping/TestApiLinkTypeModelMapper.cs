using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkType")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkTypeModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLinkTypeModelMapper();
			var model = new ApiLinkTypeRequestModel();
			model.SetProperties("A");
			ApiLinkTypeResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLinkTypeModelMapper();
			var model = new ApiLinkTypeResponseModel();
			model.SetProperties(1, "A");
			ApiLinkTypeRequestModel response = mapper.MapResponseToRequest(model);

			response.Type.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLinkTypeModelMapper();
			var model = new ApiLinkTypeRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiLinkTypeRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLinkTypeRequestModel();
			patch.ApplyTo(response);
			response.Type.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>8bfd8219cf70707bb774a9bcaad54c47</Hash>
</Codenesium>*/