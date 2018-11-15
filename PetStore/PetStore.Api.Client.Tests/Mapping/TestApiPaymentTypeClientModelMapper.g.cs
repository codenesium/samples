using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPaymentTypeModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPaymentTypeModelMapper();
			var model = new ApiPaymentTypeClientRequestModel();
			model.SetProperties("A");
			ApiPaymentTypeClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPaymentTypeModelMapper();
			var model = new ApiPaymentTypeClientResponseModel();
			model.SetProperties(1, "A");
			ApiPaymentTypeClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>89601ed391f57b6817322021d4ea9021</Hash>
</Codenesium>*/