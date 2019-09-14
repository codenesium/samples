using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OffCapability")]
	[Trait("Area", "ApiModel")]
	public class TestApiOffCapabilityServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiOffCapabilityServerModelMapper();
			var model = new ApiOffCapabilityServerRequestModel();
			model.SetProperties("A");
			ApiOffCapabilityServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiOffCapabilityServerModelMapper();
			var model = new ApiOffCapabilityServerResponseModel();
			model.SetProperties(1, "A");
			ApiOffCapabilityServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOffCapabilityServerModelMapper();
			var model = new ApiOffCapabilityServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiOffCapabilityServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOffCapabilityServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>850f0db0fa8c0aa68813879b48b4d73c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/