using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Vendor")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVendorMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVendorMapper();
			ApiVendorServerRequestModel model = new ApiVendorServerRequestModel();
			model.SetProperties("A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			BOVendor response = mapper.MapModelToBO(1, model);

			response.AccountNumber.Should().Be("A");
			response.ActiveFlag.Should().Be(true);
			response.CreditRating.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PreferredVendorStatu.Should().Be(true);
			response.PurchasingWebServiceURL.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLVendorMapper();
			BOVendor bo = new BOVendor();
			bo.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			ApiVendorServerResponseModel response = mapper.MapBOToModel(bo);

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
		public void MapBOToModelList()
		{
			var mapper = new BOLVendorMapper();
			BOVendor bo = new BOVendor();
			bo.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			List<ApiVendorServerResponseModel> response = mapper.MapBOToModel(new List<BOVendor>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a1acbc28d9dfe4f3567ab071d0c570d9</Hash>
</Codenesium>*/