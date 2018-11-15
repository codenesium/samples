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
	[Trait("Table", "StateProvince")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLStateProvinceMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLStateProvinceMapper();
			ApiStateProvinceServerRequestModel model = new ApiStateProvinceServerRequestModel();
			model.SetProperties("A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			BOStateProvince response = mapper.MapModelToBO(1, model);

			response.CountryRegionCode.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceCode.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLStateProvinceMapper();
			BOStateProvince bo = new BOStateProvince();
			bo.SetProperties(1, "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiStateProvinceServerResponseModel response = mapper.MapBOToModel(bo);

			response.CountryRegionCode.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceCode.Should().Be("A");
			response.StateProvinceID.Should().Be(1);
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLStateProvinceMapper();
			BOStateProvince bo = new BOStateProvince();
			bo.SetProperties(1, "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			List<ApiStateProvinceServerResponseModel> response = mapper.MapBOToModel(new List<BOStateProvince>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ffba99ae69827a58170cbcd64c5c3f2c</Hash>
</Codenesium>*/