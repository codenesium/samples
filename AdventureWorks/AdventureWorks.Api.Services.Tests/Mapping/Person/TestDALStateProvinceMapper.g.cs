using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "StateProvince")]
	[Trait("Area", "DALMapper")]
	public class TestDALStateProvinceMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALStateProvinceMapper();
			ApiStateProvinceServerRequestModel model = new ApiStateProvinceServerRequestModel();
			model.SetProperties("A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			StateProvince response = mapper.MapModelToEntity(1, model);

			response.CountryRegionCode.Should().Be("A");
			response.IsOnlyStateProvinceFlag.Should().Be(true);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceCode.Should().Be("A");
			response.TerritoryID.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALStateProvinceMapper();
			StateProvince item = new StateProvince();
			item.SetProperties(1, "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			ApiStateProvinceServerResponseModel response = mapper.MapEntityToModel(item);

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
		public void MapEntityToModelList()
		{
			var mapper = new DALStateProvinceMapper();
			StateProvince item = new StateProvince();
			item.SetProperties(1, "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);
			List<ApiStateProvinceServerResponseModel> response = mapper.MapEntityToModel(new List<StateProvince>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>be0f280714476050dec1d2acd91defc4</Hash>
</Codenesium>*/