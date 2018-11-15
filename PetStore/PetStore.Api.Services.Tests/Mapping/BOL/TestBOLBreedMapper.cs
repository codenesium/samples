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
	[Trait("Table", "Breed")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLBreedMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLBreedMapper();
			ApiBreedServerRequestModel model = new ApiBreedServerRequestModel();
			model.SetProperties("A");
			BOBreed response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLBreedMapper();
			BOBreed bo = new BOBreed();
			bo.SetProperties(1, "A");
			ApiBreedServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLBreedMapper();
			BOBreed bo = new BOBreed();
			bo.SetProperties(1, "A");
			List<ApiBreedServerResponseModel> response = mapper.MapBOToModel(new List<BOBreed>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1634b61cbe6226a6490560cf5d14e14a</Hash>
</Codenesium>*/