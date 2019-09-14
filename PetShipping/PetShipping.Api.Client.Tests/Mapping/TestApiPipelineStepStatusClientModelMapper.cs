using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStepStatusModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPipelineStepStatusModelMapper();
			var model = new ApiPipelineStepStatusClientRequestModel();
			model.SetProperties("A");
			ApiPipelineStepStatusClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPipelineStepStatusModelMapper();
			var model = new ApiPipelineStepStatusClientResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStepStatusClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>a95fe08483d568ae5ad7cbfed2579677</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/