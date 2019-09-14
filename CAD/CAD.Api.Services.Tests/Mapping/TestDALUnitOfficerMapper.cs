using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "UnitOfficer")]
	[Trait("Area", "DALMapper")]
	public class TestDALUnitOfficerMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALUnitOfficerMapper();
			ApiUnitOfficerServerRequestModel model = new ApiUnitOfficerServerRequestModel();
			model.SetProperties(1, 1);
			UnitOfficer response = mapper.MapModelToEntity(1, model);

			response.OfficerId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALUnitOfficerMapper();
			UnitOfficer item = new UnitOfficer();
			item.SetProperties(1, 1, 1);
			ApiUnitOfficerServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.OfficerId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALUnitOfficerMapper();
			UnitOfficer item = new UnitOfficer();
			item.SetProperties(1, 1, 1);
			List<ApiUnitOfficerServerResponseModel> response = mapper.MapEntityToModel(new List<UnitOfficer>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f8805b796522ef2a1de86d5437b795bb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/