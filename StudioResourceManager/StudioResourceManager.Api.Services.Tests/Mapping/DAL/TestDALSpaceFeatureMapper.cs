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
			bo.SetProperties(1, "A", true);

			SpaceFeature response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSpaceFeatureMapper();
			SpaceFeature entity = new SpaceFeature();
			entity.SetProperties(1, "A", true);

			BOSpaceFeature response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSpaceFeatureMapper();
			SpaceFeature entity = new SpaceFeature();
			entity.SetProperties(1, "A", true);

			List<BOSpaceFeature> response = mapper.MapEFToBO(new List<SpaceFeature>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dbec1cbb4a9a8f104c8bec0fbab91ac1</Hash>
</Codenesium>*/