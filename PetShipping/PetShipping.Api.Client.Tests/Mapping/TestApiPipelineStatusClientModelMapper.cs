using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineStatusModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPipelineStatusModelMapper();
			var model = new ApiPipelineStatusClientRequestModel();
			model.SetProperties("A");
			ApiPipelineStatusClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPipelineStatusModelMapper();
			var model = new ApiPipelineStatusClientResponseModel();
			model.SetProperties(1, "A");
			ApiPipelineStatusClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>a2ffe7ccaa1a88632b945b6443dbec34</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/