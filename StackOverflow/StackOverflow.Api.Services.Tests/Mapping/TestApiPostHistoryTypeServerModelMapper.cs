using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPostHistoryTypeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPostHistoryTypeServerModelMapper();
			var model = new ApiPostHistoryTypeServerRequestModel();
			model.SetProperties("A");
			ApiPostHistoryTypeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPostHistoryTypeServerModelMapper();
			var model = new ApiPostHistoryTypeServerResponseModel();
			model.SetProperties(1, "A");
			ApiPostHistoryTypeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPostHistoryTypeServerModelMapper();
			var model = new ApiPostHistoryTypeServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPostHistoryTypeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPostHistoryTypeServerRequestModel();
			patch.ApplyTo(response);
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ea45274cbe4ec4847a921edbe56b719b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/