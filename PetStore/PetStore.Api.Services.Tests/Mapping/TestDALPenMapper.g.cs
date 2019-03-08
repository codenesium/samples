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
    <Hash>85ebc417f73bca7c5ba9d2d9410d6385</Hash>
</Codenesium>*/