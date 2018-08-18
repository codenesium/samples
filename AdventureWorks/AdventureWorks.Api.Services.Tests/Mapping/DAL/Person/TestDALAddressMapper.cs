using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Address")]
	[Trait("Area", "DALMapper")]
	public class TestDALAddressMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALAddressMapper();
			var bo = new BOAddress();
			bo.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);

			Address response = mapper.MapBOToEF(bo);

			response.AddressID.Should().Be(1);
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALAddressMapper();
			Address entity = new Address();
			entity.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);

			BOAddress response = mapper.MapEFToBO(entity);

			response.AddressID.Should().Be(1);
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALAddressMapper();
			Address entity = new Address();
			entity.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);

			List<BOAddress> response = mapper.MapEFToBO(new List<Address>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c2f00d3ac577b7ac458981fd91a4b741</Hash>
</Codenesium>*/