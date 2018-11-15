using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepStatuModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPipelineStepStatuModelMapper();
			var model = new ApiPipelineStepStatuClientRequestModel();
			model.SetProperties("A");
			ApiPipelineStepStatuClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPipelineStepStatuModelMapper();
			var model = new ApiPipelineStepStatuClientResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStepStatuClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>1d4652f1b2b7b64be2dabbe597df703e</Hash>
</Codenesium>*/