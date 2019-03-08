using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "ApiModel")]
	public class TestApiVoteTypesModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVoteTypesModelMapper();
			var model = new ApiVoteTypesClientRequestModel();
			model.SetProperties("A");
			ApiVoteTypesClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVoteTypesModelMapper();
			var model = new ApiVoteTypesClientResponseModel();
			model.SetProperties(1, "A");
			ApiVoteTypesClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>f7a120421134d5a29373f9ae483d9a57</Hash>
</Codenesium>*/