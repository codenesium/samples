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
	[Trait("Area", "DALMapper")]
	public class TestDALVendorMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALVendorMapper();
			var bo = new BOVendor();
			bo.SetProperties(1, "A", true, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");

			Vendor response = mapper.MapBOToEF(bo);

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
		public void MapEFToBO()
		{
			var mapper = new DALVendorMapper();
			Vendor entity = new Vendor();
			entity.SetProperties("A", true, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");

			BOVendor response = mapper.MapEFToBO(entity);

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
		public void MapEFToBOList()
		{
			var mapper = new DALVendorMapper();
			Vendor entity = new Vendor();
			entity.SetProperties("A", true, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, "A");

			List<BOVendor> response = mapper.MapEFToBO(new List<Vendor>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5971561a1f537f3937dbeb39a00891e3</Hash>
</Codenesium>*/