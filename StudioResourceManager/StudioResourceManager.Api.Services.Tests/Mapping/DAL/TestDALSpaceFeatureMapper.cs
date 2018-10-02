using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
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
    <Hash>16f15a27283a3d9031f05213b6bea586</Hash>
</Codenesium>*/