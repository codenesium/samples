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
			bo.SetProperties(1, "A", "A", true);

			Space response = mapper.MapBOToEF(bo);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSpaceMapper();
			Space entity = new Space();
			entity.SetProperties("A", 1, "A", true);

			BOSpace response = mapper.MapEFToBO(entity);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSpaceMapper();
			Space entity = new Space();
			entity.SetProperties("A", 1, "A", true);

			List<BOSpace> response = mapper.MapEFToBO(new List<Space>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b4b6b126af71732350fd56a2826446ca</Hash>
</Codenesium>*/