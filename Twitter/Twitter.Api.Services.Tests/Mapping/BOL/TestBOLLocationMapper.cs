using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLLocationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLocationMapper();
			ApiLocationRequestModel model = new ApiLocationRequestModel();
			model.SetProperties(1, 1, "A");
			BOLocation response = mapper.MapModelToBO(1, model);

			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLocationMapper();
			BOLocation bo = new BOLocation();
			bo.SetProperties(1, 1, 1, "A");
			ApiLocationResponseModel response = mapper.MapBOToModel(bo);

			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationId.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLocationMapper();
			BOLocation bo = new BOLocation();
			bo.SetProperties(1, 1, 1, "A");
			List<ApiLocationResponseModel> response = mapper.MapBOToModel(new List<BOLocation>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d13e799135b8b177973fec6ecd8e9438</Hash>
</Codenesium>*/