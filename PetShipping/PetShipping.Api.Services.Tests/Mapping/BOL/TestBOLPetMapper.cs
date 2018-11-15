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
	[Trait("Table", "Pet")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPetMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPetMapper();
			ApiPetServerRequestModel model = new ApiPetServerRequestModel();
			model.SetProperties(1, 1, "A", 1);
			BOPet response = mapper.MapModelToBO(1, model);

			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPetMapper();
			BOPet bo = new BOPet();
			bo.SetProperties(1, 1, 1, "A", 1);
			ApiPetServerResponseModel response = mapper.MapBOToModel(bo);

			response.BreedId.Should().Be(1);
			response.ClientId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Weight.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPetMapper();
			BOPet bo = new BOPet();
			bo.SetProperties(1, 1, 1, "A", 1);
			List<ApiPetServerResponseModel> response = mapper.MapBOToModel(new List<BOPet>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2a418047ced82c703ad6953644e296aa</Hash>
</Codenesium>*/