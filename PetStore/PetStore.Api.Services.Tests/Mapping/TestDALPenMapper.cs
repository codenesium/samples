using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pen")]
	[Trait("Area", "DALMapper")]
	public class TestDALPenMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPenMapper();
			ApiPenServerRequestModel model = new ApiPenServerRequestModel();
			model.SetProperties("A");
			Pen response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPenMapper();
			Pen item = new Pen();
			item.SetProperties(1, "A");
			ApiPenServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPenMapper();
			Pen item = new Pen();
			item.SetProperties(1, "A");
			List<ApiPenServerResponseModel> response = mapper.MapEntityToModel(new List<Pen>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e58ed38ef59d93f4523054f86ec309c5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/