using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "DALMapper")]
	public class TestDALUnitMeasureMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALUnitMeasureMapper();
			ApiUnitMeasureServerRequestModel model = new ApiUnitMeasureServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			UnitMeasure response = mapper.MapModelToEntity("A", model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALUnitMeasureMapper();
			UnitMeasure item = new UnitMeasure();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiUnitMeasureServerResponseModel response = mapper.MapEntityToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALUnitMeasureMapper();
			UnitMeasure item = new UnitMeasure();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiUnitMeasureServerResponseModel> response = mapper.MapEntityToModel(new List<UnitMeasure>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>71a777c273b7d86ac19f54bb92064dcc</Hash>
</Codenesium>*/