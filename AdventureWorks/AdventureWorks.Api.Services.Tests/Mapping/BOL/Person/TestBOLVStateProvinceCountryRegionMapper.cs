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
	[Trait("Table", "VStateProvinceCountryRegion")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVStateProvinceCountryRegionMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVStateProvinceCountryRegionMapper();
			ApiVStateProvinceCountryRegionRequestModel model = new ApiVStateProvinceCountryRegionRequestModel();
			model.SetProperties("A", "A", true, "A", "A", 1);
			BOVStateProvinceCountryRegion response = mapper.MapModelToBO(1, model);

			response.CountryRegionCode.Should().Be("A");
			response.CountryRegionName.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceName.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLVStateProvinceCountryRegionMapper();
			BOVStateProvinceCountryRegion bo = new BOVStateProvinceCountryRegion();
			bo.SetProperties(1, "A", "A", true, "A", "A", 1);
			ApiVStateProvinceCountryRegionResponseModel response = mapper.MapBOToModel(bo);

			response.CountryRegionCode.Should().Be("A");
			response.CountryRegionName.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceID.Should().Be(1);
			response.StateProvinceName.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLVStateProvinceCountryRegionMapper();
			BOVStateProvinceCountryRegion bo = new BOVStateProvinceCountryRegion();
			bo.SetProperties(1, "A", "A", true, "A", "A", 1);
			List<ApiVStateProvinceCountryRegionResponseModel> response = mapper.MapBOToModel(new List<BOVStateProvinceCountryRegion>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d17df066a86fcfe974d58e0187176511</Hash>
</Codenesium>*/