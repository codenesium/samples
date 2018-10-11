using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceSpaceFeature")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSpaceSpaceFeatureMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSpaceSpaceFeatureMapper();
			ApiSpaceSpaceFeatureRequestModel model = new ApiSpaceSpaceFeatureRequestModel();
			model.SetProperties(1);
			BOSpaceSpaceFeature response = mapper.MapModelToBO(1, model);

			response.SpaceFeatureId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSpaceSpaceFeatureMapper();
			BOSpaceSpaceFeature bo = new BOSpaceSpaceFeature();
			bo.SetProperties(1, 1);
			ApiSpaceSpaceFeatureResponseModel response = mapper.MapBOToModel(bo);

			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSpaceSpaceFeatureMapper();
			BOSpaceSpaceFeature bo = new BOSpaceSpaceFeature();
			bo.SetProperties(1, 1);
			List<ApiSpaceSpaceFeatureResponseModel> response = mapper.MapBOToModel(new List<BOSpaceSpaceFeature>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c6e166809e803f64714aca7cb17214da</Hash>
</Codenesium>*/