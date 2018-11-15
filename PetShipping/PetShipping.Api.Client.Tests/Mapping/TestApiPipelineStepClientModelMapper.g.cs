using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPipelineStepModelMapper();
			var model = new ApiPipelineStepClientRequestModel();
			model.SetProperties("A", 1, 1);
			ApiPipelineStepClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPipelineStepModelMapper();
			var model = new ApiPipelineStepClientResponseModel();
			model.SetProperties(1, "A", 1, 1);
			ApiPipelineStepClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
			response.PipelineStepStatusId.Should().Be(1);
			response.ShipperId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4d817d56fc274e3e066909cccd3295c3</Hash>
</Codenesium>*/