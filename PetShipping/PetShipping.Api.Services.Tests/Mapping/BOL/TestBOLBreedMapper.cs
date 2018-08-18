using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
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
			ApiBreedRequestModel model = new ApiBreedRequestModel();
			model.SetProperties("A", 1);
			BOBreed response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLBreedMapper();
			BOBreed bo = new BOBreed();
			bo.SetProperties(1, "A", 1);
			ApiBreedResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.SpeciesId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLBreedMapper();
			BOBreed bo = new BOBreed();
			bo.SetProperties(1, "A", 1);
			List<ApiBreedResponseModel> response = mapper.MapBOToModel(new List<BOBreed>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8a8a61bb6f9413ccb22ac57fd69f9895</Hash>
</Codenesium>*/