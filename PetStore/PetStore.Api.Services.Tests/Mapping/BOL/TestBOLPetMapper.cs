using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pet")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPetMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPetMapper();
			ApiPetServerRequestModel model = new ApiPetServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);
			BOPet response = mapper.MapModelToBO(1, model);

			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPetMapper();
			BOPet bo = new BOPet();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);
			ApiPetServerResponseModel response = mapper.MapBOToModel(bo);

			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPetMapper();
			BOPet bo = new BOPet();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m, 1);
			List<ApiPetServerResponseModel> response = mapper.MapBOToModel(new List<BOPet>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e138c48ab9ea5754602cdf49fb14bcf5</Hash>
</Codenesium>*/