using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Airline")]
	[Trait("Area", "DALMapper")]
	public class TestDALAirlineMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALAirlineMapper();
			ApiAirlineServerRequestModel model = new ApiAirlineServerRequestModel();
			model.SetProperties("A");
			Airline response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALAirlineMapper();
			Airline item = new Airline();
			item.SetProperties(1, "A");
			ApiAirlineServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALAirlineMapper();
			Airline item = new Airline();
			item.SetProperties(1, "A");
			List<ApiAirlineServerResponseModel> response = mapper.MapEntityToModel(new List<Airline>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6c958226310099080a0b0f7dd7e64c29</Hash>
</Codenesium>*/