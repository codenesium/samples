using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProjectGroup")]
	[Trait("Area", "DALMapper")]
	public class TestDALProjectGroupMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProjectGroupMapper();
			var bo = new BOProjectGroup();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A");

			ProjectGroup response = mapper.MapBOToEF(bo);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALProjectGroupMapper();
			ProjectGroup entity = new ProjectGroup();
			entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A");

			BOProjectGroup response = mapper.MapEFToBO(entity);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALProjectGroupMapper();
			ProjectGroup entity = new ProjectGroup();
			entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A");

			List<BOProjectGroup> response = mapper.MapEFToBO(new List<ProjectGroup>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>36fbec9ba67283adddb0e9aa640e5b17</Hash>
</Codenesium>*/