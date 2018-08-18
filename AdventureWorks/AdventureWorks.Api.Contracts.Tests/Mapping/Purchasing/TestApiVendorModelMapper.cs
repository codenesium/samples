using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Vendor")]
	[Trait("Area", "ApiModel")]
	public class TestApiVendorModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiVendorModelMapper();
			var model = new ApiVendorRequestModel();
			model.SetProperties("A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			ApiVendorResponseModel response = mapper.MapRequestToResponse(1, model);

			response.AccountNumber.Should().Be("A");
			response.ActiveFlag.Should().Be(true);
			response.BusinessEntityID.Should().Be(1);
			response.CreditRating.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PreferredVendorStatu.Should().Be(true);
			response.PurchasingWebServiceURL.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiVendorModelMapper();
			var model = new ApiVendorResponseModel();
			model.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			ApiVendorRequestModel response = mapper.MapResponseToRequest(model);

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
			var mapper = new ApiVendorModelMapper();
			var model = new ApiVendorRequestModel();
			model.SetProperties("A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");

			JsonPatchDocument<ApiVendorRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVendorRequestModel();
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
    <Hash>935f6ded598b2bf9c6ef4fef0a2d13e3</Hash>
</Codenesium>*/