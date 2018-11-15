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
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLUnitMeasureMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLUnitMeasureMapper();
			ApiUnitMeasureServerRequestModel model = new ApiUnitMeasureServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BOUnitMeasure response = mapper.MapModelToBO("A", model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLUnitMeasureMapper();
			BOUnitMeasure bo = new BOUnitMeasure();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiUnitMeasureServerResponseModel response = mapper.MapBOToModel(bo);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.UnitMeasureCode.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLUnitMeasureMapper();
			BOUnitMeasure bo = new BOUnitMeasure();
			bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiUnitMeasureServerResponseModel> response = mapper.MapBOToModel(new List<BOUnitMeasure>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ee64fe12c26c675e54deb60699591a88</Hash>
</Codenesium>*/