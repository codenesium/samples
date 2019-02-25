using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CountryRegion")]
	[Trait("Area", "DALMapper")]
	public class TestDALCountryRegionMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCountryRegionMapper();
			ApiCountryRegionServerRequestModel model = new ApiCountryRegionServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			CountryRegion response = mapper.MapModelToEntity("A", model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCountryRegionMapper();
			CountryRegion item = new CountryRegion();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCountryRegionServerResponseModel response = mapper.MapEntityToModel(item);

			response.CountryRegionCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCountryRegionMapper();
			CountryRegion item = new CountryRegion();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiCountryRegionServerResponseModel> response = mapper.MapEntityToModel(new List<CountryRegion>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>03695c58ea227cbcd82790f3e4144336</Hash>
</Codenesium>*/