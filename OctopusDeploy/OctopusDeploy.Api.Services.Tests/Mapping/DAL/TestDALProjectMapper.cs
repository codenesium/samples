using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Project")]
	[Trait("Area", "DALMapper")]
	public class TestDALProjectMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALProjectMapper();
			var bo = new BOProject();
			bo.SetProperties("A", true, BitConverter.GetBytes(1), "A", true, "A", true, "A", "A", "A", "A", "A", "A");

			Project response = mapper.MapBOToEF(bo);

			response.AutoCreateRelease.Should().Be(true);
			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DeploymentProcessId.Should().Be("A");
			response.DiscreteChannelRelease.Should().Be(true);
			response.Id.Should().Be("A");
			response.IncludedLibraryVariableSetIds.Should().Be("A");
			response.IsDisabled.Should().Be(true);
			response.JSON.Should().Be("A");
			response.LifecycleId.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectGroupId.Should().Be("A");
			response.Slug.Should().Be("A");
			response.VariableSetId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALProjectMapper();
			Project entity = new Project();
			entity.SetProperties(true, BitConverter.GetBytes(1), "A", true, "A", "A", true, "A", "A", "A", "A", "A", "A");

			BOProject response = mapper.MapEFToBO(entity);

			response.AutoCreateRelease.Should().Be(true);
			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DeploymentProcessId.Should().Be("A");
			response.DiscreteChannelRelease.Should().Be(true);
			response.Id.Should().Be("A");
			response.IncludedLibraryVariableSetIds.Should().Be("A");
			response.IsDisabled.Should().Be(true);
			response.JSON.Should().Be("A");
			response.LifecycleId.Should().Be("A");
			response.Name.Should().Be("A");
			response.ProjectGroupId.Should().Be("A");
			response.Slug.Should().Be("A");
			response.VariableSetId.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALProjectMapper();
			Project entity = new Project();
			entity.SetProperties(true, BitConverter.GetBytes(1), "A", true, "A", "A", true, "A", "A", "A", "A", "A", "A");

			List<BOProject> response = mapper.MapEFToBO(new List<Project>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bd195efc579868a3c7d2c1f3dd3af765</Hash>
</Codenesium>*/