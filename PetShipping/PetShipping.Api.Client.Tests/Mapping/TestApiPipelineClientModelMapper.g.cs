using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pipeline")]
	[Trait("Area", "ApiModel")]
	public class TestApiPipelineModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPipelineModelMapper();
			var model = new ApiPipelineClientRequestModel();
			model.SetProperties(1, 1);
			ApiPipelineClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPipelineModelMapper();
			var model = new ApiPipelineClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiPipelineClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.PipelineStatusId.Should().Be(1);
			response.SaleId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8ef635c99b00c856b53a62ec3e008b0c</Hash>
</Codenesium>*/