using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStatuModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPipelineStatuModelMapper();
			var model = new ApiPipelineStatuClientRequestModel();
			model.SetProperties("A");
			ApiPipelineStatuClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPipelineStatuModelMapper();
			var model = new ApiPipelineStatuClientResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStatuClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>a7ccfa1bef8515a0e5d5b4c276142c82</Hash>
</Codenesium>*/