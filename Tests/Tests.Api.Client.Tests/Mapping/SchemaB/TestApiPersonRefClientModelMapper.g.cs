using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonRef")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonRefModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPersonRefModelMapper();
			var model = new ApiPersonRefClientRequestModel();
			model.SetProperties(1, 1);
			ApiPersonRefClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPersonRefModelMapper();
			var model = new ApiPersonRefClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiPersonRefClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.PersonAId.Should().Be(1);
			response.PersonBId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2adf24690513de5aaeb27af51e7dec4b</Hash>
</Codenesium>*/