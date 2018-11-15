using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepStatuServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPipelineStepStatuServerModelMapper();
			var model = new ApiPipelineStepStatuServerRequestModel();
			model.SetProperties("A");
			ApiPipelineStepStatuServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPipelineStepStatuServerModelMapper();
			var model = new ApiPipelineStepStatuServerResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStepStatuServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepStatuServerModelMapper();
			var model = new ApiPipelineStepStatuServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPipelineStepStatuServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepStatuServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0e1b5facd9199ed7501d703b8f81aae2</Hash>
</Codenesium>*/