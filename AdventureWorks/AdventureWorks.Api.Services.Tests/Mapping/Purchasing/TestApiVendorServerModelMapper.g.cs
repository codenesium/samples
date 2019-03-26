using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Vendor")]
	[Trait("Area", "ApiModel")]
	public class TestApiVendorServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiVendorServerModelMapper();
			var model = new ApiVendorServerRequestModel();
			model.SetProperties("A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			ApiVendorServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiVendorServerModelMapper();
			var model = new ApiVendorServerResponseModel();
			model.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			ApiVendorServerRequestModel response = mapper.MapServerResponseToRequest(model);
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
		public void CreatePatch()
		{
			var mapper = new ApiVendorServerModelMapper();
			var model = new ApiVendorServerRequestModel();
			model.SetProperties("A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");

			JsonPatchDocument<ApiVendorServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVendorServerRequestModel();
			patch.ApplyTo(response);
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
    <Hash>d7b71d709021e30951d226f9c43c9e86</Hash>
</Codenesium>*/