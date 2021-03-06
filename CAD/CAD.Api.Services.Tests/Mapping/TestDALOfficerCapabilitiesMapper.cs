using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OfficerCapabilities")]
	[Trait("Area", "DALMapper")]
	public class TestDALOfficerCapabilitiesMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALOfficerCapabilitiesMapper();
			ApiOfficerCapabilitiesServerRequestModel model = new ApiOfficerCapabilitiesServerRequestModel();
			model.SetProperties(1, 1);
			OfficerCapabilities response = mapper.MapModelToEntity(1, model);

			response.CapabilityId.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALOfficerCapabilitiesMapper();
			OfficerCapabilities item = new OfficerCapabilities();
			item.SetProperties(1, 1, 1);
			ApiOfficerCapabilitiesServerResponseModel response = mapper.MapEntityToModel(item);

			response.CapabilityId.Should().Be(1);
			response.Id.Should().Be(1);
			response.OfficerId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALOfficerCapabilitiesMapper();
			OfficerCapabilities item = new OfficerCapabilities();
			item.SetProperties(1, 1, 1);
			List<ApiOfficerCapabilitiesServerResponseModel> response = mapper.MapEntityToModel(new List<OfficerCapabilities>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bb80125a49db0bd0ffbe6a389c7337f9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/