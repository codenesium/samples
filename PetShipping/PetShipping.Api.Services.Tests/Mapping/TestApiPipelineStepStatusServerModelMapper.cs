using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepStatusServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPipelineStepStatusServerModelMapper();
			var model = new ApiPipelineStepStatusServerRequestModel();
			model.SetProperties("A");
			ApiPipelineStepStatusServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPipelineStepStatusServerModelMapper();
			var model = new ApiPipelineStepStatusServerResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStepStatusServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepStatusServerModelMapper();
			var model = new ApiPipelineStepStatusServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPipelineStepStatusServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepStatusServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>25e80af3a26dfdf08b3a70270dfaa2b7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/