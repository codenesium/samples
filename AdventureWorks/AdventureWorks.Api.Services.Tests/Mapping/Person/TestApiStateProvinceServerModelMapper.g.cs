using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "StateProvince")]
	[Trait("Area", "ApiModel")]
	public class TestApiStateProvinceServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiStateProvinceServerModelMapper();
			var model = new ApiStateProvinceServerRequestModel();
			model.SetProperties("A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiStateProvinceServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiStateProvinceServerModelMapper();
			var model = new ApiStateProvinceServerResponseModel();
			model.SetProperties(1, "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiStateProvinceServerRequestModel response = mapper.MapServerResponseToRequest(model);
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
		public void CreatePatch()
		{
			var mapper = new ApiStateProvinceServerModelMapper();
			var model = new ApiStateProvinceServerRequestModel();
			model.SetProperties("A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);

			JsonPatchDocument<ApiStateProvinceServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiStateProvinceServerRequestModel();
			patch.ApplyTo(response);
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
    <Hash>26a44b6c0f5de259d6126977c141dcc9</Hash>
</Codenesium>*/