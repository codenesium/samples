using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitDisposition")]
	[Trait("Area", "DALMapper")]
	public class TestDALUnitDispositionMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALUnitDispositionMapper();
			ApiUnitDispositionServerRequestModel model = new ApiUnitDispositionServerRequestModel();
			model.SetProperties("A");
			UnitDisposition response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALUnitDispositionMapper();
			UnitDisposition item = new UnitDisposition();
			item.SetProperties(1, "A");
			ApiUnitDispositionServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALUnitDispositionMapper();
			UnitDisposition item = new UnitDisposition();
			item.SetProperties(1, "A");
			List<ApiUnitDispositionServerResponseModel> response = mapper.MapEntityToModel(new List<UnitDisposition>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f6a644e13513c28c02cf6f57b42b72ab</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/