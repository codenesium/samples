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
	[Trait("Table", "Species")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSpeciesMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSpeciesMapper();
			ApiSpeciesServerRequestModel model = new ApiSpeciesServerRequestModel();
			model.SetProperties("A");
			BOSpecies response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSpeciesMapper();
			BOSpecies bo = new BOSpecies();
			bo.SetProperties(1, "A");
			ApiSpeciesServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSpeciesMapper();
			BOSpecies bo = new BOSpecies();
			bo.SetProperties(1, "A");
			List<ApiSpeciesServerResponseModel> response = mapper.MapBOToModel(new List<BOSpecies>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>435dd12f604e0866bf8641ec736cc45c</Hash>
</Codenesium>*/