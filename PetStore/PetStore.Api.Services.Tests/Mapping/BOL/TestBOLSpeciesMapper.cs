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
    <Hash>392152073b2a4bb29f03738d22514e04</Hash>
</Codenesium>*/