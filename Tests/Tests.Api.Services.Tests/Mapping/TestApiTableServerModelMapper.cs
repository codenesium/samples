using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Table")]
	[Trait("Area", "ApiModel")]
	public class TestApiTableServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiTableServerModelMapper();
			var model = new ApiTableServerRequestModel();
			model.SetProperties("A");
			ApiTableServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiTableServerModelMapper();
			var model = new ApiTableServerResponseModel();
			model.SetProperties(1, "A");
			ApiTableServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTableServerModelMapper();
			var model = new ApiTableServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTableServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTableServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>bec25b6a0f523ad97328c250768eed1b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/