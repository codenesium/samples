using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostHistoryTypesModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPostHistoryTypesModelMapper();
			var model = new ApiPostHistoryTypesRequestModel();
			model.SetProperties("A");
			ApiPostHistoryTypesResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPostHistoryTypesModelMapper();
			var model = new ApiPostHistoryTypesResponseModel();
			model.SetProperties(1, "A");
			ApiPostHistoryTypesRequestModel response = mapper.MapResponseToRequest(model);

			response.Type.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostHistoryTypesModelMapper();
			var model = new ApiPostHistoryTypesRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPostHistoryTypesRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostHistoryTypesRequestModel();
			patch.ApplyTo(response);
			response.Type.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d5c6f5d59ccb5bf22263079b12847825</Hash>
</Codenesium>*/