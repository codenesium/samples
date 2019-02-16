using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services
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
			model.SetProperties("A");
			Breed response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALBreedMapper();
			Breed item = new Breed();
			item.SetProperties(1, "A");
			ApiBreedServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALBreedMapper();
			Breed item = new Breed();
			item.SetProperties(1, "A");
			List<ApiBreedServerResponseModel> response = mapper.MapEntityToModel(new List<Breed>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2695fb8ce15d1d1f346f5ebfef72d282</Hash>
</Codenesium>*/