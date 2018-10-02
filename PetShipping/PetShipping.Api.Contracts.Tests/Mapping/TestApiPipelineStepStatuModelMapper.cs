using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepStatuModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPipelineStepStatuModelMapper();
			var model = new ApiPipelineStepStatuRequestModel();
			model.SetProperties("A");
			ApiPipelineStepStatuResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPipelineStepStatuModelMapper();
			var model = new ApiPipelineStepStatuResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStepStatuRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStepStatuModelMapper();
			var model = new ApiPipelineStepStatuRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPipelineStepStatuRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStepStatuRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f6d9dbc2cfa9b0b2101649742a7196df</Hash>
</Codenesium>*/