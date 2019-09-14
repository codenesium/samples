using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace TicketingCRMNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Province")]
	[Trait("Area", "ApiModel")]
	public class TestApiProvinceModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiProvinceModelMapper();
			var model = new ApiProvinceClientRequestModel();
			model.SetProperties(1, "A");
			ApiProvinceClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiProvinceModelMapper();
			var model = new ApiProvinceClientResponseModel();
			model.SetProperties(1, 1, "A");
			ApiProvinceClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>e963a9144760061e4ed01dc25681722e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/