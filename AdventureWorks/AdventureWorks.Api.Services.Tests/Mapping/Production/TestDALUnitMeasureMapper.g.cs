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
		public void MapModelToBO()
		{
			var mapper = new DALUnitMeasureMapper();
			ApiUnitMeasureServerRequestModel model = new ApiUnitMeasureServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			UnitMeasure response = mapper.MapModelToBO("A", model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALUnitMeasureMapper();
			UnitMeasure item = new UnitMeasure();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiUnitMeasureServerResponseModel response = mapper.MapBOToModel(item);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALUnitMeasureMapper();
			UnitMeasure item = new UnitMeasure();
			item.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiUnitMeasureServerResponseModel> response = mapper.MapBOToModel(new List<UnitMeasure>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>db04ffcf6f7a76dbc5c13810f253b990</Hash>
</Codenesium>*/