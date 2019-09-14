using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallType")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallTypeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCallTypeServerModelMapper();
			var model = new ApiCallTypeServerRequestModel();
			model.SetProperties("A");
			ApiCallTypeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCallTypeServerModelMapper();
			var model = new ApiCallTypeServerResponseModel();
			model.SetProperties(1, "A");
			ApiCallTypeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCallTypeServerModelMapper();
			var model = new ApiCallTypeServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiCallTypeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCallTypeServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>cfb914045c8e0b907a251f9f4d24e084</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/