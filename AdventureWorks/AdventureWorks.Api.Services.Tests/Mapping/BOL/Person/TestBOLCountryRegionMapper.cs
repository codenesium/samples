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
	[Trait("Table", "CountryRegion")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCountryRegionMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCountryRegionMapper();
			ApiCountryRegionServerRequestModel model = new ApiCountryRegionServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOCountryRegion response = mapper.MapModelToBO("A", model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCountryRegionMapper();
			BOCountryRegion bo = new BOCountryRegion();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiCountryRegionServerResponseModel response = mapper.MapBOToModel(bo);

			response.CountryRegionCode.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCountryRegionMapper();
			BOCountryRegion bo = new BOCountryRegion();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiCountryRegionServerResponseModel> response = mapper.MapBOToModel(new List<BOCountryRegion>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>11ba7d2c8976a60b2d8e43615088682d</Hash>
</Codenesium>*/