using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Country")]
	[Trait("Area", "ApiModel")]
	public class TestApiCountryModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCountryModelMapper();
			var model = new ApiCountryClientRequestModel();
			model.SetProperties("A");
			ApiCountryClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCountryModelMapper();
			var model = new ApiCountryClientResponseModel();
			model.SetProperties(1, "A");
			ApiCountryClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>eff22bba3b568596a87ec648258fdb99</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/