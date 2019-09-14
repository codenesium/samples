using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiVPersonModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVPersonModelMapper();
			var model = new ApiVPersonClientRequestModel();
			model.SetProperties("A");
			ApiVPersonClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVPersonModelMapper();
			var model = new ApiVPersonClientResponseModel();
			model.SetProperties(1, "A");
			ApiVPersonClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.PersonName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>b1c3a514d3c24f1ee0cc27b5ddf68e40</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/