using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventStatuServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiEventStatuServerModelMapper();
			var model = new ApiEventStatuServerRequestModel();
			model.SetProperties("A");
			ApiEventStatuServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEventStatuServerModelMapper();
			var model = new ApiEventStatuServerResponseModel();
			model.SetProperties(1, "A");
			ApiEventStatuServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventStatuServerModelMapper();
			var model = new ApiEventStatuServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiEventStatuServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventStatuServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0c690138dfa9daa4c9b1c37af2ad0f4c</Hash>
</Codenesium>*/