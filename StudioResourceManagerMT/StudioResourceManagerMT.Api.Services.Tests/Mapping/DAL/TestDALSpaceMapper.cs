using FluentAssertions;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
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
    <Hash>9341e90a106824afd91bfac386176b26</Hash>
</Codenesium>*/