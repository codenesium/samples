using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "ApiModel")]
	public class TestApiSelfReferenceModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiSelfReferenceModelMapper();
			var model = new ApiSelfReferenceClientRequestModel();
			model.SetProperties(1, 1);
			ApiSelfReferenceClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiSelfReferenceModelMapper();
			var model = new ApiSelfReferenceClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiSelfReferenceClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6934b62623da7b93a2ba4ca1b5821667</Hash>
</Codenesium>*/