using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Vendor")]
	[Trait("Area", "DALMapper")]
	public class TestDALVendorMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVendorMapper();
			ApiVendorServerRequestModel model = new ApiVendorServerRequestModel();
			model.SetProperties("A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			Vendor response = mapper.MapModelToEntity(1, model);

			response.AccountNumber.Should().Be("A");
			response.ActiveFlag.Should().Be(true);
			response.CreditRating.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PreferredVendorStatu.Should().Be(true);
			response.PurchasingWebServiceURL.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVendorMapper();
			Vendor item = new Vendor();
			item.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			ApiVendorServerResponseModel response = mapper.MapEntityToModel(item);

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
		public void MapEntityToModelList()
		{
			var mapper = new DALVendorMapper();
			Vendor item = new Vendor();
			item.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");
			List<ApiVendorServerResponseModel> response = mapper.MapEntityToModel(new List<Vendor>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>972706bb6c3dc836d30ea8837adb9696</Hash>
</Codenesium>*/