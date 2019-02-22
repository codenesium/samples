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
			model.SetProperties("A");
			OfficerCapability response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALOfficerCapabilityMapper();
			OfficerCapability item = new OfficerCapability();
			item.SetProperties(1, "A");
			ApiOfficerCapabilityServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALOfficerCapabilityMapper();
			OfficerCapability item = new OfficerCapability();
			item.SetProperties(1, "A");
			List<ApiOfficerCapabilityServerResponseModel> response = mapper.MapEntityToModel(new List<OfficerCapability>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>47ce6e5a5dcfdd545cba39fbe789c026</Hash>
</Codenesium>*/