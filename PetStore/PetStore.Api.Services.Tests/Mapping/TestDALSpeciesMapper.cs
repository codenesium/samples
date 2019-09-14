using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services
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
    <Hash>87ae0b8145edfe2fbcb96c58cd40b770</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/