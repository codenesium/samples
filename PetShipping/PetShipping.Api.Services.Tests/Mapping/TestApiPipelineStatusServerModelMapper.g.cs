using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStatusServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPipelineStatusServerModelMapper();
			var model = new ApiPipelineStatusServerRequestModel();
			model.SetProperties("A");
			ApiPipelineStatusServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPipelineStatusServerModelMapper();
			var model = new ApiPipelineStatusServerResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStatusServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStatusServerModelMapper();
			var model = new ApiPipelineStatusServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPipelineStatusServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStatusServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e272b1623b71ce153d2e10a11e120688</Hash>
</Codenesium>*/