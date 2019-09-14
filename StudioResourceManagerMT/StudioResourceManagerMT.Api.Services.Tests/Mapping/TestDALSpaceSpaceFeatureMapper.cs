using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>3294555740e7b12f4259fd12a9efd83a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/