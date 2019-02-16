using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Breed")]
	[Trait("Area", "DALMapper")]
	public class TestDALBreedMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALBreedMapper();
			ApiBreedServerRequestModel model = new ApiBreedServerRequestModel();
			model.SetProperties("A", 1);
			Breed response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALBreedMapper();
			Breed item = new Breed();
			item.SetProperties(1, "A", 1);
			ApiBreedServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALBreedMapper();
			Breed item = new Breed();
			item.SetProperties(1, "A", 1);
			List<ApiBreedServerResponseModel> response = mapper.MapEntityToModel(new List<Breed>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d67bc8d71bdccd98b620815fceb4f412</Hash>
</Codenesium>*/