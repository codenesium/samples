using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerRefCapability")]
	[Trait("Area", "DALMapper")]
	public class TestDALOfficerRefCapabilityMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALOfficerRefCapabilityMapper();
			ApiOfficerRefCapabilityServerRequestModel model = new ApiOfficerRefCapabilityServerRequestModel();
			model.SetProperties(1, 1);
			OfficerRefCapability response = mapper.MapModelToEntity(1, model);

			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALOfficerRefCapabilityMapper();
			OfficerRefCapability item = new OfficerRefCapability();
			item.SetProperties(1, 1, 1);
			ApiOfficerRefCapabilityServerResponseModel response = mapper.MapEntityToModel(item);

			response.CapabilityId.Should().Be(1);
			response.Id.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALOfficerRefCapabilityMapper();
			OfficerRefCapability item = new OfficerRefCapability();
			item.SetProperties(1, 1, 1);
			List<ApiOfficerRefCapabilityServerResponseModel> response = mapper.MapEntityToModel(new List<OfficerRefCapability>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f7c5cc5d412d1f191ce87cb6fe96c6c4</Hash>
</Codenesium>*/