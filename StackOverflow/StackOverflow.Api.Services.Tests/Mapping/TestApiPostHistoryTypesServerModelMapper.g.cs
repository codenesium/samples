using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostHistoryTypesServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPostHistoryTypesServerModelMapper();
			var model = new ApiPostHistoryTypesServerRequestModel();
			model.SetProperties("A");
			ApiPostHistoryTypesServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPostHistoryTypesServerModelMapper();
			var model = new ApiPostHistoryTypesServerResponseModel();
			model.SetProperties(1, "A");
			ApiPostHistoryTypesServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostHistoryTypesServerModelMapper();
			var model = new ApiPostHistoryTypesServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPostHistoryTypesServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostHistoryTypesServerRequestModel();
			patch.ApplyTo(response);
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>596ce2dc7fa0bb8ae46e4b568daa8a29</Hash>
</Codenesium>*/