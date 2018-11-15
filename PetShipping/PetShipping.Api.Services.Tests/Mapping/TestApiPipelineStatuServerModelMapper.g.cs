using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStatuServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPipelineStatuServerModelMapper();
			var model = new ApiPipelineStatuServerRequestModel();
			model.SetProperties("A");
			ApiPipelineStatuServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPipelineStatuServerModelMapper();
			var model = new ApiPipelineStatuServerResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStatuServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStatuServerModelMapper();
			var model = new ApiPipelineStatuServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPipelineStatuServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStatuServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f41ebae5d0b9b59e743eb18562e4234b</Hash>
</Codenesium>*/