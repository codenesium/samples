using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPersonServerModelMapper();
			var model = new ApiPersonServerRequestModel();
			model.SetProperties("A");
			ApiPersonServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPersonServerModelMapper();
			var model = new ApiPersonServerResponseModel();
			model.SetProperties(1, "A");
			ApiPersonServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPersonServerModelMapper();
			var model = new ApiPersonServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPersonServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPersonServerRequestModel();
			patch.ApplyTo(response);
			response.PersonName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>26347ef18a60b0d8d247f7ae21a6cbe4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/