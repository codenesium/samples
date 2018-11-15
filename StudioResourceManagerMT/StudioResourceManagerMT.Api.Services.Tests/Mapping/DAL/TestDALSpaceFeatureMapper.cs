using FluentAssertions;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SpaceFeature")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpaceFeatureMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSpaceFeatureMapper();
			var bo = new BOSpaceFeature();
			bo.SetProperties(1, "A");

			SpaceFeature response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSpaceFeatureMapper();
			SpaceFeature entity = new SpaceFeature();
			entity.SetProperties(1, "A");

			BOSpaceFeature response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSpaceFeatureMapper();
			SpaceFeature entity = new SpaceFeature();
			entity.SetProperties(1, "A");

			List<BOSpaceFeature> response = mapper.MapEFToBO(new List<SpaceFeature>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>977ca4a094852e19a4d425678a755973</Hash>
</Codenesium>*/