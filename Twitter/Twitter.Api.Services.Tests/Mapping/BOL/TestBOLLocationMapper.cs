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
			ApiLocationServerRequestModel model = new ApiLocationServerRequestModel();
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
			ApiLocationServerResponseModel response = mapper.MapBOToModel(bo);

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
			List<ApiLocationServerResponseModel> response = mapper.MapBOToModel(new List<BOLocation>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>62193334d04db029a3bc0f987723e64f</Hash>
</Codenesium>*/