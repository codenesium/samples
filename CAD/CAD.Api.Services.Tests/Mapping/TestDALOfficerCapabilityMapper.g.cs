using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerCapability")]
	[Trait("Area", "DALMapper")]
	public class TestDALOfficerCapabilityMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALOfficerCapabilityMapper();
			ApiOfficerCapabilityServerRequestModel model = new ApiOfficerCapabilityServerRequestModel();
			model.SetProperties(1);
			OfficerCapability response = mapper.MapModelToEntity(1, model);

			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALOfficerCapabilityMapper();
			OfficerCapability item = new OfficerCapability();
			item.SetProperties(1, 1);
			ApiOfficerCapabilityServerResponseModel response = mapper.MapEntityToModel(item);

			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALOfficerCapabilityMapper();
			OfficerCapability item = new OfficerCapability();
			item.SetProperties(1, 1);
			List<ApiOfficerCapabilityServerResponseModel> response = mapper.MapEntityToModel(new List<OfficerCapability>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ebf1f7dc365d065b37fa518f816d3539</Hash>
</Codenesium>*/