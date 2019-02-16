using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Destination")]
	[Trait("Area", "DALMapper")]
	public class TestDALDestinationMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALDestinationMapper();
			ApiDestinationServerRequestModel model = new ApiDestinationServerRequestModel();
			model.SetProperties(1, "A", 1);
			Destination response = mapper.MapModelToEntity(1, model);

			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALDestinationMapper();
			Destination item = new Destination();
			item.SetProperties(1, 1, "A", 1);
			ApiDestinationServerResponseModel response = mapper.MapEntityToModel(item);

			response.CountryId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALDestinationMapper();
			Destination item = new Destination();
			item.SetProperties(1, 1, "A", 1);
			List<ApiDestinationServerResponseModel> response = mapper.MapEntityToModel(new List<Destination>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dbb6fd87f58f8ea36679aeac39b18e48</Hash>
</Codenesium>*/