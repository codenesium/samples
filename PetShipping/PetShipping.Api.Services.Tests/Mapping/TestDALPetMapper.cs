using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pet")]
	[Trait("Area", "DALMapper")]
	public class TestDALPetMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPetMapper();
			ApiPetServerRequestModel model = new ApiPetServerRequestModel();
			model.SetProperties(1, 1, "A", 1);
			Pet response = mapper.MapModelToEntity(1, model);

			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPetMapper();
			Pet item = new Pet();
			item.SetProperties(1, 1, 1, "A", 1);
			ApiPetServerResponseModel response = mapper.MapEntityToModel(item);

			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPetMapper();
			Pet item = new Pet();
			item.SetProperties(1, 1, 1, "A", 1);
			List<ApiPetServerResponseModel> response = mapper.MapEntityToModel(new List<Pet>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bb7c251290399d239bcb2948eb946c40</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/