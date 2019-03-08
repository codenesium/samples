using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostTypesServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPostTypesServerModelMapper();
			var model = new ApiPostTypesServerRequestModel();
			model.SetProperties("A");
			ApiPostTypesServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPostTypesServerModelMapper();
			var model = new ApiPostTypesServerResponseModel();
			model.SetProperties(1, "A");
			ApiPostTypesServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostTypesServerModelMapper();
			var model = new ApiPostTypesServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPostTypesServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostTypesServerRequestModel();
			patch.ApplyTo(response);
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>93ef1273cabde8b28c4edc15b50d7a1e</Hash>
</Codenesium>*/