using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>02944e265a7b2e854522ca9854966e4e</Hash>
</Codenesium>*/