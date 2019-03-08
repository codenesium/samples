using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services
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
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m);
			Pet response = mapper.MapModelToEntity(1, model);

			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPetMapper();
			Pet item = new Pet();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m);
			ApiPetServerResponseModel response = mapper.MapEntityToModel(item);

			response.AcquiredDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.BreedId.Should().Be(1);
			response.Description.Should().Be("A");
			response.PenId.Should().Be(1);
			response.Price.Should().Be(1m);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPetMapper();
			Pet item = new Pet();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A", 1, 1m);
			List<ApiPetServerResponseModel> response = mapper.MapEntityToModel(new List<Pet>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1796aa4244c26375f351a1b3901eb31e</Hash>
</Codenesium>*/