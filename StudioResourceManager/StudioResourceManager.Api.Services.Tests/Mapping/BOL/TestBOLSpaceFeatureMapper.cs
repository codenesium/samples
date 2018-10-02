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
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSpaceFeatureMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSpaceFeatureMapper();
			ApiSpaceFeatureRequestModel model = new ApiSpaceFeatureRequestModel();
			model.SetProperties("A");
			BOSpaceFeature response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSpaceFeatureMapper();
			BOSpaceFeature bo = new BOSpaceFeature();
			bo.SetProperties(1, "A");
			ApiSpaceFeatureResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSpaceFeatureMapper();
			BOSpaceFeature bo = new BOSpaceFeature();
			bo.SetProperties(1, "A");
			List<ApiSpaceFeatureResponseModel> response = mapper.MapBOToModel(new List<BOSpaceFeature>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>cae646fbd2cd9c1610480eb5f3bee410</Hash>
</Codenesium>*/