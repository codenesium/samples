using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "City")]
	[Trait("Area", "DALMapper")]
	public class TestDALCityMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCityMapper();
			ApiCityServerRequestModel model = new ApiCityServerRequestModel();
			model.SetProperties("A", 1);
			City response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCityMapper();
			City item = new City();
			item.SetProperties(1, "A", 1);
			ApiCityServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.ProvinceId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCityMapper();
			City item = new City();
			item.SetProperties(1, "A", 1);
			List<ApiCityServerResponseModel> response = mapper.MapEntityToModel(new List<City>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f56d193f8e6cc21d6d8b4d701cb2ff42</Hash>
</Codenesium>*/