using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Location")]
	[Trait("Area", "DALMapper")]
	public class TestDALLocationMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALLocationMapper();
			ApiLocationServerRequestModel model = new ApiLocationServerRequestModel();
			model.SetProperties(1, 1, "A");
			Location response = mapper.MapModelToEntity(1, model);

			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALLocationMapper();
			Location item = new Location();
			item.SetProperties(1, 1, 1, "A");
			ApiLocationServerResponseModel response = mapper.MapEntityToModel(item);

			response.GpsLat.Should().Be(1);
			response.GpsLong.Should().Be(1);
			response.LocationId.Should().Be(1);
			response.LocationName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALLocationMapper();
			Location item = new Location();
			item.SetProperties(1, 1, 1, "A");
			List<ApiLocationServerResponseModel> response = mapper.MapEntityToModel(new List<Location>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f44f74071adb4662f5c9b66b317f92fa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/