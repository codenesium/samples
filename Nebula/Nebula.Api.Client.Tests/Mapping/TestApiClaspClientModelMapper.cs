using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Clasp")]
	[Trait("Area", "ApiModel")]
	public class TestApiClaspModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiClaspModelMapper();
			var model = new ApiClaspClientRequestModel();
			model.SetProperties(1, 1);
			ApiClaspClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.NextChainId.Should().Be(1);
			response.PreviousChainId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiClaspModelMapper();
			var model = new ApiClaspClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiClaspClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.NextChainId.Should().Be(1);
			response.PreviousChainId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>05c5ab843ec946b9dbebe7fa258ffb0c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/