using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pipeline")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPipelineServerModelMapper();
			var model = new ApiPipelineServerRequestModel();
			model.SetProperties(1, 1);
			ApiPipelineServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPipelineServerModelMapper();
			var model = new ApiPipelineServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiPipelineServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPipelineServerModelMapper();
			var model = new ApiPipelineServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiPipelineServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPipelineServerRequestModel();
			patch.ApplyTo(response);
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3d754b61a37342a607be7f0059c95d6a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/