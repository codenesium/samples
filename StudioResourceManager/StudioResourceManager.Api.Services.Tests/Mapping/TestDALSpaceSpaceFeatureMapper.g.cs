using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpaceSpaceFeatureMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSpaceSpaceFeatureMapper();
			ApiSpaceSpaceFeatureServerRequestModel model = new ApiSpaceSpaceFeatureServerRequestModel();
			model.SetProperties(1, 1);
			SpaceSpaceFeature response = mapper.MapModelToEntity(1, model);

			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSpaceSpaceFeatureMapper();
			SpaceSpaceFeature item = new SpaceSpaceFeature();
			item.SetProperties(1, 1, 1);
			ApiSpaceSpaceFeatureServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSpaceSpaceFeatureMapper();
			SpaceSpaceFeature item = new SpaceSpaceFeature();
			item.SetProperties(1, 1, 1);
			List<ApiSpaceSpaceFeatureServerResponseModel> response = mapper.MapEntityToModel(new List<SpaceSpaceFeature>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b6442e442fd6e69cfa6e89ca58762719</Hash>
</Codenesium>*/