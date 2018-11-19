using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Space")]
	[Trait("Area", "DALMapper")]
	public class TestDALSpaceMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSpaceMapper();
			var bo = new BOSpace();
			bo.SetProperties(1, "A", "A");

			Space response = mapper.MapBOToEF(bo);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSpaceMapper();
			Space entity = new Space();
			entity.SetProperties("A", 1, "A");

			BOSpace response = mapper.MapEFToBO(entity);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSpaceMapper();
			Space entity = new Space();
			entity.SetProperties("A", 1, "A");

			List<BOSpace> response = mapper.MapEFToBO(new List<Space>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>833e37b1e563962f4eb54a9b7bd95daf</Hash>
</Codenesium>*/