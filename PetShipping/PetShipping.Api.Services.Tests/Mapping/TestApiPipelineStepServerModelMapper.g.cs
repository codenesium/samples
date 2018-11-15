using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPipelineStepServerModelMapper();
			var model = new ApiPipelineStepServerRequestModel();
			model.SetProperties("A", 1, 1);
			ApiPipelineStepServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPipelineStepServerModelMapper();
			var model = new ApiPipelineStepServerResponseModel();
			model.SetProperties(1, "A", 1, 1);
			ApiPipelineStepServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepServerModelMapper();
			var model = new ApiPipelineStepServerRequestModel();
			model.SetProperties("A", 1, 1);

			JsonPatchDocument<ApiPipelineStepServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e1bd6372221195b19c867fe9eea45c6c</Hash>
</Codenesium>*/