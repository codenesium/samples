using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DeploymentProcess")]
	[Trait("Area", "DALMapper")]
	public class TestDALDeploymentProcessMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALDeploymentProcessMapper();
			var bo = new BODeploymentProcess();
			bo.SetProperties("A", true, "A", "A", "A", 1);

			DeploymentProcess response = mapper.MapBOToEF(bo);

			response.Id.Should().Be("A");
			response.IsFrozen.Should().Be(true);
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALDeploymentProcessMapper();
			DeploymentProcess entity = new DeploymentProcess();
			entity.SetProperties("A", true, "A", "A", "A", 1);

			BODeploymentProcess response = mapper.MapEFToBO(entity);

			response.Id.Should().Be("A");
			response.IsFrozen.Should().Be(true);
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALDeploymentProcessMapper();
			DeploymentProcess entity = new DeploymentProcess();
			entity.SetProperties("A", true, "A", "A", "A", 1);

			List<BODeploymentProcess> response = mapper.MapEFToBO(new List<DeploymentProcess>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>13038222957f43e9da29eb4f99d0233a</Hash>
</Codenesium>*/