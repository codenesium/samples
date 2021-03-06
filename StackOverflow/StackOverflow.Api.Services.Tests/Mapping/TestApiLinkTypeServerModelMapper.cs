using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkType")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkTypeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiLinkTypeServerModelMapper();
			var model = new ApiLinkTypeServerRequestModel();
			model.SetProperties("A");
			ApiLinkTypeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiLinkTypeServerModelMapper();
			var model = new ApiLinkTypeServerResponseModel();
			model.SetProperties(1, "A");
			ApiLinkTypeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLinkTypeServerModelMapper();
			var model = new ApiLinkTypeServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiLinkTypeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLinkTypeServerRequestModel();
			patch.ApplyTo(response);
			response.RwType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5dcf7c34048da9cd185a3e3622ca4334</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/