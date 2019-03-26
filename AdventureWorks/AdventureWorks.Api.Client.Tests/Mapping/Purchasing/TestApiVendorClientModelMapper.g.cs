using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Vendor")]
	[Trait("Area", "ApiModel")]
	public class TestApiVendorModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiVendorModelMapper();
			var model = new ApiVendorClientRequestModel();
			model.SetProperties("A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			ApiVendorClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AccountNumber.Should().Be("A");
			response.ActiveFlag.Should().Be(true);
			response.CreditRating.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PreferredVendorStatu.Should().Be(true);
			response.PurchasingWebServiceURL.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiVendorModelMapper();
			var model = new ApiVendorClientResponseModel();
			model.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			ApiVendorClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.AccountNumber.Should().Be("A");
			response.ActiveFlag.Should().Be(true);
			response.CreditRating.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PreferredVendorStatu.Should().Be(true);
			response.PurchasingWebServiceURL.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>2f5e8873ce5d03b3a17925d707902d87</Hash>
</Codenesium>*/