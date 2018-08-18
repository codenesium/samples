using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
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
			model.SetProperties("A", 1);
			BOSpaceFeature response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSpaceFeatureMapper();
			BOSpaceFeature bo = new BOSpaceFeature();
			bo.SetProperties(1, "A", 1);
			ApiSpaceFeatureResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSpaceFeatureMapper();
			BOSpaceFeature bo = new BOSpaceFeature();
			bo.SetProperties(1, "A", 1);
			List<ApiSpaceFeatureResponseModel> response = mapper.MapBOToModel(new List<BOSpaceFeature>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>869937f8637b00577d990ad61fd72b69</Hash>
</Codenesium>*/