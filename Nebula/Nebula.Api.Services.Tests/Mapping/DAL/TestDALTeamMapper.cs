using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Team")]
	[Trait("Area", "DALMapper")]
	public class TestDALTeamMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTeamMapper();
			var bo = new BOTeam();
			bo.SetProperties(1, "A", 1);

			Team response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.OrganizationId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTeamMapper();
			Team entity = new Team();
			entity.SetProperties(1, "A", 1);

			BOTeam response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.OrganizationId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTeamMapper();
			Team entity = new Team();
			entity.SetProperties(1, "A", 1);

			List<BOTeam> response = mapper.MapEFToBO(new List<Team>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a101dfa40c99bbd1e2cc0b9efa34aa17</Hash>
</Codenesium>*/