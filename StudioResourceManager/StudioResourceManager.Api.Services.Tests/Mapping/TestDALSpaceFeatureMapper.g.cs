using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpaceFeatureMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSpaceFeatureMapper();
			ApiSpaceFeatureServerRequestModel model = new ApiSpaceFeatureServerRequestModel();
			model.SetProperties("A");
			SpaceFeature response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSpaceFeatureMapper();
			SpaceFeature item = new SpaceFeature();
			item.SetProperties(1, "A");
			ApiSpaceFeatureServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSpaceFeatureMapper();
			SpaceFeature item = new SpaceFeature();
			item.SetProperties(1, "A");
			List<ApiSpaceFeatureServerResponseModel> response = mapper.MapEntityToModel(new List<SpaceFeature>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>851e8b839d99562c0a63fae0d8fada69</Hash>
</Codenesium>*/