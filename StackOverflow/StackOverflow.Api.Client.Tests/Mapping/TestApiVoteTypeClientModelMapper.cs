using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteType")]
	[Trait("Area", "ApiModel")]
	public class TestApiVoteTypeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVoteTypeModelMapper();
			var model = new ApiVoteTypeClientRequestModel();
			model.SetProperties("A");
			ApiVoteTypeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVoteTypeModelMapper();
			var model = new ApiVoteTypeClientResponseModel();
			model.SetProperties(1, "A");
			ApiVoteTypeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>cc7836267495607cc0e1260a06fb7841</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/