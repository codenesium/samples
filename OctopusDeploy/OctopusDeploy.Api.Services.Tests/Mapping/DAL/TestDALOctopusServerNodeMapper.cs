using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OctopusServerNode")]
	[Trait("Area", "DALMapper")]
	public class TestDALOctopusServerNodeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALOctopusServerNodeMapper();
			var bo = new BOOctopusServerNode();
			bo.SetProperties("A", true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");

			OctopusServerNode response = mapper.MapBOToEF(bo);

			response.Id.Should().Be("A");
			response.IsInMaintenanceMode.Should().Be(true);
			response.JSON.Should().Be("A");
			response.LastSeen.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.MaxConcurrentTasks.Should().Be(1);
			response.Name.Should().Be("A");
			response.Rank.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALOctopusServerNodeMapper();
			OctopusServerNode entity = new OctopusServerNode();
			entity.SetProperties("A", true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");

			BOOctopusServerNode response = mapper.MapEFToBO(entity);

			response.Id.Should().Be("A");
			response.IsInMaintenanceMode.Should().Be(true);
			response.JSON.Should().Be("A");
			response.LastSeen.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
			response.MaxConcurrentTasks.Should().Be(1);
			response.Name.Should().Be("A");
			response.Rank.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALOctopusServerNodeMapper();
			OctopusServerNode entity = new OctopusServerNode();
			entity.SetProperties("A", true, "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), 1, "A", "A");

			List<BOOctopusServerNode> response = mapper.MapEFToBO(new List<OctopusServerNode>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>79dd534ec0e1657e36e26c8c5941eaa2</Hash>
</Codenesium>*/