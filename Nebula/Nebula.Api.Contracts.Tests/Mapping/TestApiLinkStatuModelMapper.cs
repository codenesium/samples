using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkStatuModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiLinkStatuModelMapper();
			var model = new ApiLinkStatuRequestModel();
			model.SetProperties("A");
			ApiLinkStatuResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiLinkStatuModelMapper();
			var model = new ApiLinkStatuResponseModel();
			model.SetProperties(1, "A");
			ApiLinkStatuRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLinkStatuModelMapper();
			var model = new ApiLinkStatuRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiLinkStatuRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLinkStatuRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>27e6527a94cb479843b0346d4918398d</Hash>
</Codenesium>*/