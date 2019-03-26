using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "StateProvince")]
	[Trait("Area", "ApiModel")]
	public class TestApiStateProvinceModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiStateProvinceModelMapper();
			var model = new ApiStateProvinceClientRequestModel();
			model.SetProperties("A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiStateProvinceClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CountryRegionCode.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceCode.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiStateProvinceModelMapper();
			var model = new ApiStateProvinceClientResponseModel();
			model.SetProperties(1, "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiStateProvinceClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.CountryRegionCode.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceCode.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>314bc146186358c42e7b9564b7f7255f</Hash>
</Codenesium>*/