using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VStateProvinceCountryRegion")]
	[Trait("Area", "ApiModel")]
	public class TestApiVStateProvinceCountryRegionModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiVStateProvinceCountryRegionModelMapper();
			var model = new ApiVStateProvinceCountryRegionRequestModel();
			model.SetProperties("A", "A", true, "A", "A", 1);
			ApiVStateProvinceCountryRegionResponseModel response = mapper.MapRequestToResponse(1, model);

			response.CountryRegionCode.Should().Be("A");
			response.CountryRegionName.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceID.Should().Be(1);
			response.StateProvinceName.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiVStateProvinceCountryRegionModelMapper();
			var model = new ApiVStateProvinceCountryRegionResponseModel();
			model.SetProperties(1, "A", "A", true, "A", "A", 1);
			ApiVStateProvinceCountryRegionRequestModel response = mapper.MapResponseToRequest(model);

			response.CountryRegionCode.Should().Be("A");
			response.CountryRegionName.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceName.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiVStateProvinceCountryRegionModelMapper();
			var model = new ApiVStateProvinceCountryRegionRequestModel();
			model.SetProperties("A", "A", true, "A", "A", 1);

			JsonPatchDocument<ApiVStateProvinceCountryRegionRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiVStateProvinceCountryRegionRequestModel();
			patch.ApplyTo(response);
			response.CountryRegionCode.Should().Be("A");
			response.CountryRegionName.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceName.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5f2683f2c910aeb8d8ed5a4c368a980d</Hash>
</Codenesium>*/