using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStatuModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPipelineStatuModelMapper();
			var model = new ApiPipelineStatuRequestModel();
			model.SetProperties("A");
			ApiPipelineStatuResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPipelineStatuModelMapper();
			var model = new ApiPipelineStatuResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStatuRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineStatuModelMapper();
			var model = new ApiPipelineStatuRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPipelineStatuRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineStatuRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>d69df870977770602ad7c419ea590191</Hash>
</Codenesium>*/