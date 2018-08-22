using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceXSpaceFeature")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpaceXSpaceFeatureMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSpaceXSpaceFeatureMapper();
			var bo = new BOSpaceXSpaceFeature();
			bo.SetProperties(1, 1, 1, 1);

			SpaceXSpaceFeature response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSpaceXSpaceFeatureMapper();
			SpaceXSpaceFeature entity = new SpaceXSpaceFeature();
			entity.SetProperties(1, 1, 1, 1);

			BOSpaceXSpaceFeature response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.SpaceFeatureId.Should().Be(1);
			response.SpaceId.Should().Be(1);
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSpaceXSpaceFeatureMapper();
			SpaceXSpaceFeature entity = new SpaceXSpaceFeature();
			entity.SetProperties(1, 1, 1, 1);

			List<BOSpaceXSpaceFeature> response = mapper.MapEFToBO(new List<SpaceXSpaceFeature>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b25871309e95472e712560975968eaad</Hash>
</Codenesium>*/