using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Unit")]
	[Trait("Area", "DALMapper")]
	public class TestDALUnitMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALUnitMapper();
			ApiUnitServerRequestModel model = new ApiUnitServerRequestModel();
			model.SetProperties("A");
			Unit response = mapper.MapModelToEntity(1, model);

			response.CallSign.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALUnitMapper();
			Unit item = new Unit();
			item.SetProperties(1, "A");
			ApiUnitServerResponseModel response = mapper.MapEntityToModel(item);

			response.CallSign.Should().Be("A");
			response.Id.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALUnitMapper();
			Unit item = new Unit();
			item.SetProperties(1, "A");
			List<ApiUnitServerResponseModel> response = mapper.MapEntityToModel(new List<Unit>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f575abb389333bc2a751dec080b56872</Hash>
</Codenesium>*/