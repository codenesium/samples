using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Species")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpeciesMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSpeciesMapper();
			ApiSpeciesServerRequestModel model = new ApiSpeciesServerRequestModel();
			model.SetProperties("A");
			Species response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSpeciesMapper();
			Species item = new Species();
			item.SetProperties(1, "A");
			ApiSpeciesServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSpeciesMapper();
			Species item = new Species();
			item.SetProperties(1, "A");
			List<ApiSpeciesServerResponseModel> response = mapper.MapEntityToModel(new List<Species>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a81e92644c20a7887e50e7703a2fc923</Hash>
</Codenesium>*/