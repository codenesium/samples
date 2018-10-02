using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostHistoryTypeModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPostHistoryTypeModelMapper();
			var model = new ApiPostHistoryTypeRequestModel();
			model.SetProperties("A");
			ApiPostHistoryTypeResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPostHistoryTypeModelMapper();
			var model = new ApiPostHistoryTypeResponseModel();
			model.SetProperties(1, "A");
			ApiPostHistoryTypeRequestModel response = mapper.MapResponseToRequest(model);

			response.Type.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostHistoryTypeModelMapper();
			var model = new ApiPostHistoryTypeRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPostHistoryTypeRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostHistoryTypeRequestModel();
			patch.ApplyTo(response);
			response.Type.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>6e78d3405b62146451340cf7dba65205</Hash>
</Codenesium>*/