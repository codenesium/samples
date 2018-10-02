using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VStateProvinceCountryRegion")]
	[Trait("Area", "DALMapper")]
	public class TestDALVStateProvinceCountryRegionMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALVStateProvinceCountryRegionMapper();
			var bo = new BOVStateProvinceCountryRegion();
			bo.SetProperties(1, "A", "A", true, "A", "A", 1);

			VStateProvinceCountryRegion response = mapper.MapBOToEF(bo);

			response.CountryRegionCode.Should().Be("A");
			response.CountryRegionName.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceID.Should().Be(1);
			response.StateProvinceName.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALVStateProvinceCountryRegionMapper();
			VStateProvinceCountryRegion entity = new VStateProvinceCountryRegion();
			entity.SetProperties("A", "A", true, "A", 1, "A", 1);

			BOVStateProvinceCountryRegion response = mapper.MapEFToBO(entity);

			response.CountryRegionCode.Should().Be("A");
			response.CountryRegionName.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceID.Should().Be(1);
			response.StateProvinceName.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALVStateProvinceCountryRegionMapper();
			VStateProvinceCountryRegion entity = new VStateProvinceCountryRegion();
			entity.SetProperties("A", "A", true, "A", 1, "A", 1);

			List<BOVStateProvinceCountryRegion> response = mapper.MapEFToBO(new List<VStateProvinceCountryRegion>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5e368627d36f5fd17cf9a884fa60e89d</Hash>
</Codenesium>*/