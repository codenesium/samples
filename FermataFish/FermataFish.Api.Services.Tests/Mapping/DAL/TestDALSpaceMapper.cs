using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
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
			bo.SetProperties(1, "A", "A", 1);

			Space response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSpaceMapper();
			Space entity = new Space();
			entity.SetProperties(1, "A", "A", 1);

			BOSpace response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSpaceMapper();
			Space entity = new Space();
			entity.SetProperties(1, "A", "A", 1);

			List<BOSpace> response = mapper.MapEFToBO(new List<Space>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b21f0d70962791c02337c89feebb4b20</Hash>
</Codenesium>*/